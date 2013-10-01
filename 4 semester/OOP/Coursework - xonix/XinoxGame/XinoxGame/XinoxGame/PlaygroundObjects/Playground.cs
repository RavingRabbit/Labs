using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SupportTypes;
using UtilLib;
using XonixGame.GameObjects;
using XonixGame.GameObjectsBase;
using XonixGame.GameSettings;

namespace XonixGame.GameObjects
{
    [Serializable]
    public class Playground : InteractiveGameObject
    {
        private readonly PlaygroundBlock[,] _blocks;
        private readonly int _height;
        private readonly int _width;
        private int _blocksNumber;
        private bool _completedEventRaised;
        [NonSerialized] private List<DeadPathBlock> _deadPath;
        [NonSerialized] private bool _deadPathInProgress;
        [NonSerialized] private Queue<PathBlock> _deathBlocksLeftQueue;
        [NonSerialized] private Queue<PathBlock> _deathBlocksRightQueue;
        [NonSerialized] private List<PlaygroundBlock> _forIntersectionsBuffer;
        [NonSerialized] private HashSet<PlaygroundBlock> _forReplaceBuffer;
        [NonSerialized] private Sprite _grid;
        [NonSerialized] private List<PathBlock> _path;
        private Vector2 _position;
        [NonSerialized] private BoundingRectangle _rectangle;

        public Playground(IGame game, Vector2 position, int width, int height)
            : base(game)
        {
            Requires.Range(width > 0, "width");
            Requires.Range(height > 0, "height");
            _position = position;
            _width = width;
            _height = height;
            var pbg = new PlaygroundBlockGenerator(this, _height, _width);
            _blocks = pbg.GenerateBlocks();
            Init(game);
        }

        public List<PathBlock> Path
        {
            get { return _path; }
        }

        public override Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public override BoundingShape BoundingShape
        {
            get { return _rectangle; }
        }

        public override sealed float Width
        {
            get { return _width*Settings.Instance.PlaygroundBlockWidth; }
        }

        public override sealed float Height
        {
            get { return _height*Settings.Instance.PlaygroundBlockHeight; }
        }

        public Vector2 StartPosition
        {
            get { return _position + new Vector2(Width/2 - 25, Height - 63); }
        }

        public int GroundBlocksNumber { get; private set; }

        public int BlocksNumber
        {
            get { return _blocksNumber; }
        }

        private void Init(IGame game)
        {
            _rectangle = new BoundingRectangle
                {
                    Position = Position,
                    Width = _width*Settings.Instance.PlaygroundBlockWidth,
                    Height = _height*Settings.Instance.PlaygroundBlockHeight
                };
            _grid = game.ContentProvider.GetGridSprite(_width*Settings.Instance.PlaygroundBlockWidth,
                                                       _height*Settings.Instance.PlaygroundBlockHeight);
            _grid.Position = _position;
            GroundBlocksNumber = Count(block => block is GroundBlock);
            _blocksNumber = (int) (Count(block => block is GroundBlock || block is WaterBlock)*0.88);
            _forReplaceBuffer = new HashSet<PlaygroundBlock>();
            _forIntersectionsBuffer = new List<PlaygroundBlock>();
            _path = new List<PathBlock>();
            _deadPath = new List<DeadPathBlock>();
            _deathBlocksLeftQueue = new Queue<PathBlock>();
            _deathBlocksRightQueue = new Queue<PathBlock>();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            var game = context.Context as IGame;
            Debug.Assert(game != null, "game != null");
            Init(game);
        }

        private int Count(Predicate<PlaygroundBlock> predicate)
        {
            int count = 0;
            for (int index00 = 0; index00 < _blocks.GetLength(0); index00++)
                for (int index01 = 0; index01 < _blocks.GetLength(1); index01++)
                {
                    PlaygroundBlock playgroundBlock = _blocks[index00, index01];
                    if (predicate(playgroundBlock))
                        count++;
                }
            return count;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            int blockWight = Settings.Instance.PlaygroundBlockWidth;
            int nineWidth = blockWight*3;
            int nineHeight = Settings.Instance.PlaygroundBlockHeight*3;
            for (int i = 0; i < _height; i += 3)
            {
                if (i >= _height)
                    break;
                if (!Game.Camera.IsInView(_blocks[i, 0].Position, blockWight*_width, nineHeight))
                    continue;
                for (int j = 0; j < _width; j += 3)
                {
                    if (j >= _width)
                        break;
                    if (!Game.Camera.IsInView(_blocks[i, j].Position, nineWidth, nineHeight))
                        continue;
                    for (int m = i; m < _height && m < i + 3; m++)
                        for (int n = j; n < _width && n < j + 3; n++)
                            _blocks[m, n].Draw(spriteBatch);
                }
            }
            _grid.Draw(spriteBatch);
        }

        public override void Update(TimeSpan elapsed)
        {
            if (_deathBlocksLeftQueue.Count != 0)
            {
                PathBlock block = _deathBlocksLeftQueue.Dequeue();
                ReplaceWithDeadPath(block);
            }
            if (_deathBlocksRightQueue.Count != 0)
            {
                PathBlock block = _deathBlocksRightQueue.Dequeue();
                ReplaceWithDeadPath(block);
            }
            if (_deadPathInProgress && _path.Count != 0)
            {
                foreach (PathBlock pathBlock in _path)
                    _deathBlocksRightQueue.Enqueue(pathBlock);
                _path.Clear();
            }
            if (GroundBlocksNumber/BlocksNumber >= 1)
                OnCompleted();
            base.Update(elapsed);
        }

        public void StartDeadPath(PathBlock startBlock)
        {
            if (_deadPathInProgress)
                return;
            int blockNumberInPath = _path.FindIndex(block => block == startBlock);
            for (int i = blockNumberInPath; i < _path.Count; i++)
            {
                _deathBlocksRightQueue.Enqueue(_path[i]);
            }
            for (int i = blockNumberInPath - 1; i >= 0; i--)
            {
                _deathBlocksLeftQueue.Enqueue(_path[i]);
            }
            _path.Clear();
            _deadPathInProgress = true;
        }

        public override void Interact(IInteractive with)
        {
            Debug.Assert(Intersects(with));
            if (!_rectangle.Intersects(with.BoundingShape)) return;
            List<PlaygroundBlock> blocks = BlocksIntersects(with);
            foreach (PlaygroundBlock playgroundBlock in blocks)
            {
                playgroundBlock.Interact(with);
                with.Interact(playgroundBlock);
            }
        }

        public PlaygroundBlock FindBlockContaining(Vector2 point)
        {
            int i = (int) (point.Y - _position.Y)/Settings.Instance.PlaygroundBlockHeight;
            int j = (int) (point.X - _position.X)/Settings.Instance.PlaygroundBlockWidth;
            return _blocks[i, j];
        }

        public List<PlaygroundBlock> BlocksIntersects(IInteractive interactive)
        {
            //todo: ужс
            _forIntersectionsBuffer.Clear();
            Vector2 position = interactive.BoundingShape.Position;
            float width = interactive.BoundingShape.Width;
            float height = interactive.BoundingShape.Height;
            float widthBlocksNumber = width/Settings.Instance.PlaygroundBlockWidth + 1;
            float heightBlockNumber = height/Settings.Instance.PlaygroundBlockHeight + 1;
            int n = (int) (position.Y - _position.Y)/Settings.Instance.PlaygroundBlockHeight;
            int m = (int) (position.X - _position.X)/Settings.Instance.PlaygroundBlockWidth;
            if (n < 0) n = 0;
            if (n > _height) n = _height;
            if (m < 0) m = 0;
            if (m > _width) m = _width;
            float rowNumber = n + heightBlockNumber > _height ? _height : n + heightBlockNumber;
            float colNumber = m + widthBlocksNumber > _width ? _width : m + widthBlocksNumber;
            for (int i = n; i < rowNumber; i++)
            {
                for (int j = m; j < colNumber; j++)
                {
                    if (_blocks[i, j].Intersects(interactive))
                        _forIntersectionsBuffer.Add(_blocks[i, j]);
                }
            }
            return _forIntersectionsBuffer;
        }

        private void Replace(PlaygroundBlock oldBlock, PlaygroundBlock newBlock)
        {
            newBlock.Position = oldBlock.Position;
            _blocks[oldBlock.PositionOnPlayground.X, oldBlock.PositionOnPlayground.Y] = newBlock;
        }

        public void ReplaceWithPath(PlaygroundBlock oldBlock)
        {
            var pathBlock = new PathBlock(this, oldBlock.PositionOnPlayground);
            Replace(oldBlock, pathBlock);
            _path.Add(pathBlock);
        }

        public void ReplaceWithDeadPath(PlaygroundBlock oldBlock)
        {
            var deadPathBlock = new DeadPathBlock(this, oldBlock.PositionOnPlayground);
            Replace(oldBlock, deadPathBlock);
            _deadPath.Add(deadPathBlock);
        }

        public void ReplaceWithGround(PlaygroundBlock oldBlock)
        {
            if (!Game.Completed)
                Game.Scores++;
            oldBlock.Destroy();
            Replace(oldBlock, new GroundBlock(this, oldBlock.PositionOnPlayground));
        }

        public void ReplaceWithFixedGround(PlaygroundBlock oldBlock)
        {
            Replace(oldBlock, new FixedGroundBlock(this, oldBlock.PositionOnPlayground));
        }

        public void ReplaceWithWater(PlaygroundBlock oldBlock)
        {
            if (!Game.Completed)
                Game.Scores--;
            oldBlock.Destroy();
            Replace(oldBlock, new WaterBlock(this, oldBlock.PositionOnPlayground));
        }

        public void UpdateGround(bool success)
        {
            foreach (DeadPathBlock deadPathBlock in _deadPath)
                ReplaceWithWater(deadPathBlock);
            _deadPath.Clear();
            foreach (PathBlock pathBlock in _deathBlocksLeftQueue)
                _path.Add(pathBlock);
            foreach (PathBlock pathBlock in _deathBlocksRightQueue)
                _path.Add(pathBlock);
            _deathBlocksLeftQueue.Clear();
            _deathBlocksRightQueue.Clear();
            if (_path.Count != 0 && success)
            {
                List<IInteractive> enemies =
                    Game.GameObjectCollection.InteractiveObjects.Where(
                        interactive => interactive is IEnemy && ((IEnemy) interactive).CanWalkOnWater).ToList();
                PathBlock block = _path.First();
                InitWaveFrom(block, enemies);
                block = _path.Last();
                InitWaveFrom(block, enemies);
                block = _path[_path.Count/2];
                InitWaveFrom(block, enemies);
                foreach (PathBlock pathBlock in _path)
                    ReplaceWithGround(pathBlock);
            }
            else
            {
                foreach (PathBlock pathBlock in _path)
                    ReplaceWithWater(pathBlock);
            }
            _path.Clear();
            _deadPathInProgress = false;
            GroundBlocksNumber = Count(block => block is GroundBlock);
        }

        private void InitWaveFrom(PlaygroundBlock startBlock, List<IInteractive> enemies)
        {
            int row = startBlock.PositionOnPlayground.X;
            int col = startBlock.PositionOnPlayground.Y;
            for (int i = row - 1; i < (row + 2); i++)
            {
                for (int j = col - 1; j < (col + 2); j++)
                {
                    _forReplaceBuffer.Clear();
                    PlaygroundBlock nextBlock = _blocks[i, j];
                    if (nextBlock is WaterBlock)
                        if (StartWave(nextBlock, enemies))
                            foreach (PlaygroundBlock playgroundBlock in _forReplaceBuffer)
                                ReplaceWithGround(playgroundBlock);
                }
            }
        }

        private bool StartWave(PlaygroundBlock block, List<IInteractive> enemies)
        {
            int row = block.PositionOnPlayground.X;
            int col = block.PositionOnPlayground.Y;
            for (int i = row - 1; i <= (row + 1); i++)
            {
                for (int j = col - 1; j <= (col + 1); j++)
                {
                    PlaygroundBlock nextBlock = _blocks[i, j];
                    if ((nextBlock is WaterBlock) && !_forReplaceBuffer.Contains(nextBlock))
                    {
                        if (enemies.Any(interactive => interactive.Intersects(block)))
                            return false;
                        _forReplaceBuffer.Add(nextBlock);
                        if (!StartWave(nextBlock, enemies))
                            return false;
                    }
                }
            }
            return true;
        }

        /*
        public void Complete()
        {
            OnCompleted();
            List<IInteractive> enemies = Game.GameObjectCollection.InteractiveObjects.Where(
                interactive => interactive is IEnemy || interactive is IBonus).ToList();
            foreach (IInteractive interactive in enemies)
            {
                interactive.Kill();
            }
            for (int index00 = 0; index00 < _blocks.GetLength(0); index00++)
                for (int index01 = 0; index01 < _blocks.GetLength(1); index01++)
                {
                    PlaygroundBlock playgroundBlock = _blocks[index00, index01];
                    if (playgroundBlock is WaterBlock)
                        ReplaceWithGround(playgroundBlock);
                }
        }
        */
        public event EventHandler Completed;

        protected virtual void OnCompleted()
        {
            if (_completedEventRaised)
                return;
            _completedEventRaised = true;
            EventHandler handler = Completed;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
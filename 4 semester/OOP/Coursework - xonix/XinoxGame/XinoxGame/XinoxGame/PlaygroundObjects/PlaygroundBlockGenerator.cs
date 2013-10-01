using Microsoft.Xna.Framework;
using UtilLib;
using XonixGame.GameObjects;

namespace XonixGame.GameObjects
{
    internal class PlaygroundBlockGenerator
    {
        private readonly int _height;
        private readonly Playground _playground;
        private readonly int _width;

        public PlaygroundBlockGenerator(Playground playground, int height, int width)
        {
            Requires.NotNull(playground, "playground");
            Requires.Range(height > 0, "height");
            Requires.Range(width > 0, "width");

            _playground = playground;
            _height = height;
            _width = width;
        }

        public PlaygroundBlock[,] GenerateBlocks()
        {
            var blocks = new PlaygroundBlock[_height,_width];
            //генерируем границы
            for (int j = 0; j < _width; j++)
            {
                blocks[0, j] = new BorderBlock(_playground, new Point(0, j));
                blocks[_height - 1, j] = new BorderBlock(_playground, new Point(_height - 1, j));
            }
            for (int i = 0; i < _height; i++)
            {
                blocks[i, 0] = new BorderBlock(_playground, new Point(i, 0));
                blocks[i, _width - 1] = new BorderBlock(_playground, new Point(i, _width - 1));
            }

            for (int i = 1; i < (_height - 1); i++)
            {
                for (int j = 1; j < (_width - 1); j++)
                {
                    blocks[i, j] = new FixedGroundBlock(_playground, new Point(i, j));
                }
            }

            for (int i = 7; i < (_height - 7); i++)
            {
                for (int j = 7; j < (_width - 7); j++)
                {
                    blocks[i, j] = new WaterBlock(_playground, new Point(i, j));
                }
            }

            for (int i = 7; i < 14; i++)
            {
                for (int j = 7; j <= (20 - i%14); j++)
                {
                    blocks[i, j] = new GroundBlock(_playground, new Point(i, j));
                }
            }

            for (int i = 7; i < 14; i++)
            {
                for (int j = _width - 14 + (i - 7)%7; j <= _width - 7; j++)
                {
                    blocks[i, j] = new GroundBlock(_playground, new Point(i, j));
                }
            }

            for (int i = _height - 14; i <= (_height - 7); i++)
            {
                for (int j = 7; j <= (7 + 14 - (_height - i)); j++)
                {
                    blocks[i, j] = new GroundBlock(_playground, new Point(i, j));
                }
            }

            for (int i = _height - 14; i <= (_height - 7); i++)
            {
                for (int j = _width - 7; j >= (_width - 7 - (i - (_height - 14))); j--)
                {
                    blocks[i, j] = new GroundBlock(_playground, new Point(i, j));
                }
            }

            for (int i = _height/2 - 7; i < (_height/2); i++)
            {
                for (int j = _width/2; j < (_width/2 + i - (_height/2 - 7)); j++)
                {
                    blocks[i, j] = new GroundBlock(_playground, new Point(i, j));
                }
            }

            for (int i = _height/2 - 7; i < (_height/2); i++)
            {
                for (int j = _width/2; j > (_width/2 - i + (_height/2 - 7)); j--)
                {
                    blocks[i, j] = new GroundBlock(_playground, new Point(i, j));
                }
            }

            for (int i = _height/2; i < (_height/2 + 7); i++)
            {
                for (int j = _width/2; j < (_width/2 + 7 - (i - (_height/2))); j++)
                {
                    blocks[i, j] = new GroundBlock(_playground, new Point(i, j));
                }
            }

            for (int i = _height/2; i < (_height/2 + 7); i++)
            {
                for (int j = 1 + _width/2 - 7 + (i - _height/2); j < (_width/2); j++)
                {
                    blocks[i, j] = new GroundBlock(_playground, new Point(i, j));
                }
            }
            /*for (int i = _height / 2 - _height / 8; i < (_height / 2 + _height/8); i++)
            {
                for (int j = _width/2 - _width/8; j < (_width / 2 + _width / 8); j++)
                {
                    blocks[i, j] = new GroundBlock(_playground, new Point(i, j));
                }
            }*/
            /*
            for (int i = _height/4; i < 3*_height/4; i++)
            {
                for (int j = _width / 4; j < 3 * _width / 4; j++)
                {
                    blocks[i, j] = new GroundBlock(_playground, new Point(i, j));
                }
            }
            */
            /*for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    blocks[i, j] = new BorderBlock(_game) {Position = GetBlockPosition(i, j)};
                }
            }*/
            return blocks;
        }
    }
}
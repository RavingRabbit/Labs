using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Typing_Tutor
{
    [Serializable]
    public class Levels
    {
        private static Levels _instance;
        private readonly SortedList<int, Level> _levels;
        public const string DefaultSavingPath = "levels.dat";

        protected Levels()
        {
            _levels = new SortedList<int, Level>();
        }

        public static Levels GetInstance()
        {
            return _instance ?? (_instance = new Levels());
        }

        public int LastLevelNumber
        {
            get
            {
                return _levels.Any() ? _levels.Last().Key : 0;
            }
        }

        public List<Level> LevelList
        {
            get { return _levels.Select(pair => pair.Value).ToList(); }
        }

        public void Add(Level level)
        {
            if (level == null)
                throw new ArgumentNullException("level");
            if (_levels.ContainsValue(level))
                throw new Exception("This level is already added.");
            level.SetLevelNumber(LastLevelNumber + 1);
            _levels.Add(level.LevelNumber, level);
        }

        public Level Get(int levelNumber)
        {
            return _levels.ContainsKey(levelNumber) ? _levels[levelNumber] : null;
        }

        public void Remove(Level level)
        {
            if (level != null)
                _levels.Remove(level.LevelNumber);
        }

        public static void Serialize()
        {
            Serialize(DefaultSavingPath);
        }

        public static void Serialize(string path)
        {
            if (_instance == null) return;
            using (Stream fileStream = File.Create(path))
            {
                var br = new BinaryFormatter();
                br.Serialize(fileStream, _instance);
            }
        }

        public static void Deserialize()
        {
            Deserialize(DefaultSavingPath);
        }

        public static void Deserialize(string path)
        {
            using (Stream fileStream = File.OpenRead(path))
            {
                var br = new BinaryFormatter();
                _instance = (Levels)br.Deserialize(fileStream);
            }
        }

        public void Replace(Level oldLevel, Level newLevel)
        {
            newLevel.SetLevelNumber(oldLevel.LevelNumber);
            _levels[oldLevel.LevelNumber] = newLevel;
        }
    }
}

using System;

namespace AudioSystem
{
    class KeyGenerator : Singleton<KeyGenerator>
    {
        private int _qurrKey;

        public int GetKey()
        {
            return ++_qurrKey;
        }

        private KeyGenerator()
        {
        }
    }
}

using System;

namespace Patterns
{
    class KeyGenerator : Singleton<KeyGenerator>
    {
        private UInt64 _qurrKey;

        public UInt64 GetKey()
        {
            return ++_qurrKey;
        }

        private KeyGenerator()
        {
        }
    }
}

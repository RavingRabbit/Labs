using System.IO;
using System.Reflection;

namespace Test
{
    public static class StreamReaderExtension
    {
        public static int GetRealPosition(this StreamReader sr)
        {
            var charpos = (int) sr.GetType().InvokeMember("charPos",
                                                          BindingFlags.DeclaredOnly | BindingFlags.NonPublic |
                                                          BindingFlags.Instance | BindingFlags.GetField,
                                                          null, sr, null);
            return charpos;
        }
    }
}
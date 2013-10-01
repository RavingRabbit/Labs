using System;

namespace PluginInfoLib
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PluginInfoAttribute : Attribute
    {
        private readonly string _author;
        private readonly string _copyright;
        private readonly string _displayName;
        private readonly Version _version;
        private readonly Uri _websiteUri;

        public PluginInfoAttribute(string displayName, string author, string copyright, string version, string websiteUri)
        {
            if (version == null)
                throw new ArgumentNullException("version");
            if (websiteUri == null)
                throw new ArgumentNullException("websiteUri");
            _author = author;
            _copyright = copyright;
            _displayName = displayName;
            _version = Version.Parse(version);
            _websiteUri = new Uri(websiteUri);
        }

        public string Author
        {
            get { return _author; }
        }

        public string Copyright
        {
            get { return _copyright; }
        }

        public string DisplayName
        {
            get { return _displayName; }
        }

        public Version Version
        {
            get { return _version; }
        }

        public Uri WebsiteUri
        {
            get { return _websiteUri; }
        }
    }
}
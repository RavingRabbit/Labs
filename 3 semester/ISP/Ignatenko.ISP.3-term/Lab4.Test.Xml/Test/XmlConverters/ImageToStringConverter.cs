using System.Drawing;
using System.IO;

namespace Test.XmlConverters
{
    public class ImageToStringConverter : IStringConverter<Image>
    {
        private string _path = Path.Combine("save", "images");

        public string SaveImagesFolderPath
        {
            get
            {
                return _path;
            } 
            set
            {
                _path = value;
            }
        }

        public string ConvertTo(Image data)
        {
            var path = Path.Combine(_path, GetHashCodeFromImage(data) + ".bmp");
            data.Save(path);
            return path;
        }

        public Image ConvertFrom(string path)
        {
            return Image.FromFile(path);
        }

        private static int GetHashCodeFromImage(Image image)
        {
            using (var memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Gif);
                return GetHashCodeFromByteArray(memoryStream.ToArray());
            }
        }

        public static int GetHashCodeFromByteArray(byte[] data)
        {
            if (data == null)
            {
                return 0;
            }
            var i = data.Length;
            var hc = i + 1;
            while (--i >= 0)
            {
                hc *= 257;
                hc ^= data[i];
            }
            return hc;
        }
    }
}

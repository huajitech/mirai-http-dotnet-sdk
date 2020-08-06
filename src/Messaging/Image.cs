using System;

namespace HuajiTech.Mirai.Messaging
{
    public class Image : ImageBase
    {
        internal override string Type { get; } = "Image";

        public Image(string id) : base(id)
        {
        }

        public Image(Uri uri) : base(uri)
        {
        }

        public Image(string str, ImageSource source) : base(str, source)
        {
        }
    }
}
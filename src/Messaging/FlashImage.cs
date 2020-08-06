using System;

namespace HuajiTech.Mirai.Messaging
{
    public class FlashImage : ImageBase
    {
        internal override string Type { get; } = "FlashImage";

        public FlashImage(string id) : base(id)
        {
        }

        public FlashImage(Uri uri) : base(uri)
        {
        }

        public FlashImage(string str, ImageSource source) : base(str, source)
        {
        }
    }
}
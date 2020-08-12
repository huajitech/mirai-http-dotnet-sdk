using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HuajiTech.Mirai
{
    public class ChatNotFoundException : Exception
    {
        internal ChatNotFoundException(Type type, long number) : base(string.Format(Resources.ChatNotFound, type.Name, number))
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    /// <summary>
    /// 消息格式不正确时所引发的异常
    /// </summary>
    public class MessageFormatException : Exception
    {
        /// <summary>
        /// 创建 <see cref="MessageFormatException"/> 实例
        /// </summary>
        /// <param name="name">错误消息</param>
        internal MessageFormatException(string name) : base(string.Format(Resources.UnexpectedMessageFormat, name))
        {
        }
    }
}
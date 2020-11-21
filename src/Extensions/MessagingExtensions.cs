using HuajiTech.Mirai.Messaging;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace HuajiTech.Mirai
{
    /// <summary>
    /// 定义 <see cref="Messaging"/> 中的类型的扩展方法
    /// </summary>
    public static class MessagingExtensions
    {
        /// <summary>
        /// 以指定目标创建一个 <see cref="Messaging.Mention"/> 实例
        /// </summary>
        /// <param name="member">提及的目标</param>
        /// <returns>指定目标的 <see cref="Messaging.Mention"/> 实例</returns>
        public static Mention Mention(this Member member) => new(member);

        /// <summary>
        /// 以指定的目标和显示名称，创建一个 <see cref="Messaging.Mention"/> 实例
        /// </summary>
        /// <param name="member">提及的目标</param>
        /// <param name="displayName">提及的显示名称</param>
        /// <returns>指定的目标和显示名称的 <see cref="Messaging.Mention"/> 实例</returns>
        public static Mention Mention(this Member member, string displayName) => new(member, displayName);

        /// <summary>
        /// 以指定的消息，创建一个 <see cref="Messaging.Quote"/> 实例
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns>指定消息的 <see cref="Messaging.Quote"/> 实例</returns>
        public static Quote Quote(this Message message) => new(message);

        /// <summary>
        /// 转换字符串到 <see cref="PlainText"/> 实例
        /// </summary>
        /// <param name="str">将要转换的字符串</param>
        /// <returns>内容为指定字符串的 <see cref="PlainText"/> 实例</returns>
        public static PlainText ToPlainText(this string str) => new(str);

        /// <summary>
        /// 保存 <see cref="IMediaElement"/> 实例为指定目录文件
        /// </summary>
        /// <param name="mediaElement">指定 <see cref="IMediaElement"/> 实例</param>
        /// <param name="path">文件路径</param>
        public static async Task SaveTo(this IMediaElement mediaElement, string path)
        {
            var uri = mediaElement.Uri ?? throw new NotSupportedException();

            var client = new HttpClient();
            var bytes = await client.GetByteArrayAsync(uri);

            await File.WriteAllBytesAsync(path, bytes);
        }
    }
}
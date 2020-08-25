﻿using HuajiTech.Mirai.Messaging;

namespace HuajiTech.Mirai.Extensions
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
        public static Mention Mention(this Member member) => new Mention(member);

        /// <summary>
        /// 以指定的目标和显示名称，创建一个 <see cref="Messaging.Mention"/> 实例
        /// </summary>
        /// <param name="member">提及的目标</param>
        /// <param name="displayName">提及的显示名称</param>
        /// <returns>指定的目标和显示名称的 <see cref="Messaging.Mention"/> 实例</returns>
        public static Mention Mention(this Member member, string displayName) => new Mention(member, displayName);

        /// <summary>
        /// 转换字符串到 <see cref="PlainText"/> 实例
        /// </summary>
        /// <param name="str">将要转换的字符串</param>
        /// <returns>内容为指定字符串的 <see cref="PlainText"/> 实例</returns>
        public static PlainText ToPlainText(this string str) => new PlainText(str);
    }
}
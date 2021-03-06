﻿using HuajiTech.Mirai.Http.Interop;
using HuajiTech.Mirai.Http.Interop.Messaging;
using HuajiTech.Mirai.Http.Messaging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HuajiTech.Mirai.Http.Parsing
{
    /// <summary>
    /// 用作消息解析的基类
    /// </summary>
    internal abstract class MessageParser
    {
        protected CurrentUser CurrentUser { get; }

        /// <summary>
        /// 将 Json 消息元素解析为 <see cref="MessageElement"/> 的可重写方法扩展
        /// </summary>
        /// <param name="element">要解析的 Json 消息元素</param>
        /// <returns>解析 Json 消息元素后的 <see cref="MessageElement"/> 实例</returns>
        protected virtual MessageElement ParseExt(JObject element) => throw new InvalidMessageTypeException(element.Value<string>("type"));

        /// <summary>
        /// 将 Json 消息元素解析为 <see cref="MessageElement"/>
        /// </summary>
        /// <param name="element">要解析的 Json 消息元素</param>
        /// <returns>解析 Json 消息元素后的 <see cref="MessageElement"/> 实例</returns>
        public MessageElement Parse(JObject element) => element.Value<string>("type") switch
        {
            "Source" => ToSource(element),
            "App" => ToApp(element),
            "Face" => ToEmoticon(element),
            "FlashImage" => ToFlashImage(element),
            "Image" => ToImage(element),
            "Json" => ToJson(element),
            "AtAll" => ToMentionAll(),
            "Plain" => ToPlainText(element),
            "Poke" => ToPoke(element),
            "Voice" => ToVoice(element),
            "Xml" => ToXml(element),
            "At" => ToMention(element),
            _ => ParseExt(element)
        };

        /// <summary>
        /// 将多个 Json 消息元素解析为 <see cref="MessageElement"/>
        /// </summary>
        /// <param name="elements">要解析的多个 Json 消息元素</param>
        /// <returns>解析多个 Json 消息元素后的 <see cref="IEnumerable{MessageElement}"/> 实例</returns>
        public IEnumerable<MessageElement> ParseMore(JArray elements) => elements.Select(x => Parse((JObject)x));

        /// <summary>
        /// 根据消息来源获取 <see cref="MessageParser"/> 实例
        /// </summary>
        /// <param name="currentUser">创建 <see cref="MessageParser"/> 实例所使用的当前用户</param>
        /// <param name="data">Json 形式的消息数据</param>
        /// <returns></returns>
        public static MessageParser GetParser(CurrentUser currentUser, MessageData data) => data.Type switch
        {
            "FriendMessage" => new FriendMessageParser(currentUser),
            "GroupMessage" => new GroupMessageParser(currentUser),
            "TempMessage" => new MemberMessageParser(currentUser),
            _ => null
        };

        /// <summary>
        /// 从 Json 中提取信息，并创建 <see cref="Source"/> 实例
        /// </summary>
        /// <param name="element">以 Json 表达的来源</param>
        private static Source ToSource(JObject element) => element.ToObject<Source>();

        /// <summary>
        /// 从 Json 中提取信息，并创建 <see cref="App"/> 实例
        /// </summary>
        /// <param name="element">以 Json 表达的 App 消息</param>
        private static App ToApp(JObject element) => element.ToObject<App>();

        /// <summary>
        /// 从 Json 中提取信息，并创建 <see cref="Emoticon"/> 实例
        /// </summary>
        /// <param name="element">以 Json 表达的表情</param>
        private static Emoticon ToEmoticon(JObject element) => element.ToObject<FaceInfo>().ToEmoticon();

        /// <summary>
        /// 从 Json 中提取信息，并创建 <see cref="FlashImage"/> 实例
        /// </summary>
        /// <param name="element">以 Json 表达的闪图</param>
        private static FlashImage ToFlashImage(JObject element) => element.ToObject<ImageInfo>().ToFlashImage();

        /// <summary>
        /// 从 Json 中提取信息，并创建 <see cref="Image"/> 实例
        /// </summary>
        /// <param name="element">以 Json 表达的图片</param>
        private static Image ToImage(JObject element) => element.ToObject<ImageInfo>().ToImage();

        /// <summary>
        /// 从 Json 中提取信息，并创建 <see cref="Json"/> 实例
        /// </summary>
        /// <param name="element">以 Json 表达的 Json 消息</param>
        private static Json ToJson(JObject element) => element.ToObject<Json>();

        /// <summary>
        /// 从 Json 中提取信息，并创建 <see cref="MentionAll"/> 实例
        /// </summary>
        private static MentionAll ToMentionAll() => new MentionAll();

        /// <summary>
        /// 从 Json 中提取信息，并创建 <see cref="PlainText"/> 实例
        /// </summary>
        /// <param name="element">以 Json 表达的纯文本</param>
        private static PlainText ToPlainText(JObject element) => element.ToObject<PlainText>();

        /// <summary>
        /// 从 Json 中提取信息，并创建 <see cref="Poke"/> 实例
        /// </summary>
        /// <param name="element">以 Json 表达的戳一戳</param>
        private static Poke ToPoke(JObject element) => element.ToObject<PokeInfo>().ToPoke();

        /// <summary>
        /// 从 Json 中提取信息，并创建 <see cref="Voice"/> 实例
        /// </summary>
        /// <param name="element">以 Json 表达的语音</param>
        private static Voice ToVoice(JObject element) => element.ToObject<VoiceInfo>().ToVoice();

        /// <summary>
        /// 从 Json 中提取信息，并创建 <see cref="Xml"/> 实例
        /// </summary>
        /// <param name="element">以 Json 表达的 Xml 消息</param>
        private static Xml ToXml(JObject element) => element.ToObject<Xml>();

        /// <summary>
        /// 从 Json 中提取信息，并创建 <see cref="Mention"/> 实例
        /// </summary>
        /// <param name="element">以 Json 表达的提及</param>
        private Mention ToMention(JObject element) => new Mention(new User(CurrentUser.Session, element.Value<long>("target")), element.Value<string>("display").TrimStart('@'));

        /// <summary>
        /// 创建 <see cref="MessageParser"/> 实例
        /// </summary>
        /// <param name="currentUser">指定 <see cref="MessageParser"/> 实例所使用的当前用户</param>
        public MessageParser(CurrentUser currentUser) => CurrentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
    }
}
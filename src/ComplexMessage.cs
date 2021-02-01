using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HuajiTech.Mirai.Http
{
    /// <summary>
    /// 表示复合消息
    /// </summary>
    public sealed partial class ComplexMessage
    {
        private readonly List<MessageElement> Elements;

        /// <summary>
        /// 添加指定 <see cref="MessageElement"/> 实例至当前 <see cref="ComplexMessage"/> 实例的末尾
        /// </summary>
        /// <param name="value">指定 <see cref="MessageElement"/> 实例</param>
        /// <returns>已将指定 <see cref="MessageElement"/> 实例添加至末尾的 <see cref="ComplexMessage"/> 实例</returns>
        public void Add(MessageElement value) => Elements.Add(value);

        /// <summary>
        /// 添加指定 <see cref="IEnumerable"/> 实例的所有元素至当前 <see cref="ComplexMessage"/> 实例的末尾
        /// </summary>
        /// <param name="items">指定 <see cref="IEnumerable"/> 实例</param>
        /// <returns>已将指定 <see cref="IEnumerable"/> 实例的所有元素添加至末尾的 <see cref="ComplexMessage"/> 实例</returns>
        public void AddRange(IEnumerable<MessageElement> items) => Elements.AddRange(items);

        /// <summary>
        /// 插入指定 <see cref="MessageElement"/> 实例至当前 <see cref="ComplexMessage"/> 实例的指定位置
        /// </summary>
        /// <param name="index">指定插入位置</param>
        /// <param name="element">指定 <see cref="MessageElement"/> 实例</param>
        /// <returns>已将指定 <see cref="MessageElement"/> 实例插入至指定位置的 <see cref="ComplexMessage"/> 实例</returns>
        public void Insert(int index, MessageElement element) => Elements.Insert(index, element);

        /// <summary>
        /// 插入指定 <see cref="IEnumerable"/> 实例的所有元素至当前 <see cref="ComplexMessage"/> 实例的指定位置
        /// </summary>
        /// <param name="index">指定插入位置</param>
        /// <param name="items">指定 <see cref="IEnumerable"/> 实例</param>
        /// <returns>已将指定 <see cref="IEnumerable"/> 实例的所有元素插入至指定位置的 <see cref="ComplexMessage"/> 实例</returns>
        public void InsertRange(int index, IEnumerable<MessageElement> items) => Elements.InsertRange(index, items);

        /// <summary>
        /// 从当前 <see cref="ComplexMessage"/> 实例移除指定元素
        /// </summary>
        /// <param name="value">指定元素</param>
        /// <returns>已将指定元素移除的 <see cref="ComplexMessage"/> 实例</returns>
        public void Remove(MessageElement value) => Elements.Remove(value);

        /// <summary>
        /// 从当前 <see cref="ComplexMessage"/> 实例移除所有符合指定条件的元素
        /// </summary>
        /// <param name="match">指定条件</param>
        /// <returns>已将所有符合指定条件的元素实例移除的 <see cref="ComplexMessage"/> 实例</returns>
        public void RemoveAll(Predicate<MessageElement> match) => Elements.RemoveAll(match);

        /// <summary>
        /// 从当前 <see cref="ComplexMessage"/> 实例移除指定索引处的元素
        /// </summary>
        /// <param name="index">指定索引</param>
        /// <returns>已将指定索引处的元素移除的 <see cref="ComplexMessage"/> 实例</returns>
        public void RemoveAt(int index) => Elements.RemoveAt(index);

        /// <summary>
        /// 从当前 <see cref="ComplexMessage"/> 实例移除指定范围内所有元素
        /// </summary>
        /// <param name="index">指定索引</param>
        /// <param name="count">指定数量</param>
        /// <returns>已将移除指定范围内所有元素移除的 <see cref="ComplexMessage"/> 实例</returns>
        public void RemoveRange(int index, int count) => Elements.RemoveRange(index, count);

        /// <inheritdoc/>
        public override string ToString() => string.Join(string.Empty, this.Select(x => x.ToString()));

        /// <inheritdoc/>
        public static ComplexMessage operator +(ComplexMessage left, MessageElement right)
        {
            var complexMessage = new ComplexMessage(left) { right };
            return complexMessage;
        }

        /// <inheritdoc/>
        public static ComplexMessage operator +(MessageElement left, ComplexMessage right)
        {
            var complexMessage = new ComplexMessage(right);
            complexMessage.Insert(0, left);

            return complexMessage;
        }

        /// <inheritdoc/>
        public static ComplexMessage operator +(ComplexMessage left, ComplexMessage right)
        {
            var complexMessage = new ComplexMessage(left);
            complexMessage.AddRange(right);

            return complexMessage;
        }

        /// <summary>
        /// 创建 <see cref="ComplexMessage"/> 实例
        /// </summary>
        /// <param name="elements">指定 <see cref="ComplexMessage"/> 实例的元素</param>
        public ComplexMessage(IEnumerable<MessageElement> elements) => Elements = elements?.ToList();

        /// <summary>
        /// 创建 <see cref="ComplexMessage"/> 实例
        /// </summary>
        /// <param name="elements">指定 <see cref="ComplexMessage"/> 实例的元素</param>
        public ComplexMessage(params MessageElement[] elements) => Elements = elements?.ToList();
    }

    public partial class ComplexMessage : IList<MessageElement>, IReadOnlyList<MessageElement>
    {
        /// <inheritdoc/>
        public MessageElement this[int index] => Elements[index];

        /// <inheritdoc/>
        public int Count => Elements.Count;

        /// <inheritdoc/>
        public bool IsReadOnly { get; } = true;

        MessageElement IList<MessageElement>.this[int index] { get => Elements[index]; set => Elements[index] = value; }

        /// <inheritdoc/>
        public IEnumerator<MessageElement> GetEnumerator() => Elements.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Elements.GetEnumerator();

        /// <inheritdoc/>
        public int IndexOf(MessageElement item) => Elements.IndexOf(item);

        void IList<MessageElement>.Insert(int index, MessageElement item) => Elements.Insert(index, item);

        void IList<MessageElement>.RemoveAt(int index) => Elements.RemoveAt(index);

        void ICollection<MessageElement>.Add(MessageElement item) => Elements.Add(item);

        /// <inheritdoc/>
        public void Clear() => Elements.Clear();

        /// <inheritdoc/>
        public bool Contains(MessageElement item) => Elements.Contains(item);

        /// <inheritdoc/>
        public void CopyTo(MessageElement[] array, int arrayIndex) => Elements.CopyTo(array, arrayIndex);

        bool ICollection<MessageElement>.Remove(MessageElement item) => Elements.Remove(item);
    }
}
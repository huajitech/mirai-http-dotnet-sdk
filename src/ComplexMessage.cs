using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace HuajiTech.Mirai.Http
{
    /// <summary>
    /// 表示复合消息
    /// </summary>
    public sealed partial class ComplexMessage
    {
        private readonly ImmutableList<MessageElement> Elements;

        /// <summary>
        /// 添加指定 <see cref="MessageElement"/> 实例至当前 <see cref="ComplexMessage"/> 实例的末尾
        /// </summary>
        /// <param name="value">指定 <see cref="MessageElement"/> 实例</param>
        /// <returns>已将指定 <see cref="MessageElement"/> 实例添加至末尾的 <see cref="ComplexMessage"/> 实例</returns>
        public ComplexMessage Add(MessageElement value) => new(Elements.Add(value));

        /// <summary>
        /// 添加指定 <see cref="IEnumerable"/> 实例的所有元素至当前 <see cref="ComplexMessage"/> 实例的末尾
        /// </summary>
        /// <param name="items">指定 <see cref="IEnumerable"/> 实例</param>
        /// <returns>已将指定 <see cref="IEnumerable"/> 实例的所有元素添加至末尾的 <see cref="ComplexMessage"/> 实例</returns>
        public ComplexMessage AddRange(IEnumerable<MessageElement> items) => new(Elements.AddRange(items));

        /// <summary>
        /// 插入指定 <see cref="MessageElement"/> 实例至当前 <see cref="ComplexMessage"/> 实例的指定位置
        /// </summary>
        /// <param name="index">指定插入位置</param>
        /// <param name="element">指定 <see cref="MessageElement"/> 实例</param>
        /// <returns>已将指定 <see cref="MessageElement"/> 实例插入至指定位置的 <see cref="ComplexMessage"/> 实例</returns>
        public ComplexMessage Insert(int index, MessageElement element) => new(Elements.Insert(index, element));

        /// <summary>
        /// 插入指定 <see cref="IEnumerable"/> 实例的所有元素至当前 <see cref="ComplexMessage"/> 实例的指定位置
        /// </summary>
        /// <param name="index">指定插入位置</param>
        /// <param name="items">指定 <see cref="IEnumerable"/> 实例</param>
        /// <returns>已将指定 <see cref="IEnumerable"/> 实例的所有元素插入至指定位置的 <see cref="ComplexMessage"/> 实例</returns>
        public ComplexMessage InsertRange(int index, IEnumerable<MessageElement> items) => new(Elements.InsertRange(index, items));

        /// <summary>
        /// 从当前 <see cref="ComplexMessage"/> 实例移除指定元素
        /// </summary>
        /// <param name="value">指定元素</param>
        /// <returns>已将指定元素移除的 <see cref="ComplexMessage"/> 实例</returns>
        public ComplexMessage Remove(MessageElement value) => new(Elements.Remove(value));

        /// <summary>
        /// 从当前 <see cref="ComplexMessage"/> 实例移除所有符合指定条件的元素
        /// </summary>
        /// <param name="match">指定条件</param>
        /// <returns>已将所有符合指定条件的元素实例移除的 <see cref="ComplexMessage"/> 实例</returns>
        public ComplexMessage RemoveAll(Predicate<MessageElement> match) => new(Elements.RemoveAll(match));

        /// <summary>
        /// 从当前 <see cref="ComplexMessage"/> 实例移除指定索引处的元素
        /// </summary>
        /// <param name="index">指定索引</param>
        /// <returns>已将指定索引处的元素移除的 <see cref="ComplexMessage"/> 实例</returns>
        public ComplexMessage RemoveAt(int index) => new(Elements.RemoveAt(index));

        /// <summary>
        /// 从当前 <see cref="ComplexMessage"/> 实例移除指定集合内所包含所有元素
        /// </summary>
        /// <param name="items">指定集合</param>
        /// <returns>已将指定集合内所包含所有元素移除的 <see cref="ComplexMessage"/> 实例</returns>
        public ComplexMessage RemoveRange(IEnumerable<MessageElement> items) => new(Elements.RemoveRange(items));

        /// <summary>
        /// 从当前 <see cref="ComplexMessage"/> 实例移除指定范围内所有元素
        /// </summary>
        /// <param name="index">指定索引</param>
        /// <param name="count">指定数量</param>
        /// <returns>已将移除指定范围内所有元素移除的 <see cref="ComplexMessage"/> 实例</returns>
        public ComplexMessage RemoveRange(int index, int count) => new(Elements.RemoveRange(index, count));

        /// <summary>
        /// 替换当前 <see cref="ComplexMessage"/> 实例的指定元素至指定 <see cref="MessageElement"/> 实例
        /// </summary>
        /// <param name="oldValue">指定替换元素</param>
        /// <param name="newValue">指定 <see cref="MessageElement"/> 实例</param>
        /// <returns></returns>
        public ComplexMessage Replace(MessageElement oldValue, MessageElement newValue) => new(Elements.Replace(oldValue, newValue));

        /// <summary>
        /// 设置当前 <see cref="ComplexMessage"/> 实例的指定索引处元素为指定 <see cref="MessageElement"/> 实例
        /// </summary>
        /// <param name="index">指定索引</param>
        /// <param name="value">指定 <see cref="MessageElement"/> 实例</param>
        /// <returns></returns>
        public ComplexMessage SetItem(int index, MessageElement value) => new(Elements.SetItem(index, value));

        /// <summary>
        /// 创建 <see cref="ComplexMessage"/> 实例
        /// </summary>
        /// <param name="elements">指定 <see cref="ComplexMessage"/> 实例的元素</param>
        public static ComplexMessage Create(IEnumerable<MessageElement> elements) => new(elements.ToImmutableList());

        /// <summary>
        /// 创建 <see cref="ComplexMessage"/> 实例
        /// </summary>
        /// <param name="elements">指定 <see cref="ComplexMessage"/> 实例的元素</param>
        public static ComplexMessage Create(params MessageElement[] elements) => new(elements.ToImmutableList());

        /// <inheritdoc/>
        public override string ToString() => string.Join(string.Empty, this.Select(x => x.ToString()));

        /// <inheritdoc/>
        public static ComplexMessage operator +(ComplexMessage left, MessageElement right) => left.Add(right);

        /// <inheritdoc/>
        public static ComplexMessage operator +(MessageElement left, ComplexMessage right) => right.Insert(0, left);

        /// <inheritdoc/>
        public static ComplexMessage operator +(ComplexMessage left, ComplexMessage right) => left.AddRange(right);

        private ComplexMessage(ImmutableList<MessageElement> elements) => Elements = elements;
    }

    public partial class ComplexMessage : IImmutableList<MessageElement>, IList<MessageElement>, IReadOnlyList<MessageElement>
    {
        /// <inheritdoc/>
        public MessageElement this[int index] => Elements[index];

        /// <inheritdoc/>
        public int Count => Elements.Count;

        /// <inheritdoc/>
        public bool IsReadOnly { get; } = true;

        MessageElement IList<MessageElement>.this[int index] { get => Elements[index]; set => throw new NotSupportedException(); }

        IImmutableList<MessageElement> IImmutableList<MessageElement>.Add(MessageElement value) => Elements.Add(value);

        IImmutableList<MessageElement> IImmutableList<MessageElement>.AddRange(IEnumerable<MessageElement> items) => Elements.AddRange(items);

        IImmutableList<MessageElement> IImmutableList<MessageElement>.Clear() => Elements.Clear();

        /// <inheritdoc/>
        public IEnumerator<MessageElement> GetEnumerator() => Elements.GetEnumerator();

        /// <inheritdoc/>
        public int IndexOf(MessageElement item, int index, int count, IEqualityComparer<MessageElement> equalityComparer) => Elements.IndexOf(item, index, count, equalityComparer);

        IImmutableList<MessageElement> IImmutableList<MessageElement>.InsertRange(int index, IEnumerable<MessageElement> items) => Elements.InsertRange(index, items);

        IImmutableList<MessageElement> IImmutableList<MessageElement>.Insert(int index, MessageElement element) => Elements.Insert(index, element);

        IImmutableList<MessageElement> IImmutableList<MessageElement>.Remove(MessageElement value, IEqualityComparer<MessageElement> equalityComparer) => Elements.Remove(value, equalityComparer);

        /// <inheritdoc/>
        public int LastIndexOf(MessageElement item, int index, int count, IEqualityComparer<MessageElement> equalityComparer) => Elements.LastIndexOf(item, index, count, equalityComparer);

        IImmutableList<MessageElement> IImmutableList<MessageElement>.RemoveAll(Predicate<MessageElement> match) => Elements.RemoveAll(match);

        IImmutableList<MessageElement> IImmutableList<MessageElement>.RemoveAt(int index) => Elements.RemoveAt(index);

        IImmutableList<MessageElement> IImmutableList<MessageElement>.RemoveRange(IEnumerable<MessageElement> items, IEqualityComparer<MessageElement> equalityComparer) => Elements.RemoveRange(items, equalityComparer);

        IImmutableList<MessageElement> IImmutableList<MessageElement>.RemoveRange(int index, int count) => Elements.RemoveRange(index, count);

        IImmutableList<MessageElement> IImmutableList<MessageElement>.Replace(MessageElement oldValue, MessageElement newValue, IEqualityComparer<MessageElement> equalityComparer) => Elements.Replace(oldValue, newValue, equalityComparer);

        IImmutableList<MessageElement> IImmutableList<MessageElement>.SetItem(int index, MessageElement value) => Elements.SetItem(index, value);

        IEnumerator IEnumerable.GetEnumerator() => Elements.GetEnumerator();

        /// <inheritdoc/>
        public int IndexOf(MessageElement item) => Elements.IndexOf(item);

        void IList<MessageElement>.Insert(int index, MessageElement item) => throw new NotSupportedException();

        void IList<MessageElement>.RemoveAt(int index) => throw new NotSupportedException();

        void ICollection<MessageElement>.Add(MessageElement item) => throw new NotSupportedException();

        /// <inheritdoc/>
        public void Clear() => throw new NotSupportedException();

        /// <inheritdoc/>
        public bool Contains(MessageElement item) => Elements.Contains(item);

        /// <inheritdoc/>
        public void CopyTo(MessageElement[] array, int arrayIndex) => Elements.CopyTo(array, arrayIndex);

        bool ICollection<MessageElement>.Remove(MessageElement item) => throw new NotSupportedException();
    }
}
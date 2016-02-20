﻿// Enums.NET
// Copyright 2016 Tyler Brinkley. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace EnumsNET
{
    /// <summary>
    /// Class that provides efficient defined enum member operations
    /// </summary>
    public abstract class EnumMemberInfo : IEnumMemberInfo, IComparable<EnumMemberInfo>
    {
        internal readonly IEnumMemberInfo _info;

        /// <summary>
        /// The defined enum member's value
        /// </summary>
        public object Value => GetValue();

        /// <summary>
        /// The defined enum member's name
        /// </summary>
        public string Name => _info.Name;

        /// <summary>
        /// The defined enum member's attributes
        /// </summary>
        public Attribute[] Attributes => _info.Attributes;

        /// <summary>
        /// The defined enum member's <see cref="DescriptionAttribute.Description"/> if applied else null.
        /// </summary>
        public string Description => _info.Description;

        /// <summary>
        /// The defined enum member's underlying integer value
        /// </summary>
        public object UnderlyingValue => _info.UnderlyingValue;

        /// <summary>
        /// Specifies if the given EnumMemberInfo is defined, the only time it may not be defined is within
        /// a custom enum formatter
        /// </summary>
        public bool IsDefined => _info.IsDefined;

        internal EnumMemberInfo(IEnumMemberInfo info)
        {
            _info = info;
        }

        /// <summary>
        /// Retrieves the <see cref="Description"/> if not null else the <see cref="Name"/>.
        /// </summary>
        /// <returns></returns>
        public string GetDescriptionOrName() => _info.GetDescriptionOrName();

        /// <summary>
        /// Retrieves the <see cref="Description"/> if not null else the <see cref="Name"/> that's been formatted with <paramref name="nameFormatter"/>.
        /// </summary>
        /// <param name="nameFormatter"></param>
        /// <returns></returns>
        public string GetDescriptionOrName(Func<string, string> nameFormatter) => _info.GetDescriptionOrName(nameFormatter);

        public override string ToString() => _info.ToString();

        public string ToString(string format) => _info.ToString(format);

        public string ToString(params EnumFormat[] formats) => _info.ToString(formats);

        public string AsString() => _info.AsString();

        public string AsString(string format) => _info.AsString(format);

        public string AsString(params EnumFormat[] formats) => _info.AsString(formats);

        public string Format(string format) => _info.Format(format);

        public string Format(EnumFormat format) => _info.Format(format);

        public string Format(EnumFormat format0, EnumFormat format1) => _info.Format(format0, format1);

        public string Format(EnumFormat format0, EnumFormat format1, EnumFormat format2) => _info.Format(format0, format1, format2);

        public string Format(EnumFormat format0, EnumFormat format1, EnumFormat format2, EnumFormat format3) => _info.Format(format0, format1, format2, format3);

        public string Format(EnumFormat format0, EnumFormat format1, EnumFormat format2, EnumFormat format3, EnumFormat format4) => _info.Format(format0, format1, format2, format3, format4);

        public string Format(params EnumFormat[] formats) => _info.Format(formats);

        /// <summary>
        /// Indicates if <see cref="Attributes"/> contains a <typeparamref name="TAttribute"/>.
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns>Indication if <see cref="Attributes"/> contains a <typeparamref name="TAttribute"/>.</returns>
        public bool HasAttribute<TAttribute>() where TAttribute : Attribute => _info.HasAttribute<TAttribute>();

        /// <summary>
        /// Retrieves the first <typeparamref name="TAttribute"/> in <see cref="Attributes"/> if defined else null.
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public TAttribute GetAttribute<TAttribute>() where TAttribute : Attribute => _info.GetAttribute<TAttribute>();

        /// <summary>
        /// Retrieves the first <typeparamref name="TAttribute"/> in <see cref="Attributes"/> if defined and returns a <typeparamref name="TResult"/>
        /// using the <paramref name="selector"/> else returns <paramref name="defaultValue"/>.
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="selector"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="selector"/> is null.</exception>
        public TResult GetAttributeSelect<TAttribute, TResult>(Func<TAttribute, TResult> selector, TResult defaultValue = default(TResult)) where TAttribute : Attribute => _info.GetAttributeSelect(selector, defaultValue);

        /// <summary>
        /// Tries to retrieve the first <typeparamref name="TAttribute"/> in <see cref="Attributes"/> if defined and sets <paramref name="result"/>
        /// to applying the <paramref name="selector"/> to the <typeparamref name="TAttribute"/>. Returns true if a <typeparamref name="TAttribute"/>
        /// is found else false.
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="selector"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="selector"/> is null.</exception>
        public bool TryGetAttributeSelect<TAttribute, TResult>(Func<TAttribute, TResult> selector, out TResult result) where TAttribute : Attribute => _info.TryGetAttributeSelect(selector, out result);

        /// <summary>
        /// Retrieves all <typeparamref name="TAttribute"/>'s in <see cref="Attributes"/>.
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public IEnumerable<TAttribute> GetAttributes<TAttribute>() where TAttribute : Attribute => _info.GetAttributes<TAttribute>();

        [CLSCompliant(false)]
        public sbyte ToSByte() => _info.ToSByte();

        public byte ToByte() => _info.ToByte();

        public short ToInt16() => _info.ToInt16();

        [CLSCompliant(false)]
        public ushort ToUInt16() => _info.ToUInt16();

        public int ToInt32() => _info.ToInt32();

        [CLSCompliant(false)]
        public uint ToUInt32() => _info.ToUInt32();

        public long ToInt64() => _info.ToInt64();
        
        [CLSCompliant(false)]
        public ulong ToUInt64() => _info.ToUInt64();

        internal abstract object GetValue();

        #region Explicit Interface Implementation
        string IFormattable.ToString(string format, IFormatProvider formatProvider) => _info.ToString(format, formatProvider);

        TypeCode IConvertible.GetTypeCode() => _info.GetTypeCode();

        bool IConvertible.ToBoolean(IFormatProvider provider) => _info.ToBoolean(provider);

        char IConvertible.ToChar(IFormatProvider provider) => _info.ToChar(provider);

        sbyte IConvertible.ToSByte(IFormatProvider provider) => _info.ToSByte(provider);

        byte IConvertible.ToByte(IFormatProvider provider) => _info.ToByte(provider);

        short IConvertible.ToInt16(IFormatProvider provider) => _info.ToInt16(provider);

        ushort IConvertible.ToUInt16(IFormatProvider provider) => _info.ToUInt16(provider);

        int IConvertible.ToInt32(IFormatProvider provider) => _info.ToInt32(provider);

        uint IConvertible.ToUInt32(IFormatProvider provider) => _info.ToUInt32(provider);

        long IConvertible.ToInt64(IFormatProvider provider) => _info.ToInt64(provider);

        ulong IConvertible.ToUInt64(IFormatProvider provider) => _info.ToUInt64(provider);

        float IConvertible.ToSingle(IFormatProvider provider) => _info.ToSingle(provider);

        double IConvertible.ToDouble(IFormatProvider provider) => _info.ToDouble(provider);

        decimal IConvertible.ToDecimal(IFormatProvider provider) => _info.ToDecimal(provider);

        DateTime IConvertible.ToDateTime(IFormatProvider provider) => _info.ToDateTime(provider);

        string IConvertible.ToString(IFormatProvider provider) => _info.ToString(provider);

        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => _info.ToType(conversionType, provider);

        int IComparable.CompareTo(object obj) => _info.CompareTo(obj);

        int IComparable<EnumMemberInfo>.CompareTo(EnumMemberInfo other) => _info.CompareTo(other);
        #endregion
    }

    /// <summary>
    /// Class that provides efficient defined enum member operations
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    public sealed class EnumMemberInfo<TEnum> : EnumMemberInfo, IComparable<EnumMemberInfo<TEnum>>
    {
        /// <summary>
        /// The defined enum member's value
        /// </summary>
        public new TEnum Value
        {
            get
            {
                var toEnum = Enums<TEnum>.ToEnum;
                switch (Enums<TEnum>.TypeCode)
                {
                    case TypeCode.Int32:
                        return ((Func<int, TEnum>)toEnum)(((InternalEnumMemberInfo<int>)_info).Value);
                    case TypeCode.UInt32:
                        return ((Func<uint, TEnum>)toEnum)(((InternalEnumMemberInfo<uint>)_info).Value);
                    case TypeCode.Int64:
                        return ((Func<long, TEnum>)toEnum)(((InternalEnumMemberInfo<long>)_info).Value);
                    case TypeCode.UInt64:
                        return ((Func<ulong, TEnum>)toEnum)(((InternalEnumMemberInfo<ulong>)_info).Value);
                    case TypeCode.SByte:
                        return ((Func<sbyte, TEnum>)toEnum)(((InternalEnumMemberInfo<sbyte>)_info).Value);
                    case TypeCode.Byte:
                        return ((Func<byte, TEnum>)toEnum)(((InternalEnumMemberInfo<byte>)_info).Value);
                    case TypeCode.Int16:
                        return ((Func<short, TEnum>)toEnum)(((InternalEnumMemberInfo<short>)_info).Value);
                    case TypeCode.UInt16:
                        return ((Func<ushort, TEnum>)toEnum)(((InternalEnumMemberInfo<ushort>)_info).Value);
                }
                Debug.Fail("Unknown Enum TypeCode");
                return default(TEnum);
            }
        }

        internal EnumMemberInfo(IEnumMemberInfo info)
            : base(info)
        {
        }

        internal override object GetValue() => Value;

        #region Explicit Interface Implementation
        int IComparable<EnumMemberInfo<TEnum>>.CompareTo(EnumMemberInfo<TEnum> other) => _info.CompareTo(other);
        #endregion
    }
}

using FluentSql.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FluentSql.Models
{
    public enum DataType
    {
        [CommandFragment("INTEGER")]
        Integer,

        [CommandFragment("VARCHAR")]
        Text
    }

    internal static class DataTypeExtensions
    {
        private static readonly Type Type = typeof(DataType);
        private static readonly IDictionary<DataType, string> FragmentLookup = new Dictionary<DataType, string>();

        static DataTypeExtensions()
        {
            foreach (DataType dataType in Enum.GetValues(Type))
            {
                FragmentLookup.Add(dataType, GetCommandFragementAttribute(dataType).Fragment);
            }
        }

        internal static string GetCommandFragment(this DataType dataType)
            => FragmentLookup[dataType];

        private static CommandFragmentAttribute GetCommandFragementAttribute(DataType dataType)
        {
            MemberInfo[] memberInfos = Type.GetMember(dataType.ToString());
            MemberInfo memberInfo = memberInfos.First(m => m.DeclaringType == Type);
            return memberInfo.GetCustomAttribute<CommandFragmentAttribute>(false) as CommandFragmentAttribute;
        }
    }
}
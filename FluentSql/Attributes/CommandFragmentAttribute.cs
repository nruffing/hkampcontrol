using System;

namespace FluentSql.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    internal sealed class CommandFragmentAttribute : Attribute
    {
        public CommandFragmentAttribute(string fragement)
            => this.Fragment = fragement;

        public string Fragment { get; }
    }
}
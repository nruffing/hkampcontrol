using FluentSql.Extensions;
using System;
using System.Text;

namespace FluentSql.Commands
{
    public sealed class Select : ISelect
    {
        private const string Template = "SELECT {0} FROM {1}";
        private const string AllFragment = "*";
        private const string ColumnSeparator = ", ";

        private bool _isAll;
        private string[] _columnNames;
        private string _fromTableName;

        internal Select()
        {
        }

        public ISelect All()
        {
            this._isAll = true;
            return this;
        }

        public ISelect Columns(params string[] columnNames)
        {
            this._columnNames = columnNames;
            return this;
        }

        public ISelect From(string tableName)
        {
            this._fromTableName = tableName;
            return this;
        }

        public string End()
        {
            this.Validate();

            StringBuilder sb = new StringBuilder();
            if (this._isAll)
            {
                sb.Append(AllFragment);
            }
            else
            {
                for (int i = 0; i < this._columnNames.Length; i++)
                {
                    sb.Append(this._columnNames[i]);
                    if (i < this._columnNames.Length - 1)
                    {
                        sb.Append(ColumnSeparator);
                    }
                }
            }

            return string.Format(
                Template,
                sb.ToString(),
                this._fromTableName);
        }

        private void Validate()
        {
            if (this._isAll == false && this._columnNames.IsNullOrEmptyOrContainsNullOrWhiteSpace())
            {
                throw new InvalidOperationException("Select statement must specify at least one column or the all qualifier.");
            }

            if (string.IsNullOrWhiteSpace(this._fromTableName))
            {
                throw new InvalidOperationException("Select statement must have a from table specified.");
            }
        }
    }
}
using System;

namespace FluentSql.Models
{
    public sealed class Column<TCommand> : IColumn<TCommand>
    {
        private const string Template = "{0} {1}{2}{3}";
        private const string PrimaryKeyFragemnt = " PRIMARY KEY";
        private const string NullableFragment = " NULL";

        private TCommand _command;

        private string _name;
        private DataType _dataType;
        private bool _isPrimaryKey;
        private bool _isNullable;

        internal Column(TCommand command, string name, DataType dataType)
        {
            this._command = command;
            this._name = name;
            this._dataType = dataType;
        }

        public IColumn<TCommand> AsPrimaryKey()
        {
            this._isPrimaryKey = true;
            return this;
        }

        public IColumn<TCommand> IsNullable()
        {
            this._isNullable = true;
            return this;
        }

        public TCommand EndColumn()
            => _command;

        public string GetCommandFragment()
            => string.Format(
                Template,
                this._name,
                this._dataType.GetCommandFragment(),
                this._isPrimaryKey ? PrimaryKeyFragemnt : string.Empty,
                this._isNullable ? NullableFragment : string.Empty);

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(this._name))
            {
                throw new InvalidOperationException("Column name is invalid.");
            }

            if (this._isPrimaryKey && this._isNullable)
            {
                throw new InvalidOperationException("A column cannot be both nullable and a primary key.");
            }
        }
    }
}
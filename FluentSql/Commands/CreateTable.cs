using FluentSql.Models;
using System.Collections.Generic;
using System.Text;
using FluentSql.Extensions;
using System;

namespace FluentSql.Commands
{
    public sealed class CreateTable : ICreateTable
    {
        private const string Template = "CREATE TABLE {0}{1} ({2})";
        private const string IfNotExistsFragment = "IF NOT EXISTS ";
        private const string ColumnSeparator = ", ";

        private string _name;
        private bool _ifNotExists;
        private IList<IColumn<ICreateTable>> _columns = new List<IColumn<ICreateTable>>();

        internal CreateTable(string name)
            => this._name = name;

        public ICreateTable IfNotExists()
        {
            this._ifNotExists = true;
            return this;
        }

        public IColumn<ICreateTable> WithColumn(string name, DataType dataType)
        {
            Column<ICreateTable> column = new Column<ICreateTable>(this, name, dataType);
            this._columns.Add(column);
            return column;
        }

        public string End()
        {
            this.Validate();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this._columns.Count; i++)
            {
                sb.Append(this._columns[i].GetCommandFragment());
                if (i < this._columns.Count - 1)
                {
                    sb.Append(ColumnSeparator);
                }
            }

            return string.Format(
                Template,
                this._ifNotExists ? IfNotExistsFragment : string.Empty,
                this._name,
                sb.ToString());
        }

        private void Validate()
        {
            if (_columns.IsEmpty())
            {
                throw new InvalidOperationException("At least one column is required to create a table.");
            }

            foreach (IColumn<ICreateTable> column in this._columns)
            {
                column.Validate();
            }
        }
    }
}
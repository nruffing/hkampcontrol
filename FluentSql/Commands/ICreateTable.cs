using FluentSql.Models;

namespace FluentSql.Commands
{
    public interface ICreateTable : ICommand
    {
        ICreateTable IfNotExists();

        IColumn<ICreateTable> WithColumn(string name, DataType dataType);
    }
}
namespace FluentSql.Commands
{
    public interface ISelect : ICommand
    {
        ISelect All();

        ISelect Columns(params string[] columnNames);

        ISelect From(string tableName);
    }
}
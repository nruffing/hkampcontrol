namespace FluentSql.Models
{
    public interface IColumn<TCommand>
    {
        IColumn<TCommand> AsPrimaryKey();

        IColumn<TCommand> IsNullable();

        TCommand EndColumn();

        string GetCommandFragment();
    }
}
using FluentSql.Commands;

namespace FluentSql
{
    public static class FluentSql
    {
        public static ICreateTable CreateTable(string name)
            => new CreateTable(name);
    }
}
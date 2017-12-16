using System;
namespace CadmusDND
{
    public interface IDatabaseConnection
{
  SQLite.SQLiteConnection DbConnection();
}
}

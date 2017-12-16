using SQLite;
using CadmusDND.Droid;
using System.IO;
[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]
namespace CadmusDND.Droid
{
	public class DatabaseConnection_Android : IDatabaseConnection
	{
		public SQLiteConnection DbConnection()
		{
			var dbName = "GameDb.db3";
			var path = Path.Combine(System.Environment.
			  GetFolderPath(System.Environment.
			  SpecialFolder.Personal), dbName);
			return new SQLiteConnection(path);
		}
	}
}

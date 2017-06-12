using System.IO;
using HeroChatClient.DBRepository;
using HeroChatClient.Droid.SQLIteDB;
using Xamarin.Forms;
using Environment = System.Environment;

[assembly: Dependency(typeof(SQLiteAndroid))]
namespace HeroChatClient.Droid.SQLIteDB
{
    class SQLiteAndroid : ISQLiteDB
    {
        public SQLiteAndroid()
        {
                
        }
        public string GetDatabasePath(string sqliteFilename)
        {
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(folderPath, sqliteFilename);
            return path;
        }
    }
}
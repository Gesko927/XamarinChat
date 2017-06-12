namespace HeroChatClient.DBRepository
{
    public interface ISQLiteDB
    {
        string GetDatabasePath(string sqliteFilename);
    }
}
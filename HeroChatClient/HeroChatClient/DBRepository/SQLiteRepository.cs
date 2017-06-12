using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HeroChatClient.Models;
using SQLite;
using Xamarin.Forms;

namespace HeroChatClient.DBRepository
{
    public class SQLiteRepository
    {
        #region Private Fileds
        private readonly SQLiteConnection _database;
        #endregion

        public SQLiteRepository(string filename)
        {
            var databasePath = DependencyService.Get<ISQLiteDB>().GetDatabasePath(filename);
            _database = new SQLiteConnection(databasePath);
            _database.CreateTable<User>();
        }

        public int DeleteUser(int id)
        {
            return _database.Delete<User>(id);
        }
        public int SaveOrUpdateUser(User user)
        {
            if (user.Id != 0)
            {
                _database.Update(user);
                return user.Id;
            }
            else
            {
                return _database.Insert(user);
            }
        }

        #region GetUser Methods
        public IEnumerable<User> GetUsers()
        {
            return (from user in _database.Table<User>() select user).ToList();
        }
        public User GetUserById(int id)
        {
            return _database.Get<User>(id);
        }
        public User GetUserByUsername(string username)
        {
            try
            {
                var user = _database.Get<User>(u => u.Username == username);
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public User GetUserByEmail(string email)
        {
            try
            {
                var user = _database.Get<User>(u => u.Email == email);
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

    }
}

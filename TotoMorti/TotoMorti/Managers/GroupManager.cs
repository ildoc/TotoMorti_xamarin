using System.Collections.Generic;
using System.Linq;
using SQLite;
using TotoMorti.Classes;
using TotoMorti.Interfaces;

namespace TotoMorti.Managers
{
    public class GroupManager
    {
        private readonly SQLiteConnection _connection;

        public GroupManager(ISQLiteDb sqLiteDb)
        {
            _connection = sqLiteDb.GetConnection();
            _connection.CreateTable<Group>();
        }

        public List<Group> GetAllGroups()
        {
            return _connection.Table<Group>().ToList();
        }

        public void AddGroup(Group g)
        {
            _connection.Insert(g);
        }

        public void DeleteGroup(Group g)
        {
            _connection.Delete(g);
        }

        public void UpdateGroup(Group g)
        {
            _connection.Update(g);
        }

        public Group FindGroupByName(string groupName)
        {
            return _connection.Table<Group>().FirstOrDefault(g => g.Title == groupName);
        }
    }
}
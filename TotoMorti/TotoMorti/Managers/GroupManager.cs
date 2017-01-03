using System;
using System.Collections.Generic;
using TotoMorti.Classes;
using TotoMorti.Interfaces;

namespace TotoMorti.Managers
{
    public class GroupManager
    {
        //private readonly SQLiteConnection _connection;

        public GroupManager(ISQLiteDb sqLiteDb)
        {
            //_connection = sqLiteDb.GetConnection();
            //_connection.CreateTable<Group>();
        }

        public List<Group> GetAllGroups()
        {
            throw new NotImplementedException();
        }

        public void AddGroup(Group g)
        {
            //_connection.Insert(g);
        }

        public void DeleteGroup(Group g)
        {
            //_connection.Delete(g);
        }

        public void UpdateGroup(Group g)
        {
            //_connection.Update(g);
        }

        public Group FindGroupByName(string groupName)
        {
            throw new NotImplementedException();
            // return _connection.Table<Group>().FirstOrDefault(g => g.Title == groupName);
        }
    }
}

using System.Collections.Generic;
namespace MeetingApp.Models
{
    public static class Repository
    {
        private static List<UserInfo> _users = new();
        public static List<UserInfo> Users
        {
            get
            {
                return _users;
            }
        }
        public static void CreateUser(UserInfo user)
        {
            user.Id = Users.Count + 1;//id ataması yaparız
            _users.Add(user);
        }
        public static UserInfo? GetById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }
    }
}
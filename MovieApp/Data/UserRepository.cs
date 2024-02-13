using MovieApp.Models;

namespace MovieApp.Data
{
    public static class UserRepository
    {
        private static List<User> _users = null;
        static UserRepository()
        {
            _users = new List<User>(){
new User(){Id=1,Name="Muhammed Yasin Özdemir",UserName="kkyyasin",Passaword="12345"}
        };
        }
        public static List<User> Users
        {
            get { return _users; }
        }
        public static void AddUser(User user)
        {
            _users.Add(user);
        }
        public static User GetUser(String UserName, String Passaword)
        {
            return _users.FirstOrDefault(a => a.UserName == UserName && a.Passaword == Passaword);
        }
    }
}
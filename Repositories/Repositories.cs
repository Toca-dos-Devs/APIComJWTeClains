
using System.Collections.Generic;
using System.Linq;
using APIComJWTeClains.Models;

namespace APIComJWTeClains.Repositories
{

    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>
            {
                new User { Id = 1, Username = "marcos", Password = "marcos", Role = "gerente" },
                new User { Id = 2, Username = "ricardo", Password = "ricardo", Role = "funcionario" }
            };
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    internal class UserCollection
    {
        public List<User> Users { get; set; } = new List<User>();

        public UserCollection Add(User user)
        {
            Users.Add(user);
            return this;
        }

        public User Find(string name)
        {
            return Users.Find(item => item.Name == name);
        }

        public void Show()
        {
            foreach (var user in Users)
            {
                Console.WriteLine(user);
            }
        }
    }
}

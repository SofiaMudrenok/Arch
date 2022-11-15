using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    internal class SubscriptionManager
    {
        public UserCollection users = new UserCollection()
            .Add(new User("Anna", "Anna@gmail.com").ActivateSubscription())
            .Add(new User("Olya", "Olya@gmail.com").ActivateSubscription())
            .Add(new User("Sonya", "Sonya@gmail.com"));

        public void Show()
        {
            users.Show();
        }
        public void ActivateSubscription(string name)
        {
            users.Find(name).ActivateSubscription();
        }

        public void DeActivateSubscription(string name)
        {
            users.Find(name).DeActivateSubscription();
        }
    }
}

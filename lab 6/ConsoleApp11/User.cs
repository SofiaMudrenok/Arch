using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    internal class User
    {
        public string Name { get; set; }
        public string Mail { get; set; }

        private string subscription { get; set; } = "unsubscribed";

        public User(string name, string mail)
        {
            Name = name;
            Mail = mail;
        }

        public User ActivateSubscription()
        {
            if (subscription == "unsubscribed")
            {
                subscription = "subscribed";
                Console.WriteLine($"{Name} Sucessfully subscribed");
            }
            else
            {
                Console.WriteLine($"{Name} Already subscribed");
            }
            return this;
        }
        public User DeActivateSubscription()
        {
            if (subscription == "subscribed")
            {
                subscription = "unsubscribed";
                Console.WriteLine($"{Name} Sucessfully unsubscribed");
            }
            else
            {
                Console.WriteLine($"{Name} Already unsubscribed");
            }
            return this;
        }

        public override string ToString()
        {
            return $"User {Name} with {Mail} address. Status: { subscription }.";
        }
    }
}

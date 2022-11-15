using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SubscriptionManager app = new SubscriptionManager();
            app.Show();
            app.ActivateSubscription("Anna");
            app.DeActivateSubscription("Anna");
            app.ActivateSubscription("Anna");
        }
    }
}

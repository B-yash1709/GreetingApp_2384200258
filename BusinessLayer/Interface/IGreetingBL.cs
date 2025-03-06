using ModelLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IGreetingBL
    {
        string GetGreetingMessage(UserModel userModel);
        public string PrintHelloWorld();
        public GreetingEntity SaveGreeting(string message);

        public GreetingEntity GetGreetingById(int id);
        public List<GreetingEntity> GetAllGreetings();
        GreetingEntity UpdateGreeting(int id, string newMessage);
        bool DeleteGreeting(int id);
    }
}

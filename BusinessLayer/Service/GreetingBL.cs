﻿using BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Interface;
using ModelLayer.Model;
namespace BusinessLayer.Service
{
    public class GreetingBL : IGreetingBL
    {
        IGreetingRL _greetingRL;

        public GreetingBL(IGreetingRL greetingRL)
        {
            _greetingRL = greetingRL;
        }

        public string PrintHelloWorld()
        {
            string result = _greetingRL.PrintHelloWorld();

            return result;
        }
       public string GetGreetingMessage(UserModel user)
        {
            return _greetingRL.PrintHelloWorldWithName(user);
        }
        public GreetingEntity SaveGreeting(string message)
        {
            return _greetingRL.SaveGreeting(message);
        }

        public GreetingEntity GetGreetingById(int id)
        {
            return _greetingRL.GetGreetingById(id);
        }
        public List<GreetingEntity> GetAllGreetings()
        {
            return _greetingRL.GetAllGreetings();
        }

        public GreetingEntity UpdateGreeting(int id, string newMessage)
        {
            return _greetingRL.UpdateGreeting(id, newMessage);
        }
       

    }
}

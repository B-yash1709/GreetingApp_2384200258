using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Interface;
using ModelLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;

namespace RepositoryLayer.Service
{
    public class GreetingRL : IGreetingRL
    {

        public string PrintHelloWorldWithName(UserModel userModel)
        {
            {
                if (!string.IsNullOrEmpty(userModel.FirstName) && !string.IsNullOrEmpty(userModel.LastName))
                {
                    return $"Hello, {userModel.FirstName} {userModel.LastName}";
                }
                else if (!string.IsNullOrEmpty(userModel.FirstName))
                {
                    return $"Hello, {userModel.FirstName}";
                }
                else if (!string.IsNullOrEmpty(userModel.LastName))
                {
                    return $"Hello, {userModel.LastName}";
                }
                return "Hello World!";
            }
        }

        public string PrintHelloWorld()
        {
            return "Hello World!";
        }
        /// <summary>
        /// Database code implementation
        /// </summary>
        private readonly HelloGreetingDbContext _context;

        public GreetingRL(HelloGreetingDbContext context)
        {
            _context = context;
        }
        public GreetingEntity SaveGreeting(string message)
        {
            var greeting = new GreetingEntity { Message = message };
            _context.Greetings.Add(greeting);
            _context.SaveChanges();
            return greeting;
        }
        public GreetingEntity GetGreetingById(int id)
        {
            return _context.Greetings.FirstOrDefault(g => g.Id == id);
        }
        public List<GreetingEntity> GetAllGreetings()
        {
            return _context.Greetings.ToList();
        }
        public GreetingEntity UpdateGreeting(int id, string newMessage)
        {
            var greeting = _context.Greetings.FirstOrDefault(g => g.Id == id);
            if (greeting != null)
            {
                greeting.Message = newMessage;
                _context.SaveChanges();
            }
            return greeting;

        }
        
    }

}


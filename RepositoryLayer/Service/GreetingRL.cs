using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Interface;
using ModelLayer.Model;

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
          return  "Hello World!";
        }
    }
}

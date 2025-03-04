﻿using BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Interface;
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

        
    }
}

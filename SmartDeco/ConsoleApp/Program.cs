using SmartDeco.Domain.Core;
using SmartDeco.Infrastructure.Logger;
using SmartDeco.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerFactory.Instance.Logger_Info("123");
            Console.WriteLine("Hello World!");
        }
    }
}

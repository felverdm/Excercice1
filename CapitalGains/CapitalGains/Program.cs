using CapitalGains.Models;
using CapitalGains.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CapitalGains
{
    class Program
    {
        static void Main(string[] args)
        {
            AdaptInput adaptInput = new AdaptInput();
            Operations operations = new Operations();
            Response response = new Response();

            Console.WriteLine("Capital Gains Calculator in C#\r");
            Console.WriteLine("------------------------\n");
            Console.WriteLine("Please put the input\r");
            Console.WriteLine("------------------------\n");
            string strInput = Console.ReadLine();
            Console.WriteLine("------------------------\n");

            List<Input> jsonInput = adaptInput.PrepareInput(strInput); // prepares the input to be parsed to json format
            jsonInput = operations.CalculateTaxes(jsonInput);
            response.printAnswer(jsonInput);

            Console.WriteLine("------------------------\n");
        }
    }
}

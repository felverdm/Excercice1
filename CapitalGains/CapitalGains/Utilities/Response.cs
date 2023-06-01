using CapitalGains.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalGains.Utilities
{
    public class Response
    {
        public void printAnswer(List<Input> jsonInput)
        {
            foreach (Input input in jsonInput)
            {
                //string rta = "[{ ";
                List<Output> outputs = new List<Output>();
                foreach (BaseInput baseInput in input.InputCapitalGains)
                {
                    Output output = new Output();
                    output.Tax = baseInput.Tax;
                    outputs.Add(output);
                }
                var json = JsonConvert.SerializeObject(outputs);
                Console.WriteLine(json.ToString() + "\n");
            }
        }

    }
}

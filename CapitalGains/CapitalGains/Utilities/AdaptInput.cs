using CapitalGains.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapitalGains.Utilities
{
    public class AdaptInput
    {
        public List<Input> PrepareInput(string strInput)
        {
            strInput = strInput.Replace("[", "");
            string[] strInputList = strInput.Split("]");
            strInputList = strInputList.SkipLast(1).ToArray();
            for (int i = 0; i < strInputList.Length; i++)
            {
                strInputList[i] = "[" + strInputList[i] + "]";
            }

            List<Input> jsonInput = new List<Input>();            
            for (int i = 0; i < strInputList.Length; i++)
            {
                Input tempInput = new Input();
                List<BaseInput> jsonBaseInput = new List<BaseInput>();
                jsonBaseInput = JsonConvert.DeserializeObject<List<BaseInput>>(strInputList[i]);
                tempInput.InputCapitalGains = jsonBaseInput;
                jsonInput.Add(tempInput);
            }
            return jsonInput;
        }
    }
}

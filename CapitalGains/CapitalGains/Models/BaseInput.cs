using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CapitalGains.Models
{
    public class BaseInput
    {
        [JsonProperty("operation")]
        public string Operation { set; get; }

        [JsonProperty("unit-cost")]
        public double UnitCost { set; get; }

        [JsonProperty("quantity")]
        public int Quantity { set; get; }

        [JsonProperty("tax")]
        public double Tax { set; get; }
    }
}

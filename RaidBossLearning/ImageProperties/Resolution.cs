using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidBossLearning.ImageProperties
{
    public class Resolution
    {
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }

        public override bool Equals(object obj)
        {
            var res = (Resolution)obj;
            return Height == res.Height && Width == res.Width;
        }
    }
}

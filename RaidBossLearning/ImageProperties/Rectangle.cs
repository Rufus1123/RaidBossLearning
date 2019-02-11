using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidBossLearning.ImageProperties
{
    public class Rectangle
    {
        [JsonProperty("top")]
        public int Top { get; set; }
        [JsonProperty("left")]
        public int Left { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
    }
}

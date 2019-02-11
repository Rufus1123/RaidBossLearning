using Newtonsoft.Json;
using RaidBossLearning.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidBossLearning.ImageProperties
{
    public class ImageProperty
    {
        [JsonProperty("raidLevel")]
        public RaidLevel RaidLevel { get; set; }
        [JsonProperty("resolution")]
        public Resolution Resolution { get; set; }
        [JsonProperty("iconsArea")]
        public Rectangle IconsArea { get; set; }
        [JsonProperty("iconsList")]
        public List<Rectangle> IconsList { get; set; }

        public ImageProperty()
        {

        }
    }
}

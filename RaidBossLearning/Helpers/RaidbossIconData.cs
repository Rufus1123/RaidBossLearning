using RaidBossLearning.ImageProperties;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace RaidBossLearning.Helpers
{
    public class RaidbossIconData
    {
        public List<ImageProperty> IconData { get; private set; }

        public void LoadIconData()
        {
            var allText = File.ReadAllText(@"IconData.json");

            IconData = JsonConvert.DeserializeObject<List<ImageProperty>>(allText);
        }
    }
}

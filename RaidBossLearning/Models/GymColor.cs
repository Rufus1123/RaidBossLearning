using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidBossLearning.Models
{
    public class GymColor: ObservableCollection<string>
    {
        public GymColor()
        {
            Add("None");
            Add("Mystic");
            Add("Valor");
            Add("Instinct");
        }
    }
}

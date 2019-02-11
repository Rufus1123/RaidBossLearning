using System.Collections.ObjectModel;

namespace RaidBossLearning.Models
{
    public class RaidLevel : ObservableCollection<string>
    {
        public RaidLevel()
        {
            Add("1");
            Add("2");
            Add("3");
            Add("4");
            Add("5");
            Add("6");
            Add("Boss");
        }
    }
}

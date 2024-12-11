using System.Collections.ObjectModel;
using BandApp.Models; 

namespace BandApp.Utils
{
    public interface IObserver
    {
        void Update(ObservableCollection<BandMember> members);
    }

    public class BandObserver : IObserver
    {
        public void Update(ObservableCollection<BandMember> members)
        {
            System.Console.WriteLine($"Updated members count: {members.Count}");
            foreach (var member in members)
            {
                System.Console.WriteLine($"Member: {member.Name}, Role: {member.Role}");
            }
        }
    }
}

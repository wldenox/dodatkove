using BandApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace BandApp.Utils
{
    public class BandFacade
    {
        private readonly BandDataManager _dataManager = BandDataManager.Instance;

        public List<BandMember> GetMembers()
        {
            return _dataManager.Members.ToList();
        }

        public void AddMember(BandMemberFactory factory)
        {
            var member = factory.CreateMember();
            _dataManager.AddMember(member);
        }

        public void DeleteMember(BandMember member)
        {
            _dataManager.RemoveMember(member);
        }

        public IEnumerable<BandMember> SortByRole()
        {
            return _dataManager.Members.OrderBy(m => m.Role);
        }

        public IEnumerable<BandMember> FilterByRole(string role)
        {
            return _dataManager.Members.Where(m => m.Role == role);
        }
    }
}

namespace BandApp.Models
{
    public abstract class BandMemberFactory
    {
        public abstract BandMember CreateMember();
    }

    public class MemberFactory : BandMemberFactory
    {
        public override BandMember CreateMember()
        {
            return new Member { Id = 0, Name = "New Member", Role = "Musician", Age = 25 };
        }
    }

    public class LeaderFactory : BandMemberFactory
    {
        public override BandMember CreateMember()
        {
            return new Leader { Id = 0, Name = "New Leader", Role = "Leader", Age = 30, YearsOfExperience = 5 };
        }
    }
}

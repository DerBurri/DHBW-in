using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DHB_Win.Models
{
    public partial class User
    {
        public User()
        {
            AchievedAchievement = new HashSet<AchievedAchievement>();
            Bet = new HashSet<Bet>();
            JobProvider = new HashSet<Job>();
            JobWorker = new HashSet<Job>();
        }

        public int Uid { get; set; }
        public string Firstname { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Street { get; set; }
        public int? PlzFk { get; set; }
        public int? ExpPoints { get; set; }
        public string PasswordHash { get; set; }
        public int? Walletbalance { get; set; }
        public byte[] Profilepicture { get; set; }

        public virtual Plz PlzFkNavigation { get; set; }
        public virtual Placement Placement { get; set; }
        public virtual ICollection<AchievedAchievement> AchievedAchievement { get; set; }
        public virtual ICollection<Bet> Bet { get; set; }
        public virtual ICollection<Job> JobProvider { get; set; }
        public virtual ICollection<Job> JobWorker { get; set; }
    }
}
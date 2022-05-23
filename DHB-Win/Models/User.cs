using System.Collections.Generic;

namespace DHB_Win.Models
{
    public partial class User
    {
        public User()
        {
            AchievedAchievements = new HashSet<AchievedAchievement>();
            Bets = new HashSet<Bet>();
            JobProviders = new HashSet<Job>();
            JobWorkers = new HashSet<Job>();
        }

        public int Uid { get; set; }
        public string? Firstname { get; set; }
        public string? Name { get; set; }
        public string? EMail { get; set; }
        public string? Street { get; set; }
        public int? PlzFk { get; set; }
        public int? ExpPoints { get; set; }
        public string? PasswordHash { get; set; }
        public int? Walletbalance { get; set; }
        public int? Profilepicture { get; set; }

        public virtual Plz? PlzFkNavigation { get; set; }
        public virtual Placement Placement { get; set; } = null!;
        public virtual ICollection<AchievedAchievement> AchievedAchievements { get; set; }
        public virtual ICollection<Bet> Bets { get; set; }
        public virtual ICollection<Job> JobProviders { get; set; }
        public virtual ICollection<Job> JobWorkers { get; set; }
    }
}
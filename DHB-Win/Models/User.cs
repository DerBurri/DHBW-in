using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DHB_Win.Models
{
    public partial class User : IdentityUser
    {
        public User()
        {
            AchievedAchievements = new HashSet<AchievedAchievement>();
            Bets = new HashSet<Bet>();
            JobProviders = new HashSet<Job>();
            JobWorkers = new HashSet<Job>();
            Placements = new HashSet<Placement>();
        }

        public string Firstname;

        public string Name;

        public int WalletBalance;

        public int ExpPoints;

        public string Street;

        public string Profilepicture;

        [Display(Name = "Postleitzahl")] public string PlzFk;
        public virtual Plz? PlzFkNavigation { get; set; }
        public virtual ICollection<AchievedAchievement> AchievedAchievements { get; set; }
        public virtual ICollection<Bet> Bets { get; set; }
        public virtual ICollection<Job> JobProviders { get; set; }
        public virtual ICollection<Job> JobWorkers { get; set; }
        public virtual ICollection<Placement> Placements { get; set; }
    }
}
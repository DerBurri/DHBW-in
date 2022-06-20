using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DHB_Win.Models
{
    public partial class User : IdentityUser
    {
        

        [PersonalData] public string? Firstname;
        [PersonalData] public string? Name;
        [PersonalData] public string? Plz;
        //[PersonalData] public byte? Profilepicture;
        [PersonalData] public string? Stadt;
        [PersonalData] public string? Street;
        [PersonalData] public int? WalletBalance;
        [PersonalData] public int? ExpPoints;

        public User()
        {
            AchievedAchievements = new HashSet<AchievedAchievement>();
            Bets = new HashSet<Bet>();
            JobProviders = new HashSet<Job>();
            JobWorkers = new HashSet<Job>();
            Placements = new HashSet<Placement>();
        }


        public virtual ICollection<AchievedAchievement> AchievedAchievements { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
        public virtual ICollection<Job> JobProviders { get; set; }
        public virtual ICollection<Job> JobWorkers { get; set; }
        public virtual ICollection<Placement> Placements { get; set; }
    }
}
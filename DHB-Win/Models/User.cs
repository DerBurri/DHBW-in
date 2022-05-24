using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
            Placements = new HashSet<Placement>();
        }

        [Display(Name = "User ID")]
        public int Uid { get; set; }

        [Display(Name = "Vorname")]
        [Required(ErrorMessage = "Vorname ist notwendig")]
        public string? Firstname { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name ist notwendig")]
        public string? Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email ist notwendig")]
        public string? EMail { get; set; }

        [Display(Name = "Strasse")]
        [Required(ErrorMessage = "Strasse ist notwendig")]
        public string? Street { get; set; }

        [Display(Name = "Postleitzahl")]
        [Required(ErrorMessage = "Postleitzahl ist notwendig")]
        public int? PlzFk { get; set; }

        [Display(Name = "User")]
        [Required(ErrorMessage = "User ist notwendig")]
        public int? ExpPoints { get; set; }

        [Display(Name = "Passwort")]
        [Required(ErrorMessage = "Passwort ist notwendig")]
        public string? PasswordHash { get; set; }

        [Display(Name = "Kontostand")]
        public int? Walletbalance { get; set; }

        [Display(Name = "Profilbild")]
        public int? Profilepicture { get; set; }


        public virtual Plz? PlzFkNavigation { get; set; }
        public virtual ICollection<AchievedAchievement> AchievedAchievements { get; set; }
        public virtual ICollection<Bet> Bets { get; set; }
        public virtual ICollection<Job> JobProviders { get; set; }
        public virtual ICollection<Job> JobWorkers { get; set; }
        public virtual ICollection<Placement> Placements { get; set; }
    }
}
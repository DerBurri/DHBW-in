using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DHB_Win.Models
{
    public partial class Bet
    {
        public Bet()
        {
            BetOptions = new HashSet<BetOption>();
            Placements = new HashSet<Placement>();
        }


        
        public int BetId { get; set; }

        [Display(Name = "User")]
        [Required(ErrorMessage = "User ist notwendig")]
        public int? UidFk2 { get; set; }

        [Display(Name = "Titel")]
        [Required(ErrorMessage = "Titel ist notwendig")]
        public string? Title { get; set; }

        [Display(Name = "Erfahrungspunkte")]
        [Required(ErrorMessage = "Erfahrungspunkte sind notwendig")]
        public int? ExpPoints { get; set; }

        [Display(Name = "Belohnung")]
        [Required(ErrorMessage = "Belohnung ist notwendig")]
        public int? Reward { get; set; }

        [Display(Name = "Beschreibung")]
        [Required(ErrorMessage = "Beschreibung ist notwendig")]
        public string? Description { get; set; }

        [Display(Name = "User")]
        public virtual User? UidFk2Navigation { get; set; }
        public virtual ICollection<BetOption> BetOptions { get; set; }
        public virtual ICollection<Placement> Placements { get; set; }
    }
}
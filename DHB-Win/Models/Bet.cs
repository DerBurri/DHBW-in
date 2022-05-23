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


        [Display(Name = "Bet ID")]
        public int BetId { get; set; }

        [Display(Name = "User")]
        [Required(ErrorMessage = "User ist notwendig")]
        public int? UidFk2 { get; set; }

        [Display(Name = "Titel")]
        [Required(ErrorMessage = "Titel ist notwendig")]
        public string? Title { get; set; }

        [Display(Name = "Erfahrungspunkte")]
        [Required(ErrorMessage = "Erfahrungspunkte sind notwendig")]
        [Range(0, 10,
        ErrorMessage = "Erfahrungspunkte dürfen nicht über 10 sein")]
        public int? ExpPoints { get; set; }

        [Display(Name = "Belohnung")]
        [Required(ErrorMessage = "Belohnung ist notwendig")]
        [Range(0, 100,
        ErrorMessage = "Beohnung darf nicht über 100 sein")]
        public int? Reward { get; set; }

        [Display(Name = "Beschreibung")]
        [Required(ErrorMessage = "Beschreibung ist notwendig")]
        public string? Description { get; set; }

        [Display(Name = "Datum")]
        public DateTime? CreationDate { get; set; }

        [Display(Name = "User")]
        public virtual User? UidFk2Navigation { get; set; }
        public virtual ICollection<BetOption> BetOptions { get; set; }
        public virtual ICollection<Placement> Placements { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHB_Win.Models
{
    /// <summary>
    /// Create jobs with Betcoins
    /// </summary>
    public partial class Job
    {
        public int JobId { get; set; }

        [Display(Name = "Titel")]
        [Required(ErrorMessage = "Titel ist notwendig")]
        public string? Title { get; set; }

        [Display(Name = "Beschreibung")]
        [Required(ErrorMessage = "Beschreibung ist notwendig")]
        public string? Description { get; set; }

        [Display(Name = "Belohnung")]
        [Required(ErrorMessage = "Belohnung ist notwendig")]
        [Range(0, 100,
            ErrorMessage = "Belohnung darf nicht über 100 sein")]
        public int? Reward { get; set; }

        [Display(Name = "Erfahrungspunkte")]
        [Required(ErrorMessage = "Erfahrungspunkte sind notwendig")]
        [Range(0, 10,
            ErrorMessage = "Erfahrungspunkte dürfen nicht über 10 sein")]
        public int? ExpPoints { get; set; }

        [Display(Name = "Erstelldatum")]
        [Required(ErrorMessage = "Erstelldatum ist notwendig")]
        public DateTime? CreationDate { get; set; }

        [Display(Name = "Enddatum")] public DateTime? FinishDate { get; set; }

        [Display(Name = "Anbieter")]
        [InverseProperty("JobProviders")]
        public virtual User Provider { get; set; }

        [Display(Name = "Arbeiter")]
        [InverseProperty("JobWorkers")]
        public virtual User? Worker { get; set; }
    }
}
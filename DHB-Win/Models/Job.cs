using System;
using System.ComponentModel.DataAnnotations;

namespace DHB_Win.Models
{
    /// <summary>
    /// Create jobs with Betcoins
    /// </summary>
    public partial class Job
    {
        [Display(Name = "Job ID")] public int JobId { get; set; }

        [Display(Name = "Anbieter ID")] public string? ProviderId { get; set; }

        [Display(Name = "Arbeiter ID")] public string? WorkerId { get; set; }

        [Display(Name = "Titel")]
        [Required(ErrorMessage = "Titel ist notwendig")]
        public string? Title { get; set; }

        [Display(Name = "Beschreibung")]
        [Required(ErrorMessage = "Beschreibung ist notwendig")]
        public string? Description { get; set; }

        [Display(Name = "Belohnung")]
        [Required(ErrorMessage = "Belohnung ist notwendig")]
        [Range(0, 100,
            ErrorMessage = "Beohnung darf nicht über 100 sein")]
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

        [Display(Name = "Anbieter")] public virtual User? Provider { get; set; }

        [Display(Name = "Arbeiter")] public virtual User? Worker { get; set; }
    }
}
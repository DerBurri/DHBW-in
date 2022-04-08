using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DHB_Win.Models
{
    public partial class BetOptions
    {
        public BetOptions()
        {
            Placement = new HashSet<Placement>();
        }

        public int OptionsId { get; set; }
        public int? BetId { get; set; }
        public string Title { get; set; }
        public string Descpription { get; set; }
        public int? QuoteValue { get; set; }

        public virtual Bet Bet { get; set; }
        public virtual ICollection<Placement> Placement { get; set; }
    }
}
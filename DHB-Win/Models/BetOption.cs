using System.Collections.Generic;

namespace DHB_Win.Models
{
    public partial class BetOption
    {
        public BetOption()
        {
            Placements = new HashSet<Placement>();
        }

        public string OptionsId { get; set; }
        public string? BetId { get; set; }
        public string? Title { get; set; }
        public string? Descpription { get; set; }
        public int? QuoteValue { get; set; }

        public virtual Bet? Bet { get; set; }
        public virtual ICollection<Placement> Placements { get; set; }
    }
}
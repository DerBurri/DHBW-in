using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DHB_Win.Models
{
    public partial class Bet
    {
        public Bet()
        {
            BetOptions = new HashSet<BetOptions>();
        }

        public int BetId { get; set; }
        public int UidFk2 { get; set; }
        public string Title { get; set; }
        public int? ExpPoints { get; set; }
        public int? Reward { get; set; }
        public string Description { get; set; }

        public virtual User UidFk2Navigation { get; set; }
        public virtual Placement Placement { get; set; }
        public virtual ICollection<BetOptions> BetOptions { get; set; }
    }
}
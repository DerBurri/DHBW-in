using System;
using System.Collections.Generic;

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
        public int? UidFk2 { get; set; }
        public string? Title { get; set; }
        public int? ExpPoints { get; set; }
        public int? Reward { get; set; }
        public string? Description { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual User? UidFk2Navigation { get; set; }
        public virtual ICollection<BetOption> BetOptions { get; set; }
        public virtual ICollection<Placement> Placements { get; set; }
    }
}
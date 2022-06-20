using System.ComponentModel.DataAnnotations.Schema;

namespace DHB_Win.Models
{
    public partial class Placement
    {
        public int PlacementId { get; set; }
        public int BetIdFk { get; set; }
        public string UidFk { get; set; }
        public int OptionIdFk { get; set; }

        public virtual Bet Bet { get; set; } = null!;
        public virtual BetOption? BetOption { get; set; }
        [InverseProperty("Placements")] public virtual User User { get; set; } = null!;
    }
}
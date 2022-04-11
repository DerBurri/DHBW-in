namespace DHB_Win.Models
{
    public partial class Placement
    {
        public int PlacementId { get; set; }
        public int BetIdFk { get; set; }
        public int UidFk { get; set; }
        public int? OptionIdFk { get; set; }

        public virtual Bet BetIdFkNavigation { get; set; } = null!;
        public virtual BetOption? OptionIdFkNavigation { get; set; }
        public virtual User UidFkNavigation { get; set; } = null!;
    }
}
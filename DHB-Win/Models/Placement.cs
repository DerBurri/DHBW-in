namespace DHB_Win.Models
{
    public partial class Placement
    {
        public string PlacementId { get; set; }
        public string BetIdFk { get; set; }
        public string UidFk { get; set; }
        public string? OptionIdFk { get; set; }

        public virtual Bet BetIdFkNavigation { get; set; } = null!;
        public virtual BetOption? OptionIdFkNavigation { get; set; }
        public virtual User UidFkNavigation { get; set; } = null!;
    }
}
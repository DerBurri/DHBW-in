

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DHB_Win.Models
{
    public partial class Placement
    {
        public int PlacementId { get; set; }
        public int BetIdFk { get; set; }
        public int UidFk { get; set; }
        public int? OptionIdFk { get; set; }

        public virtual Bet BetIdFkNavigation { get; set; }
        public virtual BetOptions OptionIdFkNavigation { get; set; }
        public virtual User UidFkNavigation { get; set; }
    }
}
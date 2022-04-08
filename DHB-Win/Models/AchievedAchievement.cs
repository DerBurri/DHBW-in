

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DHB_Win.Models
{
    public partial class AchievedAchievement
    {
        public int UidFk { get; set; }
        public int AchIdFk { get; set; }

        public virtual Achievement AchIdFkNavigation { get; set; }
        public virtual User UidFkNavigation { get; set; }
    }
}
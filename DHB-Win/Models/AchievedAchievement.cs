using System;

namespace DHB_Win.Models
{
    public partial class AchievedAchievement
    {
        public string UidFk { get; set; }
        public string AchIdFk { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Aaid { get; set; }

        public virtual Achievement AchIdFkNavigation { get; set; }
        public virtual User UidFkNavigation { get; set; }
    }
}
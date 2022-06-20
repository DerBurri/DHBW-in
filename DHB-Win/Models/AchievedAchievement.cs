using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHB_Win.Models
{
    public partial class AchievedAchievement
    {
        public string UidFk { get; set; }
        public int AchIdFk { get; set; }
        public DateTime? CreationDate { get; set; }
        public int Aaid { get; set; }

         public virtual Achievement AchIdFkNavigation { get; set; }
         [InverseProperty("AchievedAchievements")] public virtual User UidFkNavigation { get; set; }
    }
}
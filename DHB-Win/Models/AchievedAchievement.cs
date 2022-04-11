namespace DHB_Win.Models
{
    public partial class AchievedAchievement
    {
        public int UidFk { get; set; }
        public int AchIdFk { get; set; }

        public virtual Achievement AchIdFkNavigation { get; set; } = null!;
        public virtual User UidFkNavigation { get; set; } = null!;
    }
}
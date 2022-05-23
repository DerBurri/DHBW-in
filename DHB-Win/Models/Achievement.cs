using System;
using System.Collections.Generic;

namespace DHB_Win.Models
{
    public partial class Achievement
    {
        public int AchId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? ExpPoints { get; set; }
        public int? Reward { get; set; }

        public virtual AchievedAchievement AchievedAchievement { get; set; } = null!;
    }
}
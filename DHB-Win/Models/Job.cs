using System;
using System.Collections.Generic;

namespace DHB_Win.Models
{
    /// <summary>
    /// Create jobs with Betcoins
    /// </summary>
    public partial class Job
    {
        public int JobId { get; set; }
        public int? ProviderId { get; set; }
        public int? WorkerId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? Reward { get; set; }
        public int? ExpPoints { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? FinishDate { get; set; }

        public virtual User? Provider { get; set; }
        public virtual User? Worker { get; set; }
    }
}
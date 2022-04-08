

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DHB_Win.Models
{
    public partial class Job
    {
        public int JobId { get; set; }
        public int? ProviderId { get; set; }
        public int? WorkerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Reward { get; set; }
        public int? ExpPoints { get; set; }

        public virtual User Provider { get; set; }
        public virtual User Worker { get; set; }
    }
}
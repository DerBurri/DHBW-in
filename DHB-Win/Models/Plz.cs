using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DHB_Win.Models
{
    public partial class Plz
    {
        public Plz()
        {
            User = new HashSet<User>();
        }

        public int Plz1 { get; set; }
        public string Ort { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
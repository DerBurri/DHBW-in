using System.Collections.Generic;

namespace DHB_Win.Models
{
    public partial class Plz
    {
        public Plz()
        {
            Users = new HashSet<User>();
        }

        public string Plz1 { get; set; }
        public string? Ort { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
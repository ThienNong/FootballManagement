using System;
using System.Collections.Generic;

#nullable disable

namespace FootballManagement.Models
{
    public partial class Team
    {
        public Team()
        {
            Coaches = new HashSet<Coach>();
            Players = new HashSet<Player>();
        }

        public int TeamId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Coach> Coaches { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace FootballManagement.Models
{
    public partial class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int? BirthYear { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public int? TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}

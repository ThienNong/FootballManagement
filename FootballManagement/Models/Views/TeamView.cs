using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagement.Models.Views
{
    public class TeamView
    {
        public TeamView()
        {
            Coaches = new HashSet<Coach>();
            Players = new HashSet<Player>();
        }

        public int TeamId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Coach> Coaches { get; set; }
        public virtual ICollection<Player> Players { get; set; }

        public TeamView(Team team)
        {
            if (team == null)
                return;

            TeamId = team.TeamId;
            Name = team.Name;

            Players = new List<Player>();
            foreach (var player in team.Players)
            {
                var data = new Player()
                {
                    PlayerId = player.PlayerId,
                    Name = player.Name,
                    BirthYear = player.BirthYear,
                    Place = player.Place,
                    Description = player.Description,
                    Team = null,
                    TeamId = player.TeamId
                };
                Players.Add(data);
            }

            Coaches = new List<Coach>();
            foreach (var coach in team.Coaches)
            {
                var data = new Coach()
                {
                    CoachId = coach.CoachId,
                    Name = coach.Name,
                    BirthYear = coach.BirthYear,
                    Place = coach.Place,
                    Description = coach.Description,
                    Team = null,
                    TeamId = coach.TeamId
                };
                Coaches.Add(data);
            }
        }

        public List<TeamView> ToList(List<Team> list)
        {
            var data = new List<TeamView>();
            foreach(var item in list)
            {
                data.Add(new TeamView(item));
            }
            return data;
        }
    }
}

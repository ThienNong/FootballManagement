using FootballManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagement.BLL
{
    public class TeamServices
    {
        public List<Team> GetAllTeams()
        {
            try
            {
                using (var db = new FootballManagementContext())
                {
                    var data = db.Teams.Include(x => x.Players).Include(x => x.Coaches).ToList();

                    if (data.Count() == 0)
                        return null;

                    return data;
                }
            }
            catch
            {
                throw;
            }
        }

        public bool IsValid(int TeamID)
        {
            try
            {
                using (var db = new FootballManagementContext())
                {
                    var data = db.Teams.Where(x => x.TeamId == TeamID).FirstOrDefault();
                    return data != null;
                }
            }
            catch
            {
                throw;
            }
        }

        public Team GetTeam(int TeamID)
        {
            try
            {
                using (var db = new FootballManagementContext())
                {
                    var data = db.Teams.Include(x => x.Players).Include(x => x.Coaches).Where(x => x.TeamId == TeamID).FirstOrDefault();
                    return data;
                }
            }
            catch
            {
                throw;
            }
        }

        public Team AddTeam(Team team)
        {
            try
            {
                using (var db = new FootballManagementContext())
                {
                    db.Teams.Add(team);
                    db.SaveChanges();
                    return team;
                }
            }
            catch
            {
                throw;
            }
        }

        public Team UpdateTeam(Team team)
        {
            try
            {
                if (!IsValid(team.TeamId))
                    return null;

                using (var db = new FootballManagementContext())
                {
                    db.Teams.Update(team);
                    db.SaveChanges();
                    return team;
                }
            }
            catch
            {
                throw;
            }
        }

        public Team RemoveTeam(Team team)
        {
            try
            {
                if (!IsValid(team.TeamId))
                    return null;

                using (var db = new FootballManagementContext())
                {
                    db.Teams.Remove(team);
                    db.SaveChanges();
                    return team;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

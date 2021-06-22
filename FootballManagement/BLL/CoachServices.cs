using FootballManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagement.BLL
{
    public class CoachServices
    {
        public List<Coach> GetAllCoaches()
        {
            try
            {
                using (var db = new FootballManagementContext())
                {
                    var data = db.Coaches.ToList();

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

        public bool IsValid(int CoachID)
        {
            try
            {
                using (var db = new FootballManagementContext())
                {
                    var data = db.Coaches.Where(x => x.CoachId == CoachID).FirstOrDefault();
                    return data != null;
                }
            }
            catch
            {
                throw;
            }
        }

        public Coach GetCoach(int CoachID)
        {
            try
            {
                using (var db = new FootballManagementContext())
                {
                    var data = db.Coaches.Where(x => x.CoachId == CoachID).FirstOrDefault();
                    return data;
                }
            }
            catch
            {
                throw;
            }
        }

        public Coach AddCoach(Coach coach)
        {
            try
            {
                using (var db = new FootballManagementContext())
                {
                    db.Coaches.Add(coach);
                    db.SaveChanges();
                    return coach;
                }
            }
            catch
            {
                throw;
            }
        }

        public Coach UpdateCoach(Coach coach)
        {
            try
            {
                if (!IsValid((int)coach.CoachId))
                    return null;

                using (var db = new FootballManagementContext())
                {
                    db.Coaches.Update(coach);
                    db.SaveChanges();
                    return coach;
                }
            }
            catch
            {
                throw;
            }
        }

        public Coach RemoveCoach(Coach coach)
        {
            try
            {
                if (!IsValid((int)coach.CoachId))
                    return null;

                using (var db = new FootballManagementContext())
                {
                    db.Coaches.Remove(coach);
                    db.SaveChanges();
                    return coach;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

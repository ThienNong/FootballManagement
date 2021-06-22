using FootballManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagement.BLL
{
    public class PlayerServices
    {
        public List<Player> GetAllPlayers()
        {
            try
            {
                using (var db = new FootballManagementContext())
                {
                    var data = db.Players.ToList();

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

        public bool IsValid(int playerID)
        {
            try
            {
                using (var db = new FootballManagementContext())
                {
                    var data = db.Players.Where(x => x.PlayerId == playerID).FirstOrDefault();
                    return data != null;
                }
            }
            catch
            {
                throw;
            }
        }

        public Player GetPlayer(int playerID)
        {
            try
            {
                using (var db = new FootballManagementContext())
                {
                    var data = db.Players.Where(x => x.PlayerId == playerID).FirstOrDefault();
                    return data;
                }
            }
            catch
            {
                throw;
            }
        }

        public Player AddPlayer(Player player)
        {
            try
            {
                using (var db = new FootballManagementContext())
                {
                    db.Players.Add(player);
                    db.SaveChanges();
                    return player;
                }
            }
            catch
            {
                throw;
            }
        }

        public Player UpdatePlayer(Player player)
        {
            try
            {
                if (!IsValid(player.PlayerId))
                    return null;

                using (var db = new FootballManagementContext())
                {
                    db.Players.Update(player);
                    db.SaveChanges();
                    return player;
                }
            }
            catch
            {
                throw;
            }
        }

        public Player RemovePlayer(Player player)
        {
            try
            {
                if (!IsValid(player.PlayerId))
                    return null;

                using (var db = new FootballManagementContext())
                {
                    db.Players.Remove(player);
                    db.SaveChanges();
                    return player;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

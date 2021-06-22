using FootballManagement.BLL;
using FootballManagement.Models;
using FootballManagement.Models.Views;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Views;

namespace FootballManagement.Controllers
{
    public class TeamController : Controller
    {
        [HttpGet]
        [Route("GetAllTeams")]
        public IActionResult GetAllTeams()
        {
            try
            {
                var data = new TeamView().ToList(new TeamServices().GetAllTeams());

                if (data == null)
                    return Ok(ForFrontEnd<List<TeamView>>.False(data, "Không có dữ liệu!", null));

                return Ok(ForFrontEnd<List<TeamView>>.True(data));
            }
            catch (Exception e)
            {
                return Ok(ForFrontEnd<List<TeamView>>.False(null, "Không có dữ liệu!", e));
            }
        }

        [HttpGet]
        [Route("GetTeam")]
        public IActionResult GetTeam(int TeamID)
        {
            try
            {
                var data = new TeamView(new TeamServices().GetTeam(TeamID));

                if (data == null)
                    return Ok(ForFrontEnd<TeamView>.False(data, "Không có dữ liệu!", null));

                return Ok(ForFrontEnd<TeamView>.True(data));
            }
            catch (Exception e)
            {
                return Ok(ForFrontEnd<TeamView>.False(null, "Không có dữ liệu!", e));
            }
        }

        [HttpPost]
        [Route("AddTeam")]
        public IActionResult TeamCoach([FromBody] Team team)
        {
            try
            {
                var data = new TeamServices().AddTeam(team);

                if (data == null)
                    return Ok(ForFrontEnd<Team>.False(data, "Đã tồn tại!", null));

                return Ok(ForFrontEnd<Team>.True(data));
            }
            catch (Exception e)
            {
                return Ok(ForFrontEnd<Team>.False(null, "Lỗi!", e));
            }
        }

        [HttpPut]
        [Route("UpdateTeam")]
        public IActionResult UpdateCoach([FromBody] Team team)
        {
            try
            {
                var data = new TeamServices().UpdateTeam(team);

                if (data == null)
                    return Ok(ForFrontEnd<Team>.False(data, "Không tồn tại cầu thủ này!", null));

                return Ok(ForFrontEnd<Team>.True(data));
            }
            catch (Exception e)
            {
                return Ok(ForFrontEnd<Team>.False(null, "Lỗi!", e));
            }
        }

        [HttpDelete]
        [Route("RemoveTeam")]
        public IActionResult RemoveTeam([FromBody] Team team)
        {
            try
            {
                var data = new TeamServices().RemoveTeam(team);

                if (data == null)
                    return Ok(ForFrontEnd<Team>.False(data, "Không tồn tại huấn luyện viên này!", null));

                return Ok(ForFrontEnd<Team>.True(data));
            }
            catch (Exception e)
            {
                return Ok(ForFrontEnd<Team>.False(null, "Lỗi!", e));
            }
        }
    }
}

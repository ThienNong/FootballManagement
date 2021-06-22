using FootballManagement.BLL;
using FootballManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Views;

namespace FootballManagement.Controllers
{
    public class PlayerController : Controller
    {
        [HttpGet]
        [Route("GetAllPlayers")]
        public IActionResult GetAllPlayers()
        {
            try
            {
                var data = new PlayerServices().GetAllPlayers();

                if (data == null)
                    return Ok(ForFrontEnd<List<Player>>.False(data, "Không có dữ liệu!", null));

                return Ok(ForFrontEnd<List<Player>>.True(data));
            }
            catch (Exception e)
            {
                return Ok(ForFrontEnd<List<Player>>.False(null, "Không có dữ liệu!", e));
            }
        }

        [HttpGet]
        [Route("GetPlayer")]
        public IActionResult GetPlayer(int playerID)
        {
            try
            {
                var data = new PlayerServices().GetPlayer(playerID);

                if (data == null)
                    return Ok(ForFrontEnd<Player>.False(data, "Không có dữ liệu!", null));

                return Ok(ForFrontEnd<Player>.True(data));
            }
            catch (Exception e)
            {
                return Ok(ForFrontEnd<Player>.False(null, "Không có dữ liệu!", e));
            }
        }

        [HttpPost]
        [Route("AddPlayer")]
        public IActionResult AddPlayer([FromBody] Player player)
        {
            try
            {
                var data = new PlayerServices().AddPlayer(player);

                if (data == new Player())
                    return Ok(ForFrontEnd<Player>.False(data, "Đã tồn tại!", null));

                return Ok(ForFrontEnd<Player>.True(data));
            }
            catch (Exception e)
            {
                return Ok(ForFrontEnd<Player>.False(null, "Lỗi!", e));
            }
        }

        [HttpPut]
        [Route("UpdatePlayer")]
        public IActionResult UpdatePlayer([FromBody] Player player)
        {
            try
            {
                var data = new PlayerServices().UpdatePlayer(player);

                if (data == null)
                    return Ok(ForFrontEnd<Player>.False(data, "Không tồn tại cầu thủ này!", null));

                return Ok(ForFrontEnd<Player>.True(data));
            }
            catch (Exception e)
            {
                return Ok(ForFrontEnd<Player>.False(null, "Lỗi!", e));
            }
        }

        [HttpDelete]
        [Route("RemovePlayer")]
        public IActionResult RemovePlayer([FromBody] Player player)
        {
            try
            {
                var data = new PlayerServices().RemovePlayer(player);

                if (data == null)
                    return Ok(ForFrontEnd<Player>.False(data, "Không tồn tại cầu thủ này!", null));

                return Ok(ForFrontEnd<Player>.True(data));
            }
            catch (Exception e)
            {
                return Ok(ForFrontEnd<Player>.False(null, "Lỗi!", e));
            }
        }
    }
}

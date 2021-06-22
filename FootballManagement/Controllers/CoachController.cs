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
    public class CoachController : Controller
    {
        [HttpGet]
        [Route("GetAllCoaches")]
        public IActionResult GetAllCoaches()
        {
            try
            {
                var data = new CoachServices().GetAllCoaches();

                if (data == null)
                    return Ok(ForFrontEnd<List<Coach>>.False(data, "Không có dữ liệu!", null));

                return Ok(ForFrontEnd<List<Coach>>.True(data));
            }
            catch (Exception e)
            {
                return Ok(ForFrontEnd<List<Coach>>.False(null, "Không có dữ liệu!", e));
            }
        }

        [HttpGet]
        [Route("GetCoach")]
        public IActionResult GetCoach(int CoachID)
        {
            try
            {
                var data = new CoachServices().GetCoach(CoachID);

                if (data == null)
                    return Ok(ForFrontEnd<Coach>.False(data, "Không có dữ liệu!", null));

                return Ok(ForFrontEnd<Coach>.True(data));
            }
            catch (Exception e)
            {
                return Ok(ForFrontEnd<Coach>.False(null, "Không có dữ liệu!", e));
            }
        }

        [HttpPost]
        [Route("AddCoach")]
        public IActionResult AddCoach([FromBody] Coach coach)
        {
            try
            {
                var data = new CoachServices().AddCoach(coach);

                if (data == new Coach())
                    return Ok(ForFrontEnd<Coach>.False(data, "Đã tồn tại!", null));

                return Ok(ForFrontEnd<Coach>.True(data));
            }
            catch (Exception e)
            {
                return Ok(ForFrontEnd<Coach>.False(null, "Lỗi!", e));
            }
        }

        [HttpPut]
        [Route("UpdateCoach")]
        public IActionResult UpdateCoach([FromBody] Coach coach)
        {
            try
            {
                var data = new CoachServices().UpdateCoach(coach);

                if (data == null)
                    return Ok(ForFrontEnd<Coach>.False(data, "Không tồn tại cầu thủ này!", null));

                return Ok(ForFrontEnd<Coach>.True(data));
            }
            catch (Exception e)
            {
                return Ok(ForFrontEnd<Coach>.False(null, "Lỗi!", e));
            }
        }

        [HttpDelete]
        [Route("RemoveCoach")]
        public IActionResult RemoveCoach([FromBody] Coach coach)
        {
            try
            {
                var data = new CoachServices().RemoveCoach(coach);

                if (data == null)
                    return Ok(ForFrontEnd<Coach>.False(data, "Không tồn tại huấn luyện viên này!", null));

                return Ok(ForFrontEnd<Coach>.True(data));
            }
            catch (Exception e)
            {
                return Ok(ForFrontEnd<Coach>.False(null, "Lỗi!", e));
            }
        }
    }
}

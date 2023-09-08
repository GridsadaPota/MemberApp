using Member_App.Interface;
using Member_App.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Member_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet("Getall")]
        public JsonResult GetAllMember()
        {
            IEnumerable<MemberModel> mlist = _memberService.GetAll();
            return Json(mlist);


        }

        [HttpPost("Add")]
        public JsonResult AddMember(MemberModel model)
        {
            var response = _memberService.AddMember(model);
            if (response == true)
            {
                return Json(new { Status = 201, message = "Completed" });
            }
            else
            {
                return Json(new { Status = 400, message = "Not Completed" });
            }
        }



        [HttpGet("GetByID")]
        public JsonResult GetMemberByID(int id)
        {
            MemberModel member = _memberService.GetMemberByid(id);
            if (member == null)
                return Json(new { Status = 404, message = "Not Found" });
            else
                return Json(member);



        }

        [HttpPut("Update")]
        public JsonResult UpdateMember(MemberModel model)
        {
            var response = _memberService.EditMember(model);
            if (response == true)
            {
                return Json(new { Status = 201, message = "Update Completed" });
            }
            else
            {
                return Json(new { Status = 400, message = "Not Completed" });
            }



        }

        [HttpDelete("Delete")]
        public JsonResult DeleteMember(int id)
        {
            var response = _memberService.DeleteMember(id);
            if (response == true)
            {
                return Json(new { Status = 201, message = "Delete Completed" });
            }
            else
            {
                return Json(new { Status = 400, message = "Not Completed" });
            }
        }

    }
}

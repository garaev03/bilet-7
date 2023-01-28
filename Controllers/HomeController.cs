using Microsoft.AspNetCore.Mvc;
using Studio.Business.Services.Interfaces;
using Studio.Entities.DTOs.TeamMemberDtos;

namespace Studio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeamMemberService _service;

        public HomeController(ITeamMemberService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<TeamMemberGetDto> members;
            try
            {
                members= await _service.GetAllAsync();
            }
            catch
            {
                members = new();
            }
            return View(members);
        }
    }
}

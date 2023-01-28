using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Studio.Business.Services.Interfaces;
using Studio.Business.Utilities.Validation.TeamMemberValidations;
using Studio.Entities.DTOs.TeamMemberDtos;
using System.Data;

namespace Studio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TeamMembersController : Controller
    {
        private readonly ITeamMemberService _service;
        private readonly TeamMemberPostValidation _validator;

        public TeamMembersController(ITeamMemberService service, TeamMemberPostValidation validator)
        {
            _service = service;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            List<TeamMemberGetDto> members;
            try
            {
                members = await _service.GetAllAsync();
            }
            catch
            {
                members = new();
            }
            return View(members);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeamMemberPostDto postDto)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                var result = _validator.Validate(postDto);
                if (!result.IsValid)
                {
                    var error = result.Errors.FirstOrDefault();
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    return View();
                }
                await _service.CreateAsync(postDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            TeamMemberUpdateDto updateDto = new();
            try
            {

                updateDto.getDto = await _service.GetByIdAsync(id);
            }
            catch
            {
                return NotFound();
            }
            return View(updateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(TeamMemberUpdateDto updateDto)
        {
            updateDto.getDto.Name = updateDto.postDto.Name;
            updateDto.getDto.Position = updateDto.postDto.Position;
            updateDto.getDto.TwitterLink = updateDto.postDto.TwitterLink;
            updateDto.getDto.FacebookLink = updateDto.postDto.FacebookLink;
            updateDto.getDto.LinkedinLink = updateDto.postDto.LinkedinLink;
            if (!ModelState.IsValid) return View(updateDto);
            try
            {
                var result = _validator.Validate(updateDto.postDto);
                if (!result.IsValid)
                {
                    var error = result.Errors.FirstOrDefault();
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    return View(updateDto);
                }
                await _service.UpdateAsync(updateDto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(updateDto);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
            }
            catch
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}

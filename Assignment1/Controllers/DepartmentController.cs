using Assignment1.DataContextModels;
using Assignment1.DTOs;
using Assignment1.Models;
using Assignment1.Repositories.Department;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        [HttpGet("GetDepartment")]
        public async Task<IActionResult> Get() => Ok(await _departmentRepository.Get());
        [HttpGet("GetDepartmentById")]
        public async Task<IActionResult> GetById(int id) => Ok(await _departmentRepository.GetById(id));
        [HttpPost("CreateDepartment")]
        public async Task<IActionResult> Save(DepartmentDto departmentDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var data = await _departmentRepository.Save(departmentDto);
            return Ok(data);
        }
        [HttpPut("UpdateDepartment")]
        public async Task<IActionResult> Update(DepartmentDto departmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var data = await _departmentRepository.Update(departmentDto.Id,departmentDto);
            return Ok(data);
        }
        [HttpDelete("DeleteDepartment")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var data = await _departmentRepository.Delete(id);

            return Ok(data);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SevenShifts.Application.Contracts;

namespace SevenShifts.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employeeApp;

        public EmployeeController(IEmployee employeeApp)
        {
            _employeeApp = employeeApp;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeeData()
        {
            try
            {
                return Ok(await _employeeApp.GetEmployeeData());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetEmployeeData(int id)
        {
            try
            {
                return Ok(await _employeeApp.GetEmployeeData(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
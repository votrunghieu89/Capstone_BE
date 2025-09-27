using Capstone.Repositories.Dashboard;
using Capstone.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardJDsController : ControllerBase
    {
        public IDashboardJDsRepository _service;
        public DashboardJDsController(IDashboardJDsRepository service)
        {
            _service = service;
        }

        [HttpGet("total")]
        public async Task<IActionResult> GetTotalJD()
        {
            var total = await _service.GetTotalCreateJD();
            return Ok(total);
        }

        [HttpGet("byMonth")]
        public async Task<IActionResult> GetTotalJDByMonth(int month)
        {
            var totalByM = await _service.GetTotalCreateJDByMonth(month);
            return Ok(totalByM);
        }

    }
}

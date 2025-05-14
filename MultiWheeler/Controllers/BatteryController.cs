using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiWheeler.Domain;
using MultiWheeler.Data;

namespace MultiWheeler.Controllers
{
    [Route("api/v1/data/upload")]
    [ApiController]
    public class BatteryStatusController : ControllerBase
    {
        private readonly MultiWheelerContext _context;

        public BatteryStatusController(MultiWheelerContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> PostBatteryStatus(BatteryStatus batteryStatus)
        {
            var battery = await _context.Battery
                .FirstOrDefaultAsync(b => b.SN == batteryStatus.SN);

            if (battery == null)
            {
                return Ok(new { status = "wrong SN" });
            }

            batteryStatus.BatteryId = battery.BatteryId;

            _context.BatteryStatus.Add(batteryStatus);
            await _context.SaveChangesAsync();

            return Ok(new { status = "success" });
        }
    }
}
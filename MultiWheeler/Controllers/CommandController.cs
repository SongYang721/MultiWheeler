using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiWheeler.Domain;
using MultiWheeler.Data;

namespace MultiWheeler.Controllers
{
    [Route("api/v1/command")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly MultiWheelerContext _context;

        public CommandController(MultiWheelerContext context)
        {
            _context = context;
        }

        [HttpPost("ack")]
        public async Task<IActionResult> AcknowledgeCommand([FromBody] CMDResult cmdResult)
        {
            var cmd = await _context.CMD
                .FirstOrDefaultAsync(c => c.CommandId == cmdResult.CommandId);

            if (cmd == null)
            {
                return Ok(new { status = "wrong commandId" });
            }

            cmdResult.CMDId = cmd.CMDId;

            _context.CMDResult.Add(cmdResult);
            await _context.SaveChangesAsync();

            return Ok(new { status = "acknowledged" });
        }

        [HttpGet("poll")]
        public async Task<ActionResult> PollCommand([FromQuery] string sn)
        {
            if (string.IsNullOrEmpty(sn))
            {
                return BadRequest(new { status = "error", message = "Device SN is required" });
            }

            var command = await _context.CMD
                .Where(c => c.Battery != null && c.Battery.SN == sn)
                .OrderByDescending(c => c.CommandId)
                .FirstOrDefaultAsync();

            if (command == null)
            {
                return NotFound(new { status = "error", message = "No command or matching serial number found for the device" });
            }

            var response = new
            {
                commandId = command.CommandId,
                cmdType = command.CmdType,
                @params = command.Params
            };

            return Ok(response);
        }
    }
}
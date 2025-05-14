using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiWheeler.Domain
{
    public class BatteryStatus
    {
        public int BatteryStatusId { get; set; }
        [Required]
        public string? SN { get; set; }
        public string? Timestamp { get; set; }
        public float PackCurr { get; set; }
        public float PackVolt { get; set; }
        public int SOC { get; set; }
        public int SOH { get; set; }
        [NotMapped]
        public object? GPS { get; set; }
        public int ChargingSta { get; set; }
        public int PackError { get; set; }
        public float[]? MdVolt { get; set; }
        public float[]? MdTemp { get; set; }
        public int MdError { get; set; }
        public float[]? CellVolt { get; set; }
        public Battery? Battery { get; set; } //Navigation
        public int? BatteryId { get; set; } //FK
    }
}

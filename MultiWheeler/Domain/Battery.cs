using System.Collections.Generic;

namespace MultiWheeler.Domain
{
    public class Battery
    {
        public int BatteryId { get; set; } //PK
        public string? SN { get; set; }
        public Customer? Customer { get; set; } //Navigation
        public int? CustomerId { get; set; } //FK
        public ICollection<BatteryStatus>? BatteryStatuses { get; set; }
        public ICollection<CMD>? Commands { get; set; }
    }
}

using System.Collections.Generic;

namespace MultiWheeler.Domain
{
    public class Customer
    {
        public int CustomerId { get; set; } //PK
        public string? Name { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public ICollection<Report>? Reports { get; set; }
        public ICollection<Battery>? Batteries { get; set; }
    }
}

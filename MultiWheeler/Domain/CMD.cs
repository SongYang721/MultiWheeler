using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MultiWheeler.Domain
{
    public class CMD
    {
        public int CMDId { get; set; }
        public string? CommandId { get; set; }
        public string? CmdType { get; set; }
        public string? Params { get; set; } // Store as JSON string
        public Battery? Battery { get; set; } // Navigation
        public int? BatteryId { get; set; } // FK
        public CMDResult? CMDResult { get; set; }
        [NotMapped]
        public object? ParamsObject
        {
            get => Params == null ? null : JsonConvert.DeserializeObject<object>(Params);
            set => Params = JsonConvert.SerializeObject(value);
        }
    }
}

namespace MultiWheeler.Domain
{
    public class CMDResult
    {
        public int CMDResultId { get; set; }
        public string? CommandId { get; set; }
        public string? SN { get; set; }
        public string? Result { get; set; }
        public string? Message { get; set; }
        public CMD? CMD { get; set; }
        public int? CMDId { get; set; }
    }
}

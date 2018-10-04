namespace UspsWebApis.Models.RateResponse
{
    public class ExtraService
    {
        public string ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string Available { get; set; }
        public string Price { get; set; }
        public string DeclaredValueRequired { get; set; }
    }
}

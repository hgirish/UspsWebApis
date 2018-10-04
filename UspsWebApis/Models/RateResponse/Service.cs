namespace UspsWebApis.Models.RateResponse
{
    public class Service
    {
        public string Pounds { get; set; }
        public string Ounces { get; set; }
        public string MailType { get; set; }
        public string Container { get; set; }
        public string Size { get; set; }
        public string Width { get; set; }
        public string Length { get; set; }
        public string Height { get; set; }
        public string Girth { get; set; }
        public string Country { get; set; }
        public string Postage { get; set; }
        public ExtraServices ExtraServices { get; set; }
        public string ValueOfContents { get; set; }
        public string SvcCommitments { get; set; }
        public string SvcDescription { get; set; }
        public string MaxDimensions { get; set; }
        public string MaxWeight { get; set; }
        public string _ID { get; set; }
    }
}

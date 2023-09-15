namespace ApiWeb.Webapi.Dto.Reports
{
    public class OpdReportDto
    {
        public int Id { get; set; } 

        public DateTime Date { get; set; }

        public string Opd { get; set; }

        public Int64 Amount { get; set; }

        public Int64 Discount { get; set; }
        
       public Int64 NetAmount { get; set; }
    }
    
}

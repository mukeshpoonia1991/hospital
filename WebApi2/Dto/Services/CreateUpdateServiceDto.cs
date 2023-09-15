namespace ApiWeb.Webapi.Dto.Services
{
    public class CreateUpdateServiceDto
    {
        public string Name { get; set; }

        public int Amount { get; set; }

        public int Discountable { get; set; }
        public int ServiceTypeId { get; set; }
        public string Creatorid { get; set; }
        public DateTime CreatedDate { get; set; }

        public string ValidDay { get; set; }
        public int Hospitalid { get; set; }


    }
}

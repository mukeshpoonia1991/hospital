namespace ApiWeb.Webapi.Dto.Hospitals
{
    public class CreateUpdateHospitalDto
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public string RegistrationNumber { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        public int? PinCode { get; set; }

        public Int64? ContactNumber { get; set; }

        public string Website { get; set; }

        public string MailId { get; set; }

    }
}

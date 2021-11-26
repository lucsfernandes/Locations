namespace Locations.Models
{
    public class Address
    {
        public int id { get; set; }
        public string type { get; set; }
        public string cep { get; set; }
        public string address { get; set; }
        public string number { get; set; }
        public string complement { get; set; }
        public string neighborhood { get; set; }
        public string city { get; set; }
        public string uf { get; set; }
        public string country { get; set; }
        public int status { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string professional_id { get; set; }
        public string patient_id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public DateTime? deletedAt { get; set; }

    }
}

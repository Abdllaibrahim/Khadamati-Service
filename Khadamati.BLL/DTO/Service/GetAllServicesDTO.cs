
namespace Khadamati.BLL;

    public class GetAllServicesDTO
    {
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Location { get; set; } = string.Empty;
        public float Rating { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ProviderID { get; set; }= string.Empty;
        public DateTime date { get; set; }

    }

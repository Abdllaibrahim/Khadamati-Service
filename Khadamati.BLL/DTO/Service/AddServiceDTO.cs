
namespace Khadamati.BLL;

public class AddServiceDTO
    {       

        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryID { get; set; }
        public string providerId { get; set; }
        public DateTime date { get; set; }

        
        
    }

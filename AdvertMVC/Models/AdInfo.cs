using System.ComponentModel.DataAnnotations;

namespace AdvertMVC
{

    public class AdInfo
    {
        public ResponsiblePerson Person;
        public int ID
        {
            get; set;
        }
        [Required(ErrorMessage = "Field is required")]
        [StringLength(20, ErrorMessage = "Too long")]
        public string Description
        {
            get; set;
        }
        [Required(ErrorMessage = "Field is required")]
        [StringLength(20, ErrorMessage = "Too long")]
        public string Type
        {
            get; set;
        }
        [Required(ErrorMessage = "Field is required")]
        public int Price
        {
            get; set;
        }
    }
}

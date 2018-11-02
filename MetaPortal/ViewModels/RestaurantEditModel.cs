using MetaPortal.Models;
using System.ComponentModel.DataAnnotations;

namespace MetaPortal.ViewModels
{
    public class RestaurantEditModel
    {
        [Required, MaxLength(30)]
        public string Name { get; set; }
        public StatusType Status { get; set; }
    }
}

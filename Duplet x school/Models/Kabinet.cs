using System.ComponentModel.DataAnnotations;

namespace Duplet_x_school.Models
{
    public class Kabinet
    {
        public int Id { get; set; }
        [Display(Name = "Kabinet number")]
        public string Name { get; set; }

    }
}
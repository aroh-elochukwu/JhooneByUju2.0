using System.ComponentModel.DataAnnotations;

namespace JhooneByUju2._0.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Display Order")]
        public string DisplayOrder { get; set; }

    }
}

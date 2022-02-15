using System.ComponentModel.DataAnnotations;

namespace asp_net_core_mvc.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}

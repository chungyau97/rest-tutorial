using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rest_tutorial_1.Entities.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}

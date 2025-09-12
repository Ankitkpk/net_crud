using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSysterm.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
       [DisplayName("Category Name")]
        public string? Name { get; set; }
        [DisplayName("display order")]
        [Range(1,100,ErrorMessage ="display order between 1 -100")]
        public int DisplayOrder { get; set; }
    }
}
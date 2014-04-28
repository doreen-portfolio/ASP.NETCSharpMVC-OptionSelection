using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionClassLibrary.Models
{
    public class Option
    {
        [Key]
        [StringLength(50)]
        [Required]
        public string Title { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public virtual ICollection<Choice> Choices { get; set; }
    }
}

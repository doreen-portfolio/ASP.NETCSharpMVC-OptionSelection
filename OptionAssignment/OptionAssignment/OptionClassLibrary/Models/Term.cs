using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionClassLibrary.Models
{
    public class Term
    {
        [KeyAttribute]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int TermCode { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public virtual ICollection<Choice> Choices { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionClassLibrary.Models
{
    public class Choice
    {
        [Key]
        [Required]
        public int ChoiceId { get; set; }

        [StringLength(9)]
        [Required]
        public string StudentNumber { get; set; }

        [StringLength(40)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(40)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public int TermCode { get; set; }

        [StringLength(50)]
        [Required]
        public string FirstChoice { get; set; }

        [StringLength(50)]
        [Required]
        public string SecondChoice { get; set; }

        [StringLength(50)]
        [Required]
        public string ThirdChoice { get; set; }

        [StringLength(50)]
        [Required]
        public string FourthChoice { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public virtual Term Term { get; set; }
        public virtual ICollection<Option> Option { get; set; }
    }
}

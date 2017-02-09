using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsBetting.Models
{
    public class Odd
    {
     
       public int Id { get; set; }

       [Required]
       public int OriginId { get; set; }

        [Required]
        public string OddName { get; set; }

        [Required]
        public float OddValue { get; set; }
        
        public float? SpecialBetValue { get; set; }

        public virtual Bet Bet { get; set; }
    }
}

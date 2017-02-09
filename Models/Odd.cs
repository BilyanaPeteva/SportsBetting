using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class Odd
    {
        public int Id { get; set; }

        [Required]
        public int OriginId { get; set; }

        [Required]
        public string OddName { get; set; }

        public float OddValue { get; set; }

        public float SpecialBetValue { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsBetting.Models
{
    public class SportEvent
    {
        private ICollection<Match> matches;

        public SportEvent()
        {
            this.matches = new HashSet<Match>();
        }
        
        public int Id { get; set; }

        [Required]
        public string EventName { get; set; }

        [Required]
        public int EventOriginId { get; set; }

        public virtual ICollection<Match> Matches
        {
            get { return this.matches; }
            set { this.matches = value; }
        }

        public virtual Sport Sport { get; set; }
    }
}

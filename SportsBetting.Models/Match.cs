using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsBetting.Models
{
    public class Match
    {
        private ICollection<Bet> bets;

        public Match()
        {
            this.bets = new HashSet<Bet>();
        }

        public int Id { get; set; }

        [Required]
        public string MatchName { get; set; }

        [Required]
        public int MatchOriginId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public string MatchType { get; set; }

        public virtual ICollection<Bet> Bets
        {
            get { return this.bets; }
            set { this.bets = value; }
        }

        public virtual SportEvent SportEvent { get; set; }
    }
}

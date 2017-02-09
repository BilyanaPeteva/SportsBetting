using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SportsBetting.Models
{
  
    public class Sport
    {
        private ICollection<SportEvent> sportEvents;

        public Sport()
        {
            this.sportEvents = new HashSet<SportEvent>();
        }
   
        public int Id { get; set; }
       
        [Required]
        public string SportName { get; set; }
      
        [Required]
        public int SportOriginId { get; set; }
      
        public virtual ICollection<SportEvent> SportEvents
        {
            get { return this.sportEvents; }
            set { this.sportEvents = value; }
        }
    }
}

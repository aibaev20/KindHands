using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindHands.DAL.Models
{
    public class VolunteerAd
    {
        [Key]
        public int VolunteerAdId { get; set; }

        [ForeignKey("AdId")]
        public Ad? Ad { get; set; }

        [ForeignKey("VolunteerId")]
        public Volunteer? Volunteer { get; set; }

        public VolunteerAd()
        {
            Ad = null;
            Volunteer = null;
        }
    }
}
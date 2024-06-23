using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindHands.DAL.Models
{
    public class Ad
    {
        [Key]
        public int AdId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Information { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Location { get; set; }

        [ForeignKey("OrganisationId")]
        public Organisation? Organisation { get; set; }

        public Ad()
        {
            Title = "";
            Information = "";
            CreatedAt = DateTime.Now;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            Location = "";
            Organisation = null;
        }
    }
}
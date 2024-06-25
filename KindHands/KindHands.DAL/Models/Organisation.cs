using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindHands.DAL.Models
{
    public class Organisation
    {
        [Key]
        public int OrganisationId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        public Organisation()
        {
            Name = "";
            Description = "";
            User = null;
        }

        public Organisation(string name, string description, User user)
        {
            Name = name;
            Description = description;
            User = user;
        }
    }
}
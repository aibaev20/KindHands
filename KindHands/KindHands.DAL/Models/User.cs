using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindHands.DAL.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public User()
        {
            Username = "";
            Password = "";
            PhoneNumber = "";
            Email = "";
        }

        public User(string username, string password, string phoneNumber, string email)
        {
            Username = username;
            Password = password;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
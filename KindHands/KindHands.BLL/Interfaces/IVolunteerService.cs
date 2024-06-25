using KindHands.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindHands.BLL.Interfaces
{
    public interface IVolunteerService
    {
        bool CheckVolunteer(string phoneNumber);

        void AddVolunteer(string username, string password, string phoneNumber, string email, string firstName, string lastName);

        Volunteer ConvertToVolunteer(string username, string password, string phoneNumber, string email, string firstName, string lastName);

        bool AuthenticateVolunteer(string email, string password, string phoneNumber);
    }
}

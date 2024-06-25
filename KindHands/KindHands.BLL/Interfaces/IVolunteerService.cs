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
        bool CheckVolunteer(string firstName);

        void AddVolunteer(string username, string password, string phoneNumber, string email, string firstName, string lastName);

        Volunteer ConvertToVolunteer(string username, string password, string phoneNumber, string email, string firstName, string lastName);
    }
}

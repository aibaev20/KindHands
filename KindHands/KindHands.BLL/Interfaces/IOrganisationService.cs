using KindHands.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindHands.BLL.Interfaces
{
    public interface IOrganisationService
    {
        bool CheckOrganisation(string name);

        void AddOrganisation(string username, string password, string phoneNumber, string email, string name, string description);

        Organisation ConvertToOrganisation(string username, string password, string phoneNumber, string email, string name, string description);
    }
}

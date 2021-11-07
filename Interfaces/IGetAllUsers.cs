using mis321_pa4_api.Model;
using System.Collections.Generic;

namespace mis321_pa4_api.Interfaces
{
    public interface IGetAllUsers
    {
        List<User> GetUsers();
    }
}
using mis321_pa4_api.Model;

using System.Collections.Generic;

namespace mis321_pa4_api.Interfaces
{
    public interface IGetAllLikes
    {
        List<Like> GetLikes();
    }
}
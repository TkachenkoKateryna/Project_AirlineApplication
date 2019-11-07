using System.Collections.Generic;
using AirlineApplication.Core.Models;


namespace AirlineApplication.Core.Repositories
{
    public interface IProfessionRepository
    {
        IEnumerable<Profession> GetAllProfessions();
    }
}

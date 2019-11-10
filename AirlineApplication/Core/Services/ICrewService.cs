using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineApplication.Core.Models;
using AirlineApplication.Core.ViewModels;

namespace AirlineApplication.Core.Services
{
    public interface ICrewService : IDisposable
    {
        IEnumerable<CrewsViewModel> GetCrews();

        IEnumerable<CrewMember> GetCrewMembers();

        IEnumerable<CrewMember> GetFreeCrewMembers(int id, string date);

        void CreateCrew(CrewViewModel viewModel);

        CrewViewModel FormCrew(int id, CrewViewModel viewModel);

        void UpdateCrew(CrewViewModel viewModel);
    }
}

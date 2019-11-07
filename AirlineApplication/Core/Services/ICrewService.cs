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
        void CreateCrew(int id, string code);
        void UpdateCrew(int id);
        IEnumerable<CrewMember> GetCrewMembers();
        void CreateCrew(CrewViewModel viewModel);
        CrewViewModel FormCrew(int id, CrewViewModel viewModel);
        void UpdateCrew(CrewViewModel viewModel);
    }
}

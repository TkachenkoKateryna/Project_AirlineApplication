using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirlineApplication.Core.ViewModels;
using AirlineApplication.Core.Models;
using AirlineApplication.Core.Services;
using AirlineApplication.Core;


namespace AirlineApplication.Persistence.Services
{
    public class CrewService : ICrewService
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public CrewService(IUnitOfWork db)
        {
            _unitOfWork = db;
        }

        public IEnumerable<CrewMember> GetCrewMembers()
        {
            return _unitOfWork.CrewMembers.GetAllCrewMembers()
                .Where(m => m.isNotWorking == false);
        }

        public IEnumerable<CrewMember> GetFreeCrewMembers(int id, string date)
        {
            return _unitOfWork.CrewMembers.GetAllCrewMembers()
                .Where(m => m.isNotWorking == false)
                .Where(m => !m.Flights.Any(fl => fl.Flight.Date.ToString("dd/MM/yyyy") == date)
                || m.Flights.Any(f => f.FlightId == id));
        }

        public void CreateCrew(CrewViewModel viewModel)
        {
            var flight = _unitOfWork.Flights.GetFlight(viewModel.FlightId);

            _unitOfWork.CrewMembers.CreateCrew(flight, new List<int>() {
                viewModel.Captain,
                viewModel.FirstPilot,
                viewModel.Navigator,
                viewModel.RadioOperator,
                viewModel.MainFlightAttendant,
                viewModel.FligthAttendant
            });
            _unitOfWork.Complete();
        }

        public CrewViewModel FormCrew(int id, CrewViewModel viewModel)
        {
            var flight = _unitOfWork.Flights.GetFlight(id);

            viewModel.FlightId = flight.FlightId;
            viewModel.Date = flight.Date.ToString("dd/MM/yyyy");
            viewModel.FlightCode = flight.Code;

            foreach (var member in flight.CrewMembers)
            {
                switch (member.CrewMember.ProfessionId)
                {
                    case 1:
                        viewModel.Captain = member.CrewMemberId;
                        break;
                    case 2:
                        viewModel.FirstPilot = member.CrewMemberId;
                        break;
                    case 3:
                        viewModel.Navigator = member.CrewMemberId;
                        break;
                    case 4:
                        viewModel.RadioOperator = member.CrewMemberId;
                        break;
                    case 5:
                        viewModel.MainFlightAttendant = member.CrewMemberId;
                        break;
                    case 6:
                        viewModel.FligthAttendant = member.CrewMemberId;
                        break;
                }
            }
            return viewModel;
        }

        public void UpdateCrew(CrewViewModel viewModel)
        {
            var crew = _unitOfWork.Flights.FindCrew(viewModel.FlightId);

            foreach (var cr in crew)
            {
                cr.FlightId = viewModel.FlightId;

                switch (cr.CrewMember.ProfessionId)
                {
                    case 1:
                        cr.CrewMemberId = viewModel.Captain;
                        break;
                    case 2:
                        cr.CrewMemberId = viewModel.FirstPilot;
                        break;
                    case 3:
                        cr.CrewMemberId = viewModel.Navigator;
                        break;
                    case 4:
                        cr.CrewMemberId = viewModel.RadioOperator;
                        break;
                    case 5:
                        cr.CrewMemberId = viewModel.MainFlightAttendant;
                        break;
                    case 6:
                        cr.CrewMemberId = viewModel.FligthAttendant;
                        break;
                }
            }
            _unitOfWork.Complete();
        }

        public IEnumerable<CrewsViewModel> GetCrews()
        {
            var flights = _unitOfWork.Flights.GetAllFlights()
                .Where(fl => fl.IsDeleted == false 
                && fl.Date >= DateTime.Now);

            var crew = new List<CrewsViewModel>();

            foreach (var flight in flights)
            {
                var model = new CrewsViewModel();

                model.CrewId = flight.FlightId;
                model.FlightCode = flight.Code;
                model.Date = flight.Date.ToString("dd/MM/yyyy");

                if (flight.CrewMembers.Count == 0)
                {
                    model.Empty = true;
                }
                else
                {
                    foreach (var cr in flight.CrewMembers)
                    {
                        switch (cr.CrewMember.ProfessionId)
                        {
                            case 1:
                                model.Captain = cr.CrewMember.FullName;
                                break;
                            case 2:
                                model.FirstPilot = cr.CrewMember.FullName;
                                break;
                            case 3:
                                model.Navigator = cr.CrewMember.FullName;
                                break;
                            case 4:
                                model.RadioOperator = cr.CrewMember.FullName;
                                break;
                            case 5:
                                model.MainFlightAttendant = cr.CrewMember.FullName;
                                break;
                            case 6:
                                model.FligthAttendant = cr.CrewMember.FullName;
                                break;
                        }
                    }
                }
                crew.Add(model);
            }
            return crew;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
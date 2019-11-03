namespace AirlineApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using AirlineApplication.Models;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AirlineApplication.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AirlineApplication.Models.ApplicationDbContext context)
        {
            var crewMembers = new List<CrewMember>
            {
                 new CrewMember{FullName = "Leontovich Leonid Andreevich", ProfessionId = 1, },
                 new CrewMember{ FullName = "Apocha Vladimir Vladimirovich", ProfessionId = 1,},
                 new CrewMember{FullName = "Zaek Petr Artemovich", ProfessionId = 1,},
                 new CrewMember{ FullName = "Michuta Andrei Andreevich",ProfessionId = 2,},
                 new CrewMember{FullName = "Popov Artem Sergeevih", ProfessionId = 2, },
                 new CrewMember{FullName = "Ponoc Vasilii Nickolaevich", ProfessionId = 2, },
                 new CrewMember{FullName = "Nichko Artem Sergeevih", ProfessionId = 3, },
                 new CrewMember{FullName = "Kozlov Artem Artemovich", ProfessionId = 3, },
                 new CrewMember{FullName = "Demko Artem Vladimirovich", ProfessionId = 3, },
                 new CrewMember{FullName = "Shuraev Andrei Sergeevih", ProfessionId = 4, },
                 new CrewMember{FullName = "Kolodkin Vladimir Nickolaevich", ProfessionId = 4, },
                 new CrewMember{FullName = "Mochalov Vasilii Andreevich", ProfessionId = 4, },
                 new CrewMember{FullName = "Andreeva Maria Anatolivna", ProfessionId = 5, },
                 new CrewMember{FullName = "Tkachenko Katerina Andreevna", ProfessionId = 5, },
                 new CrewMember{FullName = "Bidna Lubov Vladimirovna", ProfessionId = 5, },
                 new CrewMember{FullName = "Kolesnik Valeria Stepanovnaa", ProfessionId = 6, },
                 new CrewMember{FullName = "Shtez Katerina Konstantnovna", ProfessionId = 6, },
                 new CrewMember{FullName = "Erochina Daria Aleksandrovna", ProfessionId = 6, }
            };
            crewMembers.ForEach(cr => context.CrewMembers.Add(cr));
            context.SaveChanges();

            var flights = new List<Flight>
            {
                 new Flight{Code ="0A3",Date =  new DateTime(2019,10,10, 12,30,0), StatusId = 4 },
                 new Flight{ Code ="0B4",Date =  new DateTime(2019,10,29, 11,45,00), StatusId = 4,},
                 new Flight{ Code ="0B8",Date = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,13,40,00), StatusId = 6},
                 new Flight{Code ="0A6",Date =new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,13,35,00), StatusId = 1},
                 new Flight{ Code ="0B8",Date = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,15,30,00), StatusId = 6},
                 new Flight{ Code ="0B8",Date = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,16,15,00), StatusId = 6},
                 new Flight{Code ="0C2",Date =  new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,18,00,00), StatusId = 6},
                 new Flight{Code ="0C6",Date = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,14,10,00), StatusId = 6},
                 new Flight{Code ="1S4",Date =  new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,20,40,00), StatusId =  6},
                 new Flight{Code ="1Q5",Date = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,21,30,00), StatusId = 6},
                 new Flight{Code ="1N6",Date =  new DateTime(2019,11,19,11,20,21), StatusId = 7},
                 new Flight{Code ="1M6",Date =  new DateTime(2019,11,18,11,30,00), StatusId = 7},
                 new Flight{Code ="1T4",Date =  new DateTime(2019,11,16,17,15,00), StatusId = 7},
                 new Flight{Code ="1G5",Date =  new DateTime(2019,11,15,19,10,00), StatusId = 7},
                 new Flight{Code ="1S5",Date =  new DateTime(2019,11,12,16,00,00), StatusId = 7},
                 new Flight{Code ="1C3",Date =  new DateTime(2019,11,13,18,30,00), StatusId = 7},
                 new Flight{Code ="5G4",Date =  new DateTime(2019,11,14,12,00,00), StatusId = 7},
            };
            flights.ForEach(fl => context.Flights.Add(fl));
            context.SaveChanges();

            var crew = new List<Crew>
            {
                 new Crew {FlightId = 78, CrewMemberId = 1},
                 new Crew {FlightId = 78, CrewMemberId = 5},
                 new Crew {FlightId = 78, CrewMemberId = 8},
                 new Crew {FlightId = 78, CrewMemberId = 10},
                 new Crew {FlightId = 78, CrewMemberId = 13},
                 new Crew {FlightId = 78, CrewMemberId = 16},
                 new Crew {FlightId = 79, CrewMemberId = 1},
                 new Crew {FlightId = 79, CrewMemberId = 5},
                 new Crew {FlightId = 79, CrewMemberId = 8},
                 new Crew {FlightId = 79, CrewMemberId = 10},
                 new Crew {FlightId = 79, CrewMemberId = 13},
                 new Crew {FlightId = 79, CrewMemberId = 16},
                 new Crew {FlightId = 80, CrewMemberId = 1},
                 new Crew {FlightId = 80, CrewMemberId = 5},
                 new Crew {FlightId = 80, CrewMemberId = 8},
                 new Crew {FlightId = 80, CrewMemberId = 10},
                 new Crew {FlightId = 80, CrewMemberId = 13},
                 new Crew {FlightId = 80, CrewMemberId = 16},
                 new Crew {FlightId = 80, CrewMemberId = 2},
                 new Crew {FlightId = 80, CrewMemberId = 6},
                 new Crew {FlightId = 80, CrewMemberId = 9},
                 new Crew {FlightId = 80, CrewMemberId = 11},
                 new Crew {FlightId = 80, CrewMemberId = 15},
                 new Crew {FlightId = 80, CrewMemberId = 18}
            };
            crew.ForEach(cr => context.Crew.Add(cr));
            context.SaveChanges();

            var routes = new List<Route>
            {
                 new Route {FlightId = 78, AirportId = 1, DestinationPoint = true},
                 new Route {FlightId = 78, AirportId = 2, DestinationPoint = false},
                 new Route {FlightId = 79, AirportId = 1, DestinationPoint = true},
                 new Route {FlightId = 79, AirportId = 3, DestinationPoint = false},
                 new Route {FlightId = 80, AirportId = 3, DestinationPoint = true},
                 new Route {FlightId = 80, AirportId = 1, DestinationPoint = false},
                 new Route {FlightId = 81, AirportId = 5, DestinationPoint = true},
                 new Route {FlightId = 81, AirportId = 6, DestinationPoint = false},
                 new Route {FlightId = 82, AirportId = 6, DestinationPoint = true},
                 new Route {FlightId = 82, AirportId = 5, DestinationPoint = false},
                 new Route {FlightId = 83, AirportId = 4, DestinationPoint = true},
                 new Route {FlightId = 83, AirportId = 5, DestinationPoint = false},
                 new Route {FlightId = 84, AirportId = 5, DestinationPoint = true},
                 new Route {FlightId = 84, AirportId = 4, DestinationPoint = false}, 
                 new Route {FlightId = 85, AirportId = 3, DestinationPoint = true},
                 new Route {FlightId = 85, AirportId = 5, DestinationPoint = false},
                 new Route {FlightId = 86, AirportId = 3, DestinationPoint = true},
                 new Route {FlightId = 86, AirportId = 6, DestinationPoint = false},
                 new Route {FlightId = 87, AirportId = 4, DestinationPoint = true},
                 new Route {FlightId = 87, AirportId = 7, DestinationPoint = false},
                 new Route {FlightId = 88, AirportId = 2, DestinationPoint = true},
                 new Route {FlightId = 88, AirportId = 1, DestinationPoint = false} ,
                 new Route {FlightId = 89, AirportId = 4, DestinationPoint = true},
                 new Route {FlightId = 89, AirportId = 3, DestinationPoint = false},
                 new Route {FlightId = 90, AirportId = 4, DestinationPoint = true},
                 new Route {FlightId = 90, AirportId = 5, DestinationPoint = false}
            };
            routes.ForEach(r => context.Routes.Add(r));
            context.SaveChanges();
        }
    }
}

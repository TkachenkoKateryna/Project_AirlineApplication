using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirlineApplication.Core.ViewModels;
using AirlineApplication.Core.Models;
using AirlineApplication.Core.Services;
using AirlineApplication.Core;
using AutoMapper;

namespace AirlineApplication.Persistence.Services
{
    public class ProfessionService : IProfessionService
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public ProfessionService(IUnitOfWork db)
        {
            _unitOfWork = db;
        }

        public IEnumerable<Profession> GetProfessions()
        {
            return _unitOfWork.Professions.GetAllProfessions()
                .Select(Mapper.Map<Profession, Profession>);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
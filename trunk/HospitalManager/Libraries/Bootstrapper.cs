using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using HospitalManager.Models;
using HospitalManager.ViewModels;

namespace HospitalManager.Libraries
{
    public class Bootstrapper
    {
        /**
         * Create the maps for AutoMapper
         */
        public static void ConfigureAutoMapper()
        {
            // Map the user models
            Mapper.CreateMap<User, UserViewModel>()
                  .ForMember(userVm => userVm.Permissions,
                             opt => opt.MapFrom(user => user.UserType.Permissions));

            Mapper.CreateMap<UserRegistrationViewModel, Patient>();
            Mapper.CreateMap<UserRegistrationViewModel, Doctor>();
            Mapper.CreateMap<UserRegistrationViewModel, Nurse>();
            Mapper.CreateMap<UserRegistrationViewModel, Pharmacist>();
            Mapper.CreateMap<PrescriptionViewModel, Prescription>();
            Mapper.CreateMap<Prescription, PrescriptionViewModel>();
            
            Mapper.CreateMap<Prescription, PrescriptionViewModel>();

        }

        /**
         * Debug the maps for AutoMapper
         */
        public static void TestAutoMapper()
        {
            Mapper.AssertConfigurationIsValid();
        }
    }
}
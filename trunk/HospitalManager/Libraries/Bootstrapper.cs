using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using HospitalManager.Models;
using HospitalManager.ViewModels;

namespace HospitalManager.Libraries
{
    /// <summary>
    /// Provides functionality related to our framework and libraries we are using
    /// rather than functionality related to the application itself.
    /// </summary>
    public class Bootstrapper
    {
        /// <summary>
        /// Create the maps for AutoMapper
        /// </summary>
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
            Mapper.CreateMap<Bill, BillingViewModel>();
            Mapper.CreateMap<Prescription, PrescriptionViewModel>();
            Mapper.CreateMap<BillingViewModel, Bill>();
        }

        /// <summary>
        /// Debug the maps for AutoMapper
        /// </summary>
        public static void TestAutoMapper()
        {
            Mapper.AssertConfigurationIsValid();
        }
    }
}
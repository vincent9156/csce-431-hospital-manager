using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManager.Repositories;
using HospitalManager.Models;
using HospitalManager.ViewModels;
using AutoMapper;

namespace HospitalManager.Controllers
{
    public class PermissionsTestController : Controller
    {
        /**
         * Get an instance of the user repository
         */
        UserRepository userRepository;

        public PermissionsTestController()
        {
            userRepository = new UserRepository();
        }

        /**
         * The form to create a new doctor
         * GET: /PermissionsTest/AddDoctor/
         */
        public ActionResult AddDoctor()
        {
            // Give a clean doctor to be populated by the form
            Doctor doctor = new Doctor();
            return View(doctor);
        }

        /**
         * The submission location for the doctor from the user's input
         * POST: /PermissionsTest/AddDoctor/
         */
        [HttpPost]
        public ActionResult AddDoctor(Doctor doctor)
        {
            // Ensure the input's state is valid before adding the user
            if (ModelState.IsValid)
            {
                doctor.encryptAndSetPassword(doctor.Password);
                userRepository.AddUser(doctor);

                // Redirect the user to show them information about who they submitted
                return Redirect("/PermissionsTest/ShowUser/" + doctor.Username);
            }

            // Return to the form if submission failed
            return View(doctor);
        }

        /**
         * Shows information about a user
         * GET: /PermissionsTest/ShowUser/{username}
         */
        public ActionResult ShowUser(string id)
        {
            // Get the user from the database
            User user = userRepository.GetUserByUsername(id);

            // Make sure we got a user, if we didn't, just let the view handle it. This
            // likely isn't optimal, but this is just example code
            if (user == null)
                return View(user);

            // Map the User to a UserViewModel and give it to the view
            UserViewModel userVm = Mapper.Map<User, UserViewModel>(user);
            return View(userVm);
        }
    }
}

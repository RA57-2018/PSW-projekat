using PswProject.dto;
using PswProject.model;
using PswProject.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;
using Microsoft.AspNetCore.Authentication;

namespace PswProject.service
{
    public class UserService
    {
        private UserRepository userRepository { get; set; }

        public UserService() { }

        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Boolean registration(RegistrationDTO registrationDTO) 
        {
            User user = new User(registrationDTO);

            user.setRole(Role.PATIENT);
            Console.WriteLine(user);
           // userRepository.save(user);

            return true;
	    }
    }
}

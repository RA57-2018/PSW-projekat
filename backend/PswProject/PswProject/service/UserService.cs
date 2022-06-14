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
        private UserSqlRepository userSqlRepositorys { get; set; }

        public UserService() { }

        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserService(UserSqlRepository userSqlRepository)
        {
            userSqlRepositorys = userSqlRepository;
        }

        public Boolean registration(RegistrationDTO registrationDTO) 
        {
            User user = new User(registrationDTO);
            user.Role = Role.PATIENT;
            userSqlRepositorys.Add(user);

            return true;
	    }

    }
}

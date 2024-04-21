﻿using EducationalPortal.Models;
using EducationalPortal.Repository.Interface;
using EducationalPortal.Service.Interface;
using NuGet.Protocol.Plugins;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace EducationalPortal.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ServiceResponse> Add(User user)
        {
            var resp = new ServiceResponse();

            user.PasswordHash = Helper.Hash.CreateSHA256(user.PasswordHash);

            var response = await _userRepository.Add(user);
            if (response.Status)
            {
                resp.Status = response.Status;
                resp.Data = user;
                return resp;
            }
            else
            {
                resp.Status = false;
                resp.Data = null;
                return resp;
            }
        }

        public async Task<ServiceResponse> Delete(User user)
        {
            var response = await _userRepository.Delete(user);
            return new ServiceResponse() { Status = response.Status, Data = response.Data };
        }

        public Task<IEnumerable<User>> GetAll()
        {
            return _userRepository.GetAll();
        }

        public async Task<User> GetById(string id)
        {            
            return await _userRepository.GetById(id);
        }

        public async Task<ServiceResponse> Login(LoginModel login)
        {
            var response = await _userRepository.Login(login);
            return new ServiceResponse() { Status = response.Status, Data = response.Data };
        }

        public async Task<ServiceResponse> Update(User user)
        {
            var response = await _userRepository.Update(user);
            return new ServiceResponse() { Status = response.Status, Data = response.Data };
        }        
    }
}

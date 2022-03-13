using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Data;
using No_Vk.Domain.Models.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace No_Vk.Domain.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _usersRepository;

        public UserDataService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor; 
            _usersRepository = userRepository;
        }

        public User GetMe()
        {
            if (!_httpContextAccessor.HttpContext.Session.Keys.Contains("Addressee")) return null;
            var user = _usersRepository.GetUser(_httpContextAccessor.HttpContext.Session.GetString("Addressee"));
            return user ?? null;
        }

        public IQueryable<Message> GetMessages()
        {
            var user = GetMe();
            return user != null ? _usersRepository.GetMessages().Where(m => m.FromUser.Id == user.Id) : null;
        }

        public IQueryable<Notice> GetNotices()
        {
            var user = GetMe();
            return user != null ? _usersRepository.GetNotices().Where(n => n.Addressee.Id == user.Id) : null;
        }

    }
}
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
        private IHttpContextAccessor _httpContextAccessor;
        private IUserRepository _usersRepository;

        public UserDataService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor; 
            _usersRepository = userRepository;
        }

        public User GetMe()
        {
            if (_httpContextAccessor.HttpContext.Session.Keys.Contains("User"))
            {
                User user = _usersRepository.GetUser(_httpContextAccessor.HttpContext.Session.GetString("User"));
                if (user != null)
                {
                    return user;
                }
            }
            return null;
        }

        public IQueryable<Friend> GetFriends()
        {
            User _user = GetMe();
            if (_user != null)
            {
                return _usersRepository.GetFriends().Where(f => f.Friend1.Id == _user.Id || f.Friend2.Id == _user.Id);
            }
            return null;
        }

        public IEnumerable<User> GetFriendsAsUser()
        {
            User _user = GetMe();
            if (_user != null)
            {
                IQueryable<Friend> friends = _usersRepository
                    .GetFriends().Include(f => f.Friend1).Include(f => f.Friend2)
                    .Include(f => f.Friend1)
                    .Include(f => f.Friend2);
                foreach (var friend in friends)
                {
                    if (friend.Friend1.Id == _user.Id)
                    {
                        yield return friend.Friend2;
                    }
                    else if (friend.Friend2.Id == _user.Id)
                    {
                        yield return friend.Friend1;
                    }
                }
            }
            yield break;
        }

        public IQueryable<Message> GetMessages()
        {
            User _user = GetMe();
            if (_user != null)
            {
                return _usersRepository.GetMessages().Where(m => m.FromUser.Id == _user.Id);
            }
            return null;
        }

        public IQueryable<Notice> GetNotices()
        {
            User _user = GetMe();
            if (_user != null)
            {
                return _usersRepository.GetNotices().Where(n => n.User.Id == _user.Id);
            }
            return null;
        }

    }
}
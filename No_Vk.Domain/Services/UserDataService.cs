using Microsoft.AspNetCore.Http;
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

        public User GetUser()
        {
            if (_httpContextAccessor.HttpContext.Session.Keys.Contains("User"))
            {
                User user = _httpContextAccessor.HttpContext.Session.GetObject<User>("User");
                if (user != null)
                {
                    return user;
                }
            }
            return null;
        }

        public IQueryable<Friend> GetFriends()
        {
            User _user = GetUser();
            if (_user != null)
            {
                return _usersRepository.GetFriends().Where(f => f.Friend1.Id == _user.Id || f.Friend2.Id == _user.Id);
            }
            return null;
        }

        public IEnumerable<User> GetFriendsAsUser()
        {
            User _user = GetUser();
            if (_user != null)
            {
                IQueryable<Friend> friends = _usersRepository.GetFriends();
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
            yield return null;
        }

        public IQueryable<Message> GetMessages()
        {
            User _user = GetUser();
            if (_user != null)
            {
                return _usersRepository.GetMessages().Where(m => m.FromUser.Id == _user.Id);
            }
            return null;
        }

        public IQueryable<Notice> GetNotices()
        {
            User _user = GetUser();
            if (_user != null)
            {
                return _usersRepository.GetNotices().Where(n => n.User.Id == _user.Id);
            }
            return null;
        }

    }
}
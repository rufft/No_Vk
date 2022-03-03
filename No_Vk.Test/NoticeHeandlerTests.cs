using Moq;
using No_Vk.Domain.Models;
using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Data;
using No_Vk.Domain.Models.Notices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace No_Vk.Test
{
    public class NoticeHeandlerTests
    {
        Mock<IUserRepository> _userRepositoryMock = new();


        private IQueryable<Notice> GetNotices()
        {
            return new List<Notice>
            {
                new()
                {
                    Type = NoticeType.FriendInvite.ToString()
                },
                new()
                {
                    Type = NoticeType.ChatInvite.ToString(),
                }
            }.AsQueryable();
        }
    }
}

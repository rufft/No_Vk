using No_Vk.Domain.Models.Abstractions;
using No_Vk.Domain.Models.Data;

namespace No_Vk.Domain.Models.Extensions
{
    public static class UsersRepositoryExtensions
    {
        public static void AddNewUser(this IUserRepository repository, UserRegistrationBindingTarget target)
        {
            using(repository)
            {
                User user = target.ToUser();
                repository.AddUser(user);
                repository.Save();
            }
        }
    }
}

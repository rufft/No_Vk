using System.ComponentModel.DataAnnotations.Schema;

namespace No_Vk.Domain.Models.Data
{
    public class Friend
    {
        private Friend() { }
        public Friend(User friend1, User friend2)
        {
            Friend1 = friend1;
            Friend2 = friend2;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public User Friend1 { get; set; }
        public User Friend2 { get; set; }
    }
}

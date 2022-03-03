namespace No_Vk.Domain.Models.Abstractions
{
    public interface IChat : IIdentifier
    {
        public string Name { get; set; }
    }
}

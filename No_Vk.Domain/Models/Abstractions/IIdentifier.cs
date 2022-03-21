using System.ComponentModel.DataAnnotations.Schema;

namespace No_Vk.Domain.Models.Abstractions
{
    public interface IIdentifier
    {
        public string Id { get; init; }
    }
}

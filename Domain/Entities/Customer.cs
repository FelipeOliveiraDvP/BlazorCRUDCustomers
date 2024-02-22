using System.ComponentModel.DataAnnotations;

namespace BlazorCRUDCustomers.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe um nome para o cliente")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe um e-mail para o cliente")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido")]
        public string Email { get; set; } = string.Empty;
    }
}

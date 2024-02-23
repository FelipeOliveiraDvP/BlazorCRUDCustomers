using BlazorCRUDCustomers.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BlazorCRUDCustomers.Domain.Entities
{
    public class Todo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe um título")]
        public string Title { get; set; } = string.Empty;

        [EnumDataType(typeof(Status))]        
        public Status Status { get; set; }
    }
}

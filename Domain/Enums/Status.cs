using System.ComponentModel.DataAnnotations;

namespace BlazorCRUDCustomers.Domain.Enums
{
    public enum Status
    {
        [Display(Name = "Não Iniciado")]
        NotStarted,

        [Display(Name = "Em Progresso")]
        InProgress,

        [Display(Name = "Completo")]
        Completed
    }
}

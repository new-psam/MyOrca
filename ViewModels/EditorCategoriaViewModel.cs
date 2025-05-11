using System.ComponentModel.DataAnnotations;

namespace MyOrca.ViewModels;

public class EditorCategoriaViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório!")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 40 caracteres")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O slug é obrigatório!")]
    public string Slug { get; set; }
}
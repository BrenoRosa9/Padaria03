using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Padaria03.Models
{
    public class Cliente
    {
        [Key]
        public  int IdCliente { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [MaxLength(60, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [MaxLength(11, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [RegularExpression(@"[0-9]{11}$", ErrorMessage = "O campo {0} deve ser preenchido com 11 dígitos numéricos")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [DisplayName("E-mail")]
        [EmailAddress(ErrorMessage = "O campo {0} deve conter um endereço de email válido.")]
        public string Email { get; set; }
    }
}

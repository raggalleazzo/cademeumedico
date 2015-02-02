using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadeMeuMedico.Models
{
    [MetadataType(typeof(UsuarioMetadata))]
    public partial class Usuario
    {

    }

    public class UsuarioMetadata
    {
        [Required(ErrorMessage = "Obrigatório informar o nome do usuário")]
        [StringLength(80, ErrorMessage = "O nome do usuário deve possuir no máximo 80 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o login do usuário")]
        [StringLength(30, ErrorMessage = "O login deve possuir no máximo 30 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a senha do usuário")]
        [StringLength(100, ErrorMessage = "A senha deve possuir no máximo 100 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o e-mail do usuário")]
        [StringLength(100, ErrorMessage = "O e-mail deve possuir no máximo 100 caracteres")]
        public string Email { get; set; }
    }
}
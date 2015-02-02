using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadeMeuMedico.Models
{
    [MetadataType(typeof(MedicoMetadata))]
    public partial class Medico
    {

    }

    public class MedicoMetadata
    {
        [Required(ErrorMessage = "Obrigatório informar o CRM")]
        [StringLength(30, ErrorMessage = "O CRM deve possuir no máximo 30 caracteres")]
        public string CRM { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome")]
        [StringLength(80, ErrorMessage = "O nome deve possuir no máximo 80 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o endereço")]
        [StringLength(100, ErrorMessage = "O endereço deve possuir no máximo 100 caracteres")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o bairro")]
        [StringLength(60, ErrorMessage = "O bairro deve possuir no máximo 60 caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o e-mail")]
        [StringLength(100, ErrorMessage = "O e-mail deve possuir no máximo 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar se o médico atende por convênio")]
        public bool AtendePorConvenio { get; set; }

        [Required(ErrorMessage = "Obrigatório informar se o médico possui clínica")]
        public bool TemClinica { get; set; }

        [StringLength(80, ErrorMessage = "O website deve possuir no máximo 80 caracteres")]
        public string WebsiteBlog { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a cidade")]
        public int IDCidade { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a especialidade do médico")]
        public int IDEspecialidade { get; set; }
    }
}
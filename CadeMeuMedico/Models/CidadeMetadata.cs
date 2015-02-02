using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadeMeuMedico.Models
{
    [MetadataType(typeof(CidadeMetadata))]
    public partial class Cidade
    {

    }

    public class CidadeMetadata
    {
        [Required(ErrorMessage = "Obrigatório informar o nome da cidade")]
        [StringLength(100, ErrorMessage = "O nome da cidade deve possuir no máximo 100 caracteres")]
        public string Nome { get; set; }
    }
}
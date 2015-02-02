﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadeMeuMedico.Models
{
    [MetadataType(typeof(EspecialidadeMetadata))]
    public partial class Especialidade
    {

    }

    public class EspecialidadeMetadata
    {
        [Required(ErrorMessage = "Obrigatório informar o nome da especialidade")]
        [StringLength(80, ErrorMessage = "O nome da especialidade deve possuir no máximo 80 caracteres")]
        public string Nome { get; set; }
    }
}
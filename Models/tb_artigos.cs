//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestaoArtigos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tb_artigos
    {
        [Required]
        public int codigo { get; set; }

        [Required(ErrorMessage = "Introduza a refer�ncia do artigo!")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Insira apenas caracteres alfan�mericos!")]
        public string referencia { get; set; }

        [Required(ErrorMessage = "Introduza uma descri��o para o artigo!")]
        [StringLength(30, ErrorMessage = "A descri��o deve ter entre {2} a {1} caracteres", MinimumLength = 5)]
        public string descricao { get; set; }
        
        [Required]
        public DateTime data_criado { get; set; }
        
        [Required]
        public DateTime data_alterado { get; set; }

        [Required(ErrorMessage = "Introduza o seu n�mero de utilizador!")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Insira o seu n�mero de utilizador!")]
        public int codigo_utilizador { get; set; }
    }
}

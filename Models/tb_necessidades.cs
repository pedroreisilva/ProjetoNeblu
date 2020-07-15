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
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tb_necessidades
    {
        [Required]
        public int codigo { get; set; }
        [Required(ErrorMessage = "Insira o n�mero do artigo!")]
        public int codigo_artigo { get; set; }
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Insira um valor v�lido!")]
        public double quantidade_atual { get; set; }
        [Required]
        public string estado { get; set; }
        [Required]
        public System.DateTime data_criado { get; set; }
        [Required]
        public System.DateTime data_alterado { get; set; }

        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Insira o seu n�mero de utilizador!")]
        public int codigo_utilizador { get; set; }
    }

}
    public enum Estado
    {
        Novo,
        Pendente,
        Concluido
    }


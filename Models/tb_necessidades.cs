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

    public partial class tb_necessidades
    {

        [Required]
        public int id_necessidade { get; set; }

        [Required]
        public int id_artigo { get; set; }

        [Display(Name = "Quantidade atual")]
        [Range(1, 9999999, ErrorMessage = "{0} deve estar contido entre {1} e {2}.")]
        [Required(ErrorMessage = "Introduza a quantidade atual!")]
        public double quantidade_atual { get; set; }

        [Required]
        public string estado { get; set; }

        [Required]
        public System.DateTime data_criado { get; set; }

        [Required]
        public System.DateTime data_alterado { get; set; }

        [Required(ErrorMessage = "Introduza o seu n�mero de utilizador!")]
        [Display(Name = "N�mero de utilizador")]
        [Range(1, 9999999, ErrorMessage = "{0} deve estar contido entre {1} e {2}.")]
        public int id_utilizador { get; set; }
    
        public virtual tb_artigos tb_artigos { get; set; }
        public virtual tb_utilizadores tb_utilizadores { get; set; }
    }
}
public enum Estado
{
    Novo,
    Pendente,
    Concluido
}
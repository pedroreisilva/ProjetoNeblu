using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoArtigos.Models
{
    public class NebluViewModel
    {
        public List<tb_artigos> ArtigosModel { get; set; }
        public tb_necessidades NecessidadesModel { get; set; }

    }
}
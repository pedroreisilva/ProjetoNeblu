using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestaoArtigos.Models
{
    public class NebluViewModel
    {
        public List<tb_artigos> artigosModel { get; set; }
        public tb_necessidades necessidadesModel { get; set; }

    }
}
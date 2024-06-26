using GestionLab.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLab.Utility
{
    public class ResponseLogin
    {
        public string token {  get; set; }
        public UsuarioDTO user { get; set; }
    }
}

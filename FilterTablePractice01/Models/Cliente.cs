using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilterTablePractice01.Models
{
    public class Cliente
    {
        [Display(Name = "Código Cliente", Order = 0)]
        public int idcli { get; set; }

        [Display(Name = "Nombre Cliente", Order = 1)]
        public string nomcli { get; set; }

        [Display(Name = "Apellido Cliente", Order = 2)]
        public string apecli { get; set; }

        [Display(Name = "ID Distrito", Order = 3)]
        public int iddist { get; set; }

        [Display(Name = "Fecha de Registro", Order = 4)]
        public DateTime fecha_reg { get; set; }

        [Display(Name = "Estado", Order = 5)]
        public int estado { get; set; }

        [Display(Name = "Distrito", Order = 6)]
        public string nomdist{ get; set; }
    }
}
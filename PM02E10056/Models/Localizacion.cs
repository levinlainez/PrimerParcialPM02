using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM02E10056.Models
{
    public class Localizacion
    {
        [PrimaryKey, AutoIncrement]
        public int codigo { get; set; }
        [MaxLength(70)]
        public string Latitud { get; set; }
        [MaxLength(70)]
        public string Longitud { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }
        [MaxLength(100)]
        public string DescripcionCorta { get; set; }
    }
}
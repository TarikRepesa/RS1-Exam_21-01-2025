using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Examples.Data
{
    [Table("StudentMaticnaKnjiga")]
    public class StudentMaticnaKnjiga
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int AkademskaGodinaId { get; set; }
        public AkademskaGodina  AkademskaGodina { get; set; }
        public int Godina { get; set; }
        public bool Obnova { get; set; }
        public DateTime DatumUpisa { get; set; }
        public DateTime? DatumOvjere { get; set; }
        public float CijenaSkolarine { get; set; }
        public string Napomena { get; set; }
        public int EvidentiraoId { get; set; }
        public KorisnickiNalog Evidentirao { get; set; }

    }
}

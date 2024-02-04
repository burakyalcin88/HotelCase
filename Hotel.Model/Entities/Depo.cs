using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Model.Entities
{
    public class Depo : BaseEntity
    {
        [ForeignKey("BinaId")]
        public int BinaId { get; set; }
        public string DepoAdi { get; set; }

        public Bina Bina { get; set; }
    }
}

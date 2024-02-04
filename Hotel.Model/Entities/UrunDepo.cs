using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Model.Entities
{
    public class UrunDepo : BaseEntity
    {
        [ForeignKey("DepoId")]
        public int DepoId { get; set; }

        [ForeignKey("UrunId")]
        public int UrunId { get; set; }


        public Urun Urun { get; set; }
        public Depo Depo { get; set; }
    }
}
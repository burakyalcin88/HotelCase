using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Model.Entities
{
    public class Oda : BaseEntity
    {
        [ForeignKey("BinaId")]
        public int BinaId { get; set; }
        public string OdaAdi { get; set; }

        public Bina Bina { get; set; }
    }
}

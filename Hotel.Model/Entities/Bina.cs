namespace Hotel.Model.Entities
{
    public class Bina : BaseEntity
    {
        public string BinaAdi { get; set; }
        public string BinaAdresi { get; set; }

        public virtual IEnumerable<Oda> Odalar { get; set; }
        public virtual IEnumerable<Depo> Depolar { get; set; }
    }
}
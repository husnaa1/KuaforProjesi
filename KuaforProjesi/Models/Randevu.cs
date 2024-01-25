using System.ComponentModel.DataAnnotations;

namespace KuaforProjesi.Models
{
    public class Randevu
    {
        [Key]
        public int Randevu_ID { get; set; }
        public string Randevu_KisiAd { get; set; }
        public string Randevu_KisiSoyad { get; set; }
        public string Randevu_İcerigi { get; set; }
        public string Randevu_Tarihi { get; set; }
        public string Randevu_Saati { get; set; }
        public string Odeme_Turu { get; set; }
        public string Randevu_Personel { get; set; }
        public int Kisi_ID { get; set; }

    }
}

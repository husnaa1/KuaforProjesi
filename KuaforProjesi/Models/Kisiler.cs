using System.ComponentModel.DataAnnotations;

namespace KuaforProjesi.Models
{
    public class Kisiler
    {
        [Key]
        public int Kisi_ID { get; set; }
        public string Kisi_Name { get; set; }
        public string Kisi_Soyad { get; set; }
        public string Kisi_KulAd { get; set; }
        public string Kisi_Sifre { get; set; }

    }
}

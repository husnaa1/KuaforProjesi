
using System.ComponentModel.DataAnnotations;

namespace KuaforProjesi.Models
{
    public class YöneticiKisiler
    {
        [Key]
        public int YöneticiKisi_ID { get; set; }
        public string YöneticiKisi_Name { get; set; }

        public string YöneticiKisi_Soyad { get; set; }
        public string YöneticiKisi_KulAd { get; set; }
        public string YöneticiKisi_Sifre { get; set; }



    }
}

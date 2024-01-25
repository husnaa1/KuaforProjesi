using System.ComponentModel.DataAnnotations;

namespace KuaforProjesi.Models
{
    public class Yorum
    {
        [Key]
        public int Yorum_ID { get; set; }
        public string Yorum_Ad { get; set; }
        public string Yorum_Eposta { get; set; }
        public string Yorum_Konu { get; set; }
        public string Yorum_Mesaj { get; set; }

    }
}

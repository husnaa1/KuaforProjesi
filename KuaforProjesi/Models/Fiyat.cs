using System.ComponentModel.DataAnnotations;

namespace KuaforProjesi.Models
{
    public class Fiyat
    {

        [Key] 
        public int tbl_ID { get; set; }
        public string hizmet { get; set; }
        public string fiyat { get; set; }

   

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]  // kısıtlama kullanmak için
        public int AbautID { get; set; }

        [StringLength(1000)]
        public string AbautDetails1 { get; set; }

        [StringLength(1000)]
        public string AbautDetails2 { get; set; }

        [StringLength(100)]
        public string AbautImage1 { get; set; }

        [StringLength(100)]
        public string AbautImage2 { get; set; }
    }
}

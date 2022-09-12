using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace EntityLayer.Concrete
{
    public class Category
    {

        [Key]
        public int CatagoryID { get; set; }

        [StringLength(50)]
        public string CatagoryName { get; set; }

        [StringLength(250)]
        public string CatagoryDescription { get; set; }

        public bool CatagoryStatus { get; set; }

        public ICollection<Heading> Headings { get; set; }
    }
}

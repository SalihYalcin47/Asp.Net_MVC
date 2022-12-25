using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using profile.Models;

namespace profile.Models
{
    public class viewmodel
    {
        public IEnumerable<Yetenekler> yeteneklers { get; set; }
        public IEnumerable<Diller> dillers { get; set; }
    }
}
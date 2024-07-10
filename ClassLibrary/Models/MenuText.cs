using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class MenuText
    {
        public string MenuType { get; set; }
        public List<string> MenuOptions { get; set; }
        public Dictionary<string, string> MenuTexts { get; set; }


    }
}

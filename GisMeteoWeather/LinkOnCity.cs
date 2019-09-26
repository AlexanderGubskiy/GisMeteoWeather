using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GisMeteoWeather
{
    public class LinkOnCity
    {
        public string Href { get; set; }
        public string Name { get; set; }

        public LinkOnCity(string href, string name)
        {
            this.Href = href;
            this.Name = name;
        }
        public override string ToString()
        {
            return $"{Href} - {Name}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINALPROYEKT_1
{
    public class GmaileService
    {
        public GmaileService(string? gmail)
        {
            this.gmail = gmail;
        }

        public string? gmail { get; set; }

        public override string ToString()
        {
            return $"{gmail}";
        }
    }
}

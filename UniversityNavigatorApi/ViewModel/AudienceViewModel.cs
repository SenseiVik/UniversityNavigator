using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityNavigatorApi.ViewModel
{
    public class AudienceViewModel
    {
        public string AudienceId { get; set; }

        public int Floor { get; set; }

        public string Building { get; set; }

        public byte[] ImageBytes { get; set; }
    }
}

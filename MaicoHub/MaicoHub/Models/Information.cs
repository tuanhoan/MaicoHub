using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaicoHubAPI.Model
{
    public class Information
    {
        public int Id { get; set; }
        public string phoneNumber { get; set; }
        public string filePath { get; set; }
        public DateTime time { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportZone.Service.Models
{
    public class SessionInfo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public byte[] PictureData { get; set; }

    }
}

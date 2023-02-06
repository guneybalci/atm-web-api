using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    public class TokenOptions
    {
        // Kullanıcılar
        public string Audience { get; set; }
        // İmzalayan
        public string Issuer { get; set; }
        // Ne kadar aralığında kullanılacak
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}

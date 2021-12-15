using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Rock_paper_scissors {
    public class Hmac {
        public string hmacHex { get; }
        public Hmac(HmacKey hmacKey, string str) {
            string unionHmac = hmacKey.hmacKeyHex + str;
            byte[] result = SHA256.Create().ComputeHash(Encoding.Default.GetBytes(unionHmac));
            StringBuilder hmacHexBulder = new StringBuilder("");
            foreach (byte i in result) {
                hmacHexBulder.Append(i.ToString("X2"));
            }
            hmacHex = hmacHexBulder.ToString();
        }
    }
}

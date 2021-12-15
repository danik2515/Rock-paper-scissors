using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Rock_paper_scissors {
    public class HmacKey {
        public string hmacKeyHex { get; }
        private byte[] secretKey;
        public HmacKey(int b) {
            secretKey = new Byte[b];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider()) {
                rng.GetBytes(secretKey);
            }
            StringBuilder hmacKeyHexBulder = new StringBuilder("");
            foreach (byte i in secretKey) {
                hmacKeyHexBulder.Append(i.ToString("X2"));
            }
            hmacKeyHex = hmacKeyHexBulder.ToString();
        }

    }

}

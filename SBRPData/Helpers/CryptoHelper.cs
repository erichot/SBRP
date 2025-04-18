using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Security.Cryptography;

using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;


namespace SBRPData.Helpers
{
    public class CryptoHelper
    {

        //private const string m_AesKey = "1qazxsw23edcvfr4"; //密鑰(16 byte)
        private const string m_AesKey = "1qazxsw23edcvfr41qazxsw23edcvfr4"; //密鑰(16 byte)
        private const string m_AesIv = "4rfvcde32wsxzaq1"; //密鑰向量(16 byte)

        private class DesKeyIV
        {
            public Byte[] Key = new Byte[8];
            public Byte[] IV = new Byte[8];
            public DesKeyIV(string strKey)
            {
                var sha = new Sha1Digest();
                var hash = new byte[sha.GetDigestSize()];
                var data = Encoding.ASCII.GetBytes(strKey);
                sha.BlockUpdate(data, 0, data.Length);
                sha.DoFinal(hash, 0);
                for (int i = 0; i < 8; i++) Key[i] = hash[i];
                for (int i = 8; i < 16; i++) IV[i - 8] = hash[i];
            }
        }







        public static string DesEncrypt(string rawString)
        {
            return DesEncrypt(m_AesKey, rawString);
        }

        public static string DesEncrypt(string key, string rawString)
        {
            if (rawString.Length > 92160)
                return "Error. Data String too large. Keep within 90Kb.";
            var keyIv = new DesKeyIV(key);
            // var engine = new DesEngine();
            // new PaddedBufferedBlockCipher(new CbcBlockCipher(engine));
            var cipher = CipherUtilities.GetCipher("DES/CBC/PKCS5Padding");
            cipher.Init(true, new ParametersWithIV(new KeyParameter(keyIv.Key), keyIv.IV));
            var rbData = UnicodeEncoding.Unicode.GetBytes(rawString);
            return Convert.ToBase64String(cipher.DoFinal(rbData));
        }


        public static string DesDecrypt(string encString)
        {
            return DesDecrypt(m_AesKey, encString); 
        }
        public static string DesDecrypt(string key, string encString)
        {
            if (string.IsNullOrEmpty(encString)) return "ERROR: EncString is NULL!";
            var keyIv = new DesKeyIV(key);
            var cipher = CipherUtilities.GetCipher("DES/CBC/PKCS5Padding");
            cipher.Init(false, new ParametersWithIV(new KeyParameter(keyIv.Key), keyIv.IV));
            var encData = Convert.FromBase64String(encString);
            return Encoding.Unicode.GetString(cipher.DoFinal(encData));
        }


        private class AesKeyIV
        {
            public Byte[] Key = new Byte[16];
            public Byte[] IV = new Byte[16];
            public AesKeyIV(string strKey)
            {
                var sha = new Sha256Digest();
                var hash = new byte[sha.GetDigestSize()];
                var data = Encoding.ASCII.GetBytes(strKey);
                sha.BlockUpdate(data, 0, data.Length);
                sha.DoFinal(hash, 0);
                Array.Copy(hash, 0, Key, 0, 16);
                Array.Copy(hash, 16, IV, 0, 16);
            }
        }


        public static string AesEncrypt( string rawString)
        {
            return AesEncrypt(m_AesKey, rawString);
        }
        //REF: https://kashifsoofi.github.io/cryptography/aes-in-csharp-using-bouncycastle/
        public static string AesEncrypt(string key, string rawString)
        {
            var keyIv = new AesKeyIV(key);
            // Default - AES/GCM/NoPadding、System.Security.AES - AES/CBC/PKCS7
            var cipher = CipherUtilities.GetCipher("AES/CBC/PKCS7");
            cipher.Init(true, new ParametersWithIV(new KeyParameter(keyIv.Key), keyIv.IV));
            var rawData = Encoding.UTF8.GetBytes(rawString);
            return Convert.ToBase64String(cipher.DoFinal(rawData));
        }

        public static string AesDecrypt(string encString)
        {
            return AesDecrypt(m_AesKey, encString);
        }
        public static string AesDecrypt(string key, string encString)
        {
            var keyIv = new AesKeyIV(key);
            // Default - AES/GCM/NoPadding、System.Security.AES - AES/CBC/PKCS7
            var cipher = CipherUtilities.GetCipher("AES/CBC/PKCS7");
            cipher.Init(false, new ParametersWithIV(new KeyParameter(keyIv.Key), keyIv.IV));
            var encData = Convert.FromBase64String(encString);
            return Encoding.UTF8.GetString(cipher.DoFinal(encData));
        }



    }
}

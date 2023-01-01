using System.Security.Cryptography;
using System.Text;
using ShortUrlApi.Interfaces;

namespace ShortUrl.Implementations
{
    public class SecretHasher : ISecretHasher
    {
        private const int _saltSize = 16; // 128 bits
        private const int _keySize = 32; // 256 bits
        private const int _iterations = 100000;
        private static readonly HashAlgorithmName _algorithm = HashAlgorithmName.SHA256;
        private const char segmentDelimiter = ':';


        public byte [] Hash(string secret)
        {
    
            var salt = RandomNumberGenerator.GetBytes(_saltSize);
            var key = Rfc2898DeriveBytes.Pbkdf2(
                secret,
                salt,
                _iterations,
                _algorithm,
                _keySize
            );
            string temp = string.Join(
                segmentDelimiter,
                Convert.ToHexString(key),
                Convert.ToHexString(salt),
                _iterations,
                _algorithm
            );          

              return Encoding.ASCII.GetBytes(temp);

        }

        public bool Verify(string secret, byte [] hash)
        {
             
            var segments = System.Text.Encoding.ASCII.GetString(hash).Split(segmentDelimiter);
            var key = Convert.FromHexString(segments[0]);
            var salt = Convert.FromHexString(segments[1]);
            var iterations = int.Parse(segments[2]);
            var algorithm = new HashAlgorithmName(segments[3]);
            var inputSecretKey = Rfc2898DeriveBytes.Pbkdf2(
                secret,
                salt,
                iterations,
                algorithm,
                key.Length
            );

            return key.SequenceEqual(inputSecretKey);
        }
    }
}
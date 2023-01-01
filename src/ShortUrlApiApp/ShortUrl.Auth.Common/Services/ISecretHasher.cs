namespace ShortUrlApi.Interfaces
{
    public interface ISecretHasher
    {
        public byte[] Hash(string secret);
        public bool Verify(string secret, byte[] hash);
    }
}

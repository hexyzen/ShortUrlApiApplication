using System.ComponentModel.DataAnnotations;

namespace ShortUrlApi
{
    public class Link
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Linkfull { get; set; } = string.Empty;

        [StringLength(100)]
        public string LinkCut { get; set; } = string.Empty;

    }
}

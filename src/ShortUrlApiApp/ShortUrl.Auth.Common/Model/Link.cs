using System.ComponentModel.DataAnnotations;

namespace ShortUrlApi.Model
{
    public class Link
    {
        [MaxLength(5)]
        public int LinkId { get; set; }

        [StringLength(200)]
        public string Linkfull { get; set; } = string.Empty;

        [StringLength(100)]
        public string LinkCut { get; set; } = string.Empty;

    }
}

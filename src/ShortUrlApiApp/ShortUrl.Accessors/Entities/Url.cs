﻿namespace ShortUrl.Accessors.Entities
{
    public class Url
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortUrl { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public Url()
        {
            CreatedDate = DateTime.Now;
        }
    }

}

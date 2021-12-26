using System;
using System.ComponentModel.DataAnnotations;

namespace reserreadingbe.Common
{
    public class Story
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
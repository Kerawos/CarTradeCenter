using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarTradeCenter.Data
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }

        public Image(string url)
        {
            Url = url;
        }

    }
}

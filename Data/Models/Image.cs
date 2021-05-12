using System.ComponentModel.DataAnnotations;


namespace CarTradeCenter.Data.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public Image(string url)
        {
            Url = url;
        }

    }
}

using System.ComponentModel.DataAnnotations;


namespace CatCards.Models
{
    public class CatCard
    {
        public int CatCardId { get; set; }
        [Required]
        public string CatFact { get; set; }
        [Required]
        public string ImgUrl { get; set; }

        public string Caption { get; set; }

        public CatCard() { }

        public CatCard(CatFact catFact, CatPic catPic)
        {
            this.CatFact = catFact.Text;
            this.ImgUrl = catPic.File;
        }
    }
}
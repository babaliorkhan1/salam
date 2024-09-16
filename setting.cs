using System.ComponentModel.DataAnnotations.Schema;

namespace Doggie.Modelsss
{
    public class setting:BaseModel
    {
        public string Title { get; set; }
        public string Title2 { get; set; }
        public string Description { get; set; }

      public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string CourseTitle { get; set; } 
        public string CourseDescription { get; set; } 
        public string EventTitle { get; set; } 
        public string EventDescription { get; set; }
        public string CommentTitle { get; set; }
        public string CommentDescription { get; set; }
        public string FacebookLink { get; set; }
        public string LinkendLink { get; set; }
        public string GoogleLink { get; set; }


        [NotMapped]
        public IFormFile formFile { get; set; }
        [NotMapped]
        public IFormFile formFile2 { get; set; }






    }
}

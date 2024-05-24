using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PageDrift.Models
{
    public class Books
    {
        [Key]
        public int BookId {  get; set; }

        
        [Required(ErrorMessage ="Can not leave Empty !")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Can not leave Empty !")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Can not leave Empty !")]
        public string Author { get; set; }
        
        public string Publication { get; set; }
        [DisplayName("Publication Year")]
        public DateTime PublicationYear { get; set; }
        [DisplayName("ISBN No.")]
        public string ISBNNo { get; set; }
        [Required(ErrorMessage = "Please Select Image")]
        [DisplayName("Image")]
        public string Img { get; set; }
        [Required(ErrorMessage = "Please Select Book in PDF Formate")]
        public string File { get; set;}

    }
}
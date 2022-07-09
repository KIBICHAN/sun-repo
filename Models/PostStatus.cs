using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartRent.Models;

public class PostStatus{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PostStatusId{get; set;}
    [StringLength(12)]
    public string StatusDescription{get; set;} = string.Empty;

    //One-to-Many Relationship
    public List<Post>? Posts {get; set;}
    //------------------------
}
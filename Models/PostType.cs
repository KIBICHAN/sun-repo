using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartRent.Models;

public class PostType{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PostTypeId{get; set;}
    [StringLength(12)]
    public string TypeDescription{get; set;} = string.Empty;

    //One-to-Many Relationship
    public List<Post>? Posts {get; set;}
    //------------------------
}
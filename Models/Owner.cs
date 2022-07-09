using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartRent.Models;

public class Owner{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OwnerId{get; set;}
    [StringLength(20)]
    [Required]
    public string Name{get; set;} = string.Empty;
    [StringLength(20)]
    [Required]
    public string Phone{get; set;} = string.Empty;
    [StringLength(20)]
    [Required]
    public string Email{get; set;} = string.Empty;
    [MaxLength]
    public string OwnerImgUrl{get; set;} = string.Empty;
    
    //One-to-Many Relationship
    public List<Post>? Posts {get; set;}
    //------------------------
}
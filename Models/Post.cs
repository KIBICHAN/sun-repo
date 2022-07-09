using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartRent.Models;

public class Post{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PostId {get; set;}
    [Required]
    [StringLength(200)]
    public string Title {get; set;} = string.Empty;
    [Required]
    public float Price {get; set;}
    [Required]
    [MaxLength]
    public string Description  {get; set;} = string.Empty;
    [Required]
    [DataType(DataType.Date)]
    public DateTime DateCreate {get; set;}

    // One-to-One Relationship
    public Apartment? Apartment {get; set;}
    public int ApartmentId {get; set;}
    //------------------------

    //One-to-Many Relationship
    public PostStatus? PostStatus {get; set;}
    public int PostStatusId {get; set;}

    public PostType? PostType {get; set;}
    public int PostTypeId {get; set;}

    public Owner? Owner {get; set;}
    public int OwnerId {get; set;}
    //------------------------

}
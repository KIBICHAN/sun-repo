using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartRent.Models;

public class Apartment{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ApartmentId{get; set;}
    [Required]
    public float Area{get; set;}
    [Required]
    public int NumberOfBedroom{get; set;}
    [Required]
    public int NumberOfBathroom{get; set;}
    [Required]
    [StringLength(17)]
    public string HouseDirection{get; set;} = string.Empty; 
    [Required]
    [StringLength(17)]
    public string BalconyDirection{get; set;} = string.Empty; 
    [Required]
    [StringLength(30)]
    public string LegalInformation{get; set;} = string.Empty; 
    [Required]
    [StringLength(200)]
    public string ApartmentImgUrl {get; set;} = string.Empty;

    //One-to-One Relationship
    public Post? Post {get; set;}
    //------------------------

    //One-to-Many Relationship
    public Building? Building {get; set;}
    public int BuildingId {get; set;}
    //------------------------
}
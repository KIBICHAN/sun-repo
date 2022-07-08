using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartRent.Models;

public class Building{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BuildingId{get; set;}
    [StringLength(25)]
    [Required]
    public string BuildingName{get; set;} = string.Empty;
    [StringLength(25)]
    [Required]
    public string CorporationName{get; set;} = string.Empty;
    [StringLength(100)]
    [Required]
    public string Location{get; set;} = string.Empty;
    [StringLength(200)]
    [Required]
    public string LocationImgUrl{get; set;} = string.Empty;
    [StringLength(300)]
    [Required]
    public string BuildingImgUrl{get; set;} = string.Empty;

    //One-to-Many Relationship
    public List<Apartment>? Apartments {get; set;}
    //------------------------
}
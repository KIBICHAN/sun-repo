using System.ComponentModel.DataAnnotations;

namespace ApartRent.Models;

public class CreatePost{
    public string Title {get; set;} = string.Empty;
    public float Price {get; set;}
    public string Description  {get; set;} = string.Empty;
    public DateTime DateCreate {get; set;}
    public int PostStatusId {get; set;}
    public int PostTypeId {get; set;}
    public float Area{get; set;}
    public int NumberOfBedroom{get; set;}
    public int NumberOfBathroom{get; set;}
    public string HouseDirection{get; set;} = string.Empty;
    public string BalconyDirection{get; set;} = string.Empty;
    public string LegalInformation{get; set;} = string.Empty;
    public string ApartmentImgUrl {get; set;} = string.Empty;
    public int BuildingId {get; set;}
    public string Name{get; set;} = string.Empty;
    public string Phone{get; set;} = string.Empty;
    public string Email{get; set;} = string.Empty;
}
using ApartRent.Models;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace ApartRent.Data;
public class DataContext : DbContext{
    public DataContext(DbContextOptions<DataContext> options) : base(options){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<PostStatus>().HasData(
            new PostStatus {PostStatusId = 1, StatusDescription = "Active"},
            new PostStatus {PostStatusId = 2, StatusDescription = "Waiting"},
            new PostStatus {PostStatusId = 3, StatusDescription = "Draft"},
            new PostStatus {PostStatusId = 4, StatusDescription = "Deactivate"}
        );

        modelBuilder.Entity<PostType>().HasData(
            new PostType {PostTypeId = 1, TypeDescription = "For rent"},
            new PostType {PostTypeId = 2, TypeDescription = "For selling"}
        );

        modelBuilder.Entity<Owner>().HasData(
            new Owner {OwnerId = 1, Name = "이상혁", Phone = "2022112119", Email = "Lee Sang-hyeok@mail", OwnerImgUrl = "https://static.wikia.nocookie.net/lolesports_gamepedia_en/images/7/78/T1logo_profile.png/revision/latest/scale-to-width-down/220?cb=20210402012553"}
        );
    }

    public DbSet<PostStatus> PostStatuses {get; set;}
    public DbSet<PostType> PostTypes {get; set;}
    public DbSet<Owner> Owners {get; set;}
    public DbSet<Building> Buildings {get; set;}
    public DbSet<Apartment> Apartments {get; set;}
    public DbSet<Post> Posts {get; set;}
}
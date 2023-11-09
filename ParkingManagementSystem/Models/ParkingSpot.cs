using System.ComponentModel.DataAnnotations;

namespace ParkingManagementSystem.Models;

public class ParkingSpot
{   
    [Key]
    public long ParkingSpotId { get; set; }
    public string CompanyName { get; set; } 
    public double Latitude { get; set; } 
    public double Longitude { get; set; } 
    public string Location { get; set; } 
    public double TotalSpaceInSquareFeet { get; set; } 
    public double AvailableSpaceInSquareFeet { get; set; }
}

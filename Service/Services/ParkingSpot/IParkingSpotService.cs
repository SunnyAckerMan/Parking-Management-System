namespace Service.Services.ParkingSpot;

public interface IParkingSpotService
{
    bool Create(VmParkingSpot model);
    bool Update(VmParkingSpot model);
    bool Delete(long id);
    List<VmParkingSpot> GetAll();
    VmParkingSpot GetById(long id);
}

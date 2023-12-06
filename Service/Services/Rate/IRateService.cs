namespace Service.Services.Rate;

public interface IRateService
{
    bool Create(VmRate model);
    bool Update(VmRate model);
    bool Delete(long id);
    List<VmRate> GetAll();
    VmRate GetById(long id);
}

namespace Entity.Models;

public abstract class BaseEntity
{
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public DateTime? UpdateDate { get; set; }
    public string CreatedBy { get; set; } = "Admin";
    public string UpdatedBy { get; set; } = "Admin";
    public bool IsArchived { get; set; } = false;
}

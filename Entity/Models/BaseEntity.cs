namespace Entity.Models;

public abstract class BaseEntity
{
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public DateTime? UpdateDate { get; set; }
    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
    public bool IsArchived { get; set; } = false;
}

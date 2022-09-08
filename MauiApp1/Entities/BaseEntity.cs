
namespace MauiApp1.Entities;

public class BaseEntity
{
    public Guid Id {get; set; }
    public DateTime systemCreationDate { get; set; }
    public Guid? tenantId { get; set; }

    public bool? lastState { get; set; }
    public bool isArchived { get; set; }
    public int displayOrder { get; set; }
    public bool isSelected { get; set; }
    public int displayIndex { get; set; }
    public bool isHovered { get; set; }
}

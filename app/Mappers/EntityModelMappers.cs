using app.Entities;
using app.ViewModels;

namespace app.Mappers;

public static class EntityModelMappers
{
    public static QueuesViewModel ToModel(this List<Queue> entity)
    {
        return new QueuesViewModel() 
        {
            Queues = entity.Select(i => 
            {
                return new QueueViewModel()
                {
                    Id = i.Id,
                    CustomerName = i.CustomerName,
                    Phone = i.Phone,
                    CreatedAt = i.CreatedAt,
                    ModifiedAt = i.ModifiedAt,
                    QueueTime = i.QueueTime,
                    IsActive = i.IsActive
                };
            }).ToList()
        };
    }
    public static QueueViewModel ToModel(this Queue entity)
    {
        return new QueueViewModel()
        {
            Id = entity.Id,
            CustomerName = entity.CustomerName,
            Phone = entity.Phone,
            CreatedAt = entity.CreatedAt,
            ModifiedAt = entity.ModifiedAt,
            QueueTime = entity.QueueTime,
            IsActive = entity.IsActive
        };
    }
}
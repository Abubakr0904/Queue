using System.ComponentModel.DataAnnotations;

namespace app.Entities;

public class Queue
{
    [Key]
    public Guid Id { get; set; }

    [Required, MinLength(6)]
    public string CustomerName { get; set; }

    [Required]
    public string Phone { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset ModifiedAt{ get; set; }

    public DateTimeOffset QueueTime{ get; set; }

    public bool IsActive { get; set; }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace app.ViewModels;

public class QueueViewModel
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Ism sharifingizni kiritish shart!"), MinLength(6)]
    [DisplayName("Ism Sharifingiz")]
    public string CustomerName { get; set; }

    [Required(ErrorMessage = "Telefon raqam kiritish shart!")]
    [RegularExpression(
        @"^[\+]?(998[-\s\.]?)([0-9]{2}[-\s\.]?)([0-9]{3}[-\s\.]?)([0-9]{2}[-\s\.]?)([0-9]{2}[-\s\.]?)$", 
        ErrorMessage = "Telefon raqam formati noto'g'ri.")]
    [DisplayName("Telefon raqam")]
    public string Phone { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset ModifiedAt{ get; set; }

    public DateTimeOffset QueueTime{ get; set; }

    public bool IsActive { get; set; }
}
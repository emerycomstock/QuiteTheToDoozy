using System.ComponentModel.DataAnnotations;
using ToDoozy.Server.Common.Enums;

public class UpdateToDoRequest
{
    [StringLength(256, MinimumLength = 1)]
    public string? Title { get; set; }

    [StringLength(2048, MinimumLength = 1)]
    public string? Description { get; set; }

    [EnumDataType(typeof(ToDoStatus), ErrorMessage = "Invalid status provided.")]
    public ToDoStatus? Status { get; set; }
}
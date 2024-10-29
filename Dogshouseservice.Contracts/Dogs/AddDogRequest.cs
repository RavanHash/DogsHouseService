using System.ComponentModel.DataAnnotations;

namespace Dogshouseservice.Contracts.Dogs;

public record AddDogRequest(
    [Required]
    string Name,
    
    [Required]
    string Color,
    
    [Required]
    int TailLength,
    
    [Required]
    int Weight);
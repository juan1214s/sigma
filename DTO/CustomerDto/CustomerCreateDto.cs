using System.ComponentModel.DataAnnotations;
using technical_test_sigma.DTO.AddressDto;
using technical_test_sigma.DTO.PayDto;

public class CustomerCreateDto
{
    [Required]
    public string Name { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Phone { get; set; }

    [Required]
    public AddressDto Address { get; set; }

    [Required]
    public PayDto Pay { get; set; }
}

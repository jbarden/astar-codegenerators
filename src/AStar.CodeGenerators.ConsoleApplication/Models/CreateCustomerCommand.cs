using AStar.CodeGenerators;

namespace ConsoleApplication.Models;

[GenerateToString]
public partial class CreateCustomerCommand
{
    public string Name { get; set; } = string.Empty;
    public required string Email { get; set; } = string.Empty;
    public required string PhoneNumber { get; set; } = string.Empty;
    public required string City { get; set; } = string.Empty;
    public required string Region { get; set; } = string.Empty;
    public required string Country { get; set; } = string.Empty;
    public required string PostOrZipCode { get; set; } = string.Empty;
    public string MaskedProperty { get; set; } = "A long string to confirm masking... Hope it works.";
    public string RedactedProperty { get; set; } = "A long string to confirm redacting... Hope it works.";
    public string IgnoredProperty { get; set; } = "A long string to confirm ignoring... Hope it works.";
}

using Microsoft.CodeAnalysis;

namespace AStar.CodeGenerators.Models;

internal class PropertyDetails
{
    public string PropertyName { get; set; } = string.Empty;

    public IEnumerable<AttributeData> Attributes { get; set; } = Enumerable.Empty<AttributeData>();
}

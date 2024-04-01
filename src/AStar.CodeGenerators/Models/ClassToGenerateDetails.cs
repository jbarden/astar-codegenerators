using Microsoft.CodeAnalysis;

namespace AStar.CodeGenerators.Models;
internal class ClassToGenerateDetails
{
    private readonly IList<AttributeData> attributesData = [];
    private readonly IList<string> propertyNames = [];

    public IEnumerable<AttributeData> AttributesData => attributesData;

    public string NamespaceName { get; internal set; } = "NotSpecified";
    public string ClassName { get; internal set; } = "NotSpecified";
    public IEnumerable<string> PropertyNames => propertyNames;

    public void AddAttributeDate(AttributeData attributeData) => attributesData.Add(attributeData);
    public void AddPropertyName(string propertyName) => propertyNames.Add(propertyName);
}

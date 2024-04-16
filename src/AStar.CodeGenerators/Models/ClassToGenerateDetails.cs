namespace AStar.CodeGenerators.Models;

internal class ClassToGenerateDetails
{
    private readonly IList<PropertyDetails> propertyDetails = [];

    public string NamespaceName { get; internal set; } = "NotSpecified";

    public string ClassName { get; internal set; } = "NotSpecified";

    public IEnumerable<PropertyDetails> PropertyDetails => propertyDetails;

    public void AddPropertyDetails(PropertyDetails propertyDetails) => this.propertyDetails.Add(propertyDetails);
}

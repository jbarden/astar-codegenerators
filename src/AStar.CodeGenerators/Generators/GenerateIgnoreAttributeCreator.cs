using Microsoft.CodeAnalysis;

namespace AStar.CodeGenerators.Generators;
internal static class GenerateIgnoreAttributeCreator
{
    public static void PostInitializationOutput(IncrementalGeneratorPostInitializationContext context)
    {
        context.AddSource($"{Constants.NamespaceName}.IgnoreAttribute.g.cs",
$@"namespace {Constants.NamespaceName};

/// <summary>
/// The Ignore attribute is intended to mark a property that should not be included in the overridden ToString().
/// <para>
/// Simply add this attribute to any property you do not want to see in the ToString output.
/// </para>
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Property, Inherited = false)]
internal sealed class IgnoreAttribute : System.Attribute {{ }}");
    }
}

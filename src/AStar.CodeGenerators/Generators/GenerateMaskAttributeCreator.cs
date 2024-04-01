using Microsoft.CodeAnalysis;

namespace AStar.CodeGenerators.Generators;
internal static class GenerateMaskAttributeCreator
{
    public static void PostInitializationOutput(IncrementalGeneratorPostInitializationContext context)
    {
        context.AddSource($"{Constants.NamespaceName}.MaskAttribute.g.cs",
$@"namespace {Constants.NamespaceName};

/// <summary>
/// The Mask attribute is intended to mark a property that should be masked in the overridden ToString().
/// <para>
/// Simply add this attribute to any property you want to see in the ToString output, with the applicable masking applied.
/// </para>
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Property, Inherited = false)]
internal sealed class MaskAttribute : System.Attribute {{ }}");
    }
}

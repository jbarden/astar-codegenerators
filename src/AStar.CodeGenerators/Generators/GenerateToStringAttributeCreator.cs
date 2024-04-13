using Microsoft.CodeAnalysis;

namespace AStar.CodeGenerators.Generators;

internal static class GenerateToStringAttributeCreator
{
    public static void PostInitializationOutput(IncrementalGeneratorPostInitializationContext context)
        => context.AddSource($"{Constants.NamespaceName}.GenerateToStringAttribute.g.cs",
$@"namespace {Constants.NamespaceName};

/// <summary>
/// The GenerateToString attribute is intended to be used on classes to simplify creating, as you would expect, the overridden ToString() method.
/// <para>
/// There are additional attributes to allow for Redacting, Masking or Ignoring specific properties. Any public property without one of these attributes applied will be included, in full, in the ToString output.
/// </para>
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false)]
public sealed class GenerateToStringAttribute : System.Attribute {{ }}");
}

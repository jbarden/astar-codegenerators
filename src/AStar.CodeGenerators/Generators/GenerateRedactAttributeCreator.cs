using Microsoft.CodeAnalysis;

namespace AStar.CodeGenerators.Generators;

internal static class GenerateRedactAttributeCreator
{
    public static void PostInitializationOutput(IncrementalGeneratorPostInitializationContext context)
        => context.AddSource($"{Constants.NamespaceName}.RedactAttribute.g.cs",
$@"namespace {Constants.NamespaceName};

/// <summary>
/// The Redact attribute is intended to mark a property that should be redacted in the overridden ToString().
/// <para>
/// Simply add this attribute to any property you want to see in the ToString output, with the value replaced by 'Redacted'.
/// </para>
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Property, Inherited = false)]
public sealed class RedactAttribute : System.Attribute {{ }}");
}

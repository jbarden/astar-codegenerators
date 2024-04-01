using Microsoft.CodeAnalysis;

namespace AStar.CodeGenerators.Generators;

[Generator]
internal class ToString : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context) =>
        context.RegisterPostInitializationOutput(
            static (context) => PostInitializationOutput(context));

    private static void PostInitializationOutput(
        IncrementalGeneratorPostInitializationContext context)
    {
        context.AddSource("AStar.CodeGenerators.GenerateToStringAttribute.g.cs",
@"namespace AStar.CodeGenerators;

/// <summary>
/// The GenerateToString attribute is inteaded to be used on classes to simplify creating, as you would expect, the overridden ToString() method.
/// <para>
/// There will be additional attributes created shortly that will allow for Redacting, Masking or Ignoring specific properties. Any public property without one of these attributes will be included in the ToString output.
/// </para>
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false)]
internal sealed class GenerateToStringAttribute : System.Attribute { }");
    }
}

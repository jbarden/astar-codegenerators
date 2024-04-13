using System.Text;
using AStar.CodeGenerators.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AStar.CodeGenerators.Generators;

[Generator]
internal class GenerateToStringAttribute : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var classes = context.SyntaxProvider.CreateSyntaxProvider(
            predicate: static (node, _) => IsSyntaxTarget(node),
            transform: static (ctx, _) => GetSemanticTarget(ctx))
            .Where(static (target) => target is not null);

        context.RegisterSourceOutput(classes,
            static (context, classToGenerateDetails) => GenerateCode(context, classToGenerateDetails));

        context.RegisterPostInitializationOutput(
            static (context) => PostInitializationOutput(context));
    }

    private static void GenerateCode(SourceProductionContext context, ClassToGenerateDetails classToGenerateDetails)
    {
        var namespaceName = classToGenerateDetails.NamespaceName;
        var className = classToGenerateDetails.ClassName;
        var fileName = $"{namespaceName}.{className}.g.cs";

        var stringBuilder = new StringBuilder();
        _ = stringBuilder.Append($@"namespace {namespaceName}
{{
    partial class {className}
    {{
        public override string ToString()
        {{
            return $""");

        var first = true;
        foreach(var propertyName in classToGenerateDetails.PropertyNames)
        {
            if(first)
            {
                first = false;
            }
            else
            {
                _ = stringBuilder.Append("; ");
            }

            _ = stringBuilder.Append($"{propertyName}:{{{propertyName}}}");
        }

        _ = stringBuilder.Append($@""";
        }}
    }}
}}
");
        if (!fileName.Contains("NotSpecified", StringComparison.OrdinalIgnoreCase))
        {
            context.AddSource(fileName, stringBuilder.ToString());
        }
    }

    private static bool IsSyntaxTarget(SyntaxNode node)
        => node is ClassDeclarationSyntax classDeclarationSyntax && classDeclarationSyntax.AttributeLists.Count > 0;

    private static ClassToGenerateDetails GetSemanticTarget(GeneratorSyntaxContext context)
    {
        ClassToGenerateDetails details = new();
        var classDeclarationSyntax = (ClassDeclarationSyntax)context.Node;
        var classSymbol = (INamedTypeSymbol)context.SemanticModel.GetDeclaredSymbol(classDeclarationSyntax);
        var attributeSymbol = context.SemanticModel.Compilation.GetTypeByMetadataName($"{Constants.NamespaceName}.GenerateToStringAttribute");

        if(classSymbol is not null && attributeSymbol is not null)
        {
            foreach(var attributeData in classSymbol.GetAttributes())
            {
                if(attributeSymbol.Equals(attributeData.AttributeClass, SymbolEqualityComparer.Default))
                {
                    details.NamespaceName = classSymbol.ContainingNamespace.ToDisplayString();
                    details.ClassName = classSymbol.Name;

                    foreach(var memberSymbol in classSymbol.GetMembers())
                    {
                        if(memberSymbol.Kind == SymbolKind.Property && memberSymbol.DeclaredAccessibility == Accessibility.Public)
                        {
                            details.AddPropertyName(memberSymbol.Name);
                        }
                    }
                }
            }
        }

        return details;
    }

    private static void PostInitializationOutput(IncrementalGeneratorPostInitializationContext context)
        => GenerateToStringAttributeCreator.PostInitializationOutput(context);
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;

namespace AStar.CodeGenerators.Generators;

internal class GenerateMaskAttribute : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
        => context.RegisterPostInitializationOutput(static (context) => PostInitializationOutput(context));

    private static void PostInitializationOutput(IncrementalGeneratorPostInitializationContext context)
        => GenerateMaskAttributeCreator.PostInitializationOutput(context);
}

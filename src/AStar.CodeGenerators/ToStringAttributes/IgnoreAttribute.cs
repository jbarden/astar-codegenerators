using System;
using System.Collections.Generic;
using System.Text;

namespace AStar.CodeGenerators.ToStringAttributes;

/// <summary>
/// The Ignore attribute is intended to mark a property that should not be included in the overridden ToString().
/// <para>
/// Simply add this attribute to any property you do not want to see in the ToString output.
/// </para>
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Property, Inherited = false)]
public sealed class IgnoreAttribute : System.Attribute
{
}

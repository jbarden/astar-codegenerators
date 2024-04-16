using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AStar.CodeGenerators;

namespace ConsoleApplication.Models;

[GenerateToString]
public partial class Address
{
    public string Name { get; set; } = "why would an address have a name???";

    public int Id { get; set; } = -666;
}

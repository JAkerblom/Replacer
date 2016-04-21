using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replacer.Rules
{
  /// <summary>
  ///  Append rule implementation with the abstract class Rule as implementation parent
  /// </summary>
  public class AppendRule : Rule
  {
    public int Id { get; set; }
    public string BaseChunk { get; set; }
    public string AppendChunk { get; set; }
    //public string[] RuleUsage = new string[] { "Lägga till", "till" };

    //public override void Manipulate(ref string textContents)
    public override string Manipulate(string textContents)
    {
      Console.WriteLine("Texten manipuleras enligt: Slå ihop \"" + BaseChunk + "\" med \"" + AppendChunk + "\".");
      return textContents.Replace(BaseChunk, BaseChunk + AppendChunk);
    }
  }
}

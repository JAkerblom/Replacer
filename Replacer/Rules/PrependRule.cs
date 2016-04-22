using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replacer.Rules
{
  /// <summary>
  ///  Prepend rule implementation with the abstract class Rule as implementation parent
  ///  -> Should prepend one word before another.
  /// </summary>
  class PrependRule : Rule
  {
    public int Id { get; set; }
    public string BaseChunk { get; set; }
    public string PrependChunk { get; set; }

    public override string Manipulate(string textContents)
    {
      Console.WriteLine(" -> Texten manipuleras enligt: Slå ihop \"" + PrependChunk + "\" med \"" + BaseChunk + "\".");
      return textContents.Replace(BaseChunk, PrependChunk + BaseChunk);
    }

    public override string ToString()
    {
      return "\"" + BaseChunk + "\" och \"" + PrependChunk + "\"";
    }
  }
}

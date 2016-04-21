using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Replacer.Rules
{
  /// <summary>
  ///  Replace rule implementation with the abstract class Rule as implementation parent
  /// </summary>
  public class ReplaceRule : Rule
  {
    public int Id { get; set; }
    public string OldChunk { get; set; }
    public string NewChunk { get; set; }
    //public string[] RuleUsage = new string[] { "Byta ut ", " mot " };

    //public override void Manipulate(ref string textContents)
    public override string Manipulate(string textContents)
    {
      //Console.WriteLine("Texten manipuleras enligt: " + RuleUsage[0] + OldChunk + RuleUsage[1] + NewChunk + ".");
      Console.WriteLine("Texten manipuleras enligt: Byta ut \"" + OldChunk + "\" mot \"" + NewChunk + "\".");
      return textContents.Replace(OldChunk, NewChunk);
    }
  }

  /// <summary>
  ///  Replace rule implementation with constructor and generic class implication
  /// </summary>
  //public class ReplaceRule : IRule<ReplaceRule>
  //{
  //  [JsonProperty("OldChunk")]
  //  public string OldChunk { get; set; }
  //  [JsonProperty("NewChunk")]
  //  public string NewChunk { get; set; }

  //  public ReplaceRule(string oldChunk, string newChunk)
  //  {
  //    OldChunk = oldChunk;
  //    NewChunk = newChunk;
  //  }
  //}

  /// <summary>
  ///  Replace rule implementation with just IRule interface
  /// </summary>
  //public class ReplaceRule : IRule
  //{
  //  [JsonProperty("OldChunk")]
  //  public string OldChunk { get; set; }
  //  [JsonProperty("NewChunk")]
  //  public string NewChunk { get; set; }
  //}
}

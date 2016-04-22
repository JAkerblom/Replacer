using Replacer.Data;
using System.Collections.Generic;

namespace Replacer.Runner
{
  public class TextManipulator
  {
    public TextManipulator()
    {
    }

    public string Manipulate(string textContents, List<RuleFixture> ruleFixtures)
    {
      string tmp = textContents;
      foreach (RuleFixture rf in ruleFixtures)
      {
        var rules = rf.Rules;
        var ruleType = rf.RuleType;

        foreach (var r in rules)
        {
          //r.Manipulate(ref tmp);
          tmp = r.Manipulate(tmp);
        }
      }
      return tmp;
    }
  }
}
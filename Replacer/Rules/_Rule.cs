using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replacer.Rules
{
  /// <summary>
  ///  The base rule
  /// </summary>
  public abstract class Rule
  {
    public string RuleType { get; set; }

    //public abstract void Manipulate(ref string textContents);
    public abstract string Manipulate(string textContents);
  }
}

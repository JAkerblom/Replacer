using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replacer
{
  //public interface IRule<T>
  public interface IRule
  {
    string RuleType { get; set; }

    void Manipulate(ref string textContents);
  }
}

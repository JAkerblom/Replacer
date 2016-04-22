using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Replacer.Rules;

namespace Replacer.Data
{
  //[JsonConverter(typeof(RuleConverter))]
  public class RuleFixture
  {
    /// <summary>
    ///  Implementation v.2: Towards getting json elements through ruletype.
    /// </summary>
    public string RuleType { get; set; }
    public List<Rule> Rules { get; set; }
  }
}

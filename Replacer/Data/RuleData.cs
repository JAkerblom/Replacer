using Newtonsoft.Json;
using System.Collections.Generic;

namespace Replacer.Data
{
  [JsonConverter(typeof(RuleConverter))]
  public class RuleData
  {
    public string[] ApprovedRuleTypes { get; set; }
    public List<RuleFixture> RuleFixtures { get; set; }
  }
}
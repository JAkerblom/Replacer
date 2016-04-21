using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replacer.Read
{
  public class RulesReader
  {

    public string _Path;
    Encoding _Enc;

    public RulesReader(string path)
    {
      _Path = path;
      _Enc = Encoding.Default;
    }

    public List<RuleFixture> ReadFromRulesRepository()
    {
      // The json(DB) way     
      List<RuleFixture> ruleFixtures;
      //using (StreamReader r = new StreamReader(@"C:\Users\JAkerblom\Documents\Visual Studio 2015\Projects\My_CIK_code\Replacer\rules.json.txt"))
      using (StreamReader r = new StreamReader(_Path, _Enc))
      {
        string readRulesContent = r.ReadToEnd();
        ruleFixtures = JsonConvert.DeserializeObject<List<RuleFixture>>(readRulesContent);
        //IDictionary<string, IRule<ReplaceRule>> ruleset = JsonConvert.DeserializeObject<Dictionary<string, IRule<T>>(readRules);
        //IDictionary<string, IRule> ruleset = RuleConverter.DeserializeObject<Dictionary<string, IRule>(readRules);
        //var ruleset = JsonConvert.DeserializeObject(readRules, );
        //var ruleset = JsonConvert.DeserializeObject<List<IDictionary<string, RuleFixture>>>(readRules);
        //var ruleset = JsonConvert.DeserializeObject<List<IDictionary<string, ReplaceRule>>>(readRules);
        //var ruleset = JsonConvert.DeserializeObject<IRule>(readRules, new RuleConverter());
      }
      return ruleFixtures;
    }
  }
}

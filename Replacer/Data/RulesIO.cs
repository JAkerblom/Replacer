using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Replacer.Rules;
using System;

namespace Replacer.Data
{
  public class RulesIO
  {

    public string _Path;
    Encoding _Enc;

    public RulesIO(string path)
    {
      _Path = path;
      _Enc = Encoding.UTF8;
    }

    public List<RuleFixture> GetRuleFixtures()
    {
      List<RuleFixture> ruleFixtures;
      using (StreamReader r = new StreamReader(_Path, _Enc, true))
      {
        string readRulesContent = r.ReadToEnd();
        //var ruleData = JsonConvert.DeserializeObject<List<RuleFixture>>(readRulesContent);
        var ruleData = JsonConvert.DeserializeObject<RuleData>(readRulesContent);
        ruleFixtures = ruleData.RuleFixtures;
      }

      return ruleFixtures;
    }

    public string[] GetApprovedRules()
    {
      string[] approvedRules;
      using (StreamReader r = new StreamReader(_Path, _Enc, true))
      {
        string readRulesContent = r.ReadToEnd();
        var ruleData = JsonConvert.DeserializeObject<RuleData>(readRulesContent);
        approvedRules = ruleData.ApprovedRuleTypes;
      }

      return approvedRules;
    }

    public List<RuleFixture> SaveRule(Rule newRule, List<RuleFixture> ruleFixtures, string[] approvedRuleTypes)
    {
      //ruleFixtures.Find(x => x.RuleType == newRule.RuleType).Rules.Add(newRule);
      var foundFixture = ruleFixtures.Find(x => x.RuleType == newRule.RuleType);
      if (foundFixture == null)
      {
        RuleFixture newRuleFixture =
          new RuleFixture()
          {
            RuleType = newRule.RuleType,
            Rules = new List<Rule>() { newRule }
          };
        ruleFixtures.Add(newRuleFixture);
      }

      //.Rules.Add(newRule);
      var newRuleDataAsJson = JsonConvert.SerializeObject(
        new RuleData()
        {
          ApprovedRuleTypes = approvedRuleTypes,
          RuleFixtures = ruleFixtures
        });

      File.WriteAllText(_Path, newRuleDataAsJson);

      return ruleFixtures;
    }

    //public Rule RequestNewRule(string ruleType, RuleFixture ruleFixture)
    public Rule RequestNewRule(string ruleType, List<RuleFixture> ruleFixtures)
    {
      var ruleFixture = ruleFixtures.Find(x => x.RuleType == ruleType);

      switch (ruleType)
      {
        case "replace":
          Console.WriteLine("\n Vilket är det ordet du vill byta ut?");
          var oldChunk = Console.ReadLine();
          Console.WriteLine("\n Vilket är ordet du vill byta ut med?");
          var newChunk = Console.ReadLine();
          return new ReplaceRule()
          {
            Id = (ruleFixture == null) ? 1 : ruleFixture.Rules.Count+1,
            RuleType = ruleType,
            OldChunk = oldChunk,
            NewChunk = newChunk
          };
        //break;
        case "append":
          Console.WriteLine("\n Vilket är det ordet du vill lägga till ett ord intill?");
          var baseChunk = Console.ReadLine();
          Console.WriteLine("\n Vilket är ordet du vill lägga till med?");
          var appendChunk = Console.ReadLine();
          return new AppendRule()
          {
            Id = (ruleFixture == null) ? 1 : ruleFixture.Rules.Count+1,
            RuleType = ruleType,
            BaseChunk = baseChunk,
            AppendChunk = appendChunk
          };
        //break;
        case "prepend":
          Console.WriteLine("\n Vilket är det ordet du vill lägga till ett ord före?");
          var bChunk = Console.ReadLine();
          Console.WriteLine("\n Vilket är ordet du vill lägga till med?");
          var prependChunk = Console.ReadLine();
          return new PrependRule()
          {
            Id = (ruleFixture == null) ? 1 : ruleFixture.Rules.Count + 1,
            RuleType = ruleType,
            BaseChunk = bChunk,
            PrependChunk = prependChunk
          };
        default:
          Console.WriteLine("[!!!] Du har matat in en felaktig regel. Startar om..");
          break;
      }
      return null;
    }
  }
}

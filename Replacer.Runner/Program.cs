using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Replacer;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Replacer.Read;
using Replacer.Rules;

namespace Replacer.Runner
{
  class Program
  {
    static void Main(string[] args)
    {
      string ruleLocation = @"C:\Users\JAkerblom\Documents\Visual Studio 2015\Projects\My_CIK_code\Replacer\rules_v3.json.txt";
      string textLocation = @"C:\Users\JAkerblom\Documents\Visual Studio 2015\Projects\My_CIK_code\Replacer\text.txt";

      var rulesReader = new RulesReader(ruleLocation);
      var textsReader = new TextsReader(textLocation);
      var textManipulator = new TextManipulator();
      var displayer = new Displayer();
      //var ruleWriter = new RuleWriter();

      var ruleFixtures = rulesReader.ReadFromRulesRepository();
      var textContents = textsReader.ReadFromTextRepository();

      bool userWantsToExit = false;
      string subAction;
      while (!userWantsToExit)
      {
        displayer.DisplayStartMenu();
        var action = Console.ReadLine();
        switch (action)
        {
          case "0":
            userWantsToExit = true;
            break;
          case "1":
            var manipulatedContents = textManipulator.Manipulate(textContents, ruleFixtures);
            displayer.DisplayResultsFromTextManipulator(manipulatedContents);
            subAction = Console.ReadLine();
            if (subAction == "0") userWantsToExit = true;
            break;
          case "2":
            displayer.DisplayRequestForRuleType();
            var ruleType = Console.ReadLine();
            Rule newRule = displayer.RequestNewRule(ruleType);
            ruleFixtures.Find(x => x.RuleType == ruleType).Rules.Add(newRule);
            //ruleWriter.Save(ruleFixtures);
            break;
        }
      }

      Console.WriteLine("\n\nAbryter applikationen...");
      Console.ReadLine();
    }
  }
}
      //_ruleset = new Dictionary<string, IRule<ReplaceRule>>()
      //_ruleset = new Dictionary<string, ReplaceRule>()
      //{
      //  {
      //    "req-1.1",
      //    //new ReplaceRule("Företaget", "Forefront")
      //    new ReplaceRule()
      //    {
      //      OldChunk = "Företaget",
      //      NewChunk = "Forefront"
      //    }
      //  },
      //  {
      //    "req-1.2",
      //    new ReplaceRule()
      //    {
      //      OldChunk = "",
      //      NewChunk = ""
      //    }
      //  }
      //};

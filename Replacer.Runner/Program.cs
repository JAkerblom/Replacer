using System;
using System.Linq;
using Replacer.Data;
using Replacer.Rules;

namespace Replacer.Runner
{
  class Program
  {
    static void Main(string[] args)
    {
      string ruleLocation = @"C:\Users\JAkerblom\Documents\Visual Studio 2015\Projects\My_CIK_code\Replacer\rules_v3.json";
      string textLocation = @"C:\Users\JAkerblom\Documents\Visual Studio 2015\Projects\My_CIK_code\Replacer\text.txt";

      var rulesIO = new RulesIO(ruleLocation);
      var textReader = new TextsReader(textLocation);
      var textManipulator = new TextManipulator();
      var console = new ConsoleInteractor();

      var ruleFixtures = rulesIO.GetRuleFixtures();
      var approvedRuleTypes = rulesIO.GetApprovedRules();
      var textContents = textReader.ReadFromTextRepository();

      bool userWantsToExit = false;
      string subAction;
      while (!userWantsToExit)
      {
        console.DisplayStartMenu();
        var action = Console.ReadLine();
        switch (action)
        {
          case "0":
            userWantsToExit = true;
            break;
          case "1":
            console.DisplayManipulationStart();
            var manipulatedContents = textManipulator.Manipulate(textContents, ruleFixtures);
            console.DisplayResultsFromTextManipulator(manipulatedContents);
            subAction = Console.ReadLine();
            if (subAction == "0") userWantsToExit = true;
            break;
          case "2":
            console.DisplayRequestForRuleType();
            var ruleType = Console.ReadLine();
            if (approvedRuleTypes.ToList().Where(x => x == ruleType).FirstOrDefault() == null ) {
              Console.WriteLine(" [!!!] Du matade in en regel som inte finns implementerad för närvarande.");
              break;
            }
            Rule newRule = rulesIO.RequestNewRule(ruleType, ruleFixtures);
            ruleFixtures = rulesIO.SaveRule(newRule, ruleFixtures, approvedRuleTypes);
            console.DisplayNewlyAddedRule(newRule);
            subAction = Console.ReadLine();
            if (subAction == "0") userWantsToExit = true;
            break;
        }
      }

      Console.WriteLine("\n Abryter applikationen...");
      Console.ReadLine();
    }
  }
}



//var ruleFixtures = rulesIO.ReadFromRulesRepository();
//var approvedRules = rulesIO.ReadFromRulesRepository().Find(x => x.ApprovedRules);

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

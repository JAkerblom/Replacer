using Replacer.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replacer.Runner
{
  public class ConsoleInteractor
  {
    public ConsoleInteractor()
    {

    }

    public void DisplayStartMenu()
    {
      Console.WriteLine("Välkommen. Välj vad du vill göra:");
      Console.WriteLine("1. Manipulera text med befintligt regelsystem.");
      Console.WriteLine("2. Lägg till eller ta bort regler. (just nu bara lägga till)");
      //Console.WriteLine("3. Ändra text som applikationen ska manipulera.");
      Console.WriteLine("0. Avbryt applikationen.");
    }

    public void DisplayManipulationStart()
    {
      Console.WriteLine("\n--------------------------------------------------------------------------------------");
      Console.WriteLine("\n Genomför manipulering enligt definierade regler.\n");
      Console.WriteLine("--------------------------------------------------------------------------------------\n");
    }

    public void DisplayResultsFromTextManipulator(string manipulatedContents)
    {
      Console.WriteLine("\n--------------------------------------------------------------------------------------");
      Console.WriteLine(" Det här är resultatet efter att ha manipulerat texten enligt definierade regler:");
      Console.WriteLine("--------------------------------------------------------------------------------------\n");
      Console.WriteLine(manipulatedContents);
      Console.WriteLine("\n--------------------------------------------------------------------------------------\n");
      Console.WriteLine("[###] Tryck valfri tangent för att komma till startmenyn eller 0 för att avsluta.");
    }

    public void DisplayRequestForRuleType()
    {
      Console.WriteLine("\n--------------------------------------------------------------------------------------\n");
      Console.WriteLine(" Mata in typen av regel du vill skapa:");
      Console.WriteLine(" -> :replace: (Byta ut ett ord mot ett annat)");
      Console.WriteLine(" -> :append:  (Lägga till ett ord efter ett annat)");
    }

    public void DisplayNewlyAddedRule(Rule newRule)
    {
      Console.WriteLine("\n--------------------------------------------------------------------------------------\n");
      Console.WriteLine(" Du har lagt till en regel av typ: " + newRule.RuleType);
      Console.WriteLine(" Den utför sin operation på orden " + newRule.ToString());
      Console.WriteLine("\n--------------------------------------------------------------------------------------\n");
      Console.WriteLine(" [###] Tryck valfri tangent för att komma till startmenyn eller 0 för att avsluta.");
    }

  }
}

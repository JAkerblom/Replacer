using Replacer.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replacer.Runner
{
  public class Displayer
  {
    public Displayer()
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

    public void DisplayResultsFromTextManipulator(string manipulatedContents)
    {
      Console.WriteLine("\n--------------------------------------------------------------------------------------\n");
      Console.WriteLine(" Det här är resultatet efter att ha manipulerat texten enligt definierade regler:");
      Console.WriteLine("--------------------------------------------------------------------------------------\n");
      Console.WriteLine(manipulatedContents);
      Console.WriteLine("\n--------------------------------------------------------------------------------------\n");
      Console.WriteLine("Type any key to go back to the start menu or 0 to quit.");
    }

    public void DisplayRequestForRuleType()
    {
      Console.WriteLine("\n--------------------------------------------------------------------------------------\n");
      Console.WriteLine(" Mata in typen av regel du vill skapa:");
      Console.WriteLine(":replace: (Byta ut ett ord mot ett annat)");
      Console.WriteLine(":append: (Lägga till ett ord efter ett annat)");
    }

    public Rule RequestNewRule(string ruleType)
    {
      switch (ruleType)
      {
        case "replace":
          Console.WriteLine("Vilket är det ordet du vill byta ut?");
          var oldChunk = Console.ReadLine();
          Console.WriteLine("Vilket är ordet du vill byta ut med?");
          var newChunk = Console.ReadLine();
          return new ReplaceRule()
          {
            OldChunk = oldChunk,
            NewChunk = newChunk
          };
          //break;
        case "append":
          Console.WriteLine("Vilket är det ordet du vill lägga till ett ord intill?");
          var baseChunk = Console.ReadLine();
          Console.WriteLine("Vilket är ordet du vill lägga till med?");
          var appendChunk = Console.ReadLine();
          return new AppendRule()
          {
            BaseChunk = baseChunk,
            AppendChunk = appendChunk
          };
          //break;
        default:
          Console.WriteLine("Du har matat in en felaktig regel. Startar om..");
          break;
      }
      return null;
    }
  }
}

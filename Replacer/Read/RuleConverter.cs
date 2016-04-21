using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Replacer.Rules;

namespace Replacer.Read
{
  /// <summary>
  ///  Implementation of a Json converter with capability to convert rule structures
  ///  into rule objects. Preferably multiple rule types for easy implementation of new
  ///  rule objects. 
  /// </summary>
  public class RuleConverter : JsonConverter
  {
    public override bool CanConvert(Type objectType)
    {
      return (objectType == typeof(RuleFixture));
      //return (objectType == typeof(IRule)); // An error here; was supposed to be RuleFixture and not the Rule interface
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      /// This attempt tried if the read json string part could be deserialized into a ReplaceRule
      ///  otherwise it would try with the other rules.
      //object readRule = serializer.Deserialize<ReplaceRule>(reader);

      //if (readRule == null)
      //{
      //  readRule = serializer.Deserialize<OtherRule>(reader);
      //}

      /// This attempt tries to create objects based on json property RuleType
      JObject jobj = JObject.Load(reader);
      RuleFixture ruleFixture = new RuleFixture();
      ruleFixture.RuleType = (string)jobj["RuleType"];
      ruleFixture.Rules = new List<Rule>();

      foreach (JObject jo in jobj["Rules"])
      {
        if (ruleFixture.RuleType == "replace")
          ruleFixture.Rules.Add(jo.ToObject<ReplaceRule>(serializer));
        else if (ruleFixture.RuleType == "append")
          ruleFixture.Rules.Add(jo.ToObject<AppendRule>(serializer));
        else
          // error
          Console.WriteLine("The rule database contains rules that are not defined within the core system. \n Please revise the source code.");
      } 

      return ruleFixture;
    }

    public override bool CanWrite
    {
      get
      {
        return false;
      }
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      throw new NotImplementedException();
    }
  }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Replacer.Rules;

namespace Replacer.Data
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
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      /// This attempt tries to create objects based on json property RuleType
      JObject jobj = JObject.Load(reader);

      RuleData ruleData = new RuleData();
      ruleData.ApprovedRuleTypes = jobj["ApprovedRuleTypes"].ToObject<string[]>(serializer);
      ruleData.RuleFixtures = new List<RuleFixture>();

      foreach (JObject joF in jobj["RuleFixtures"])
      {
        RuleFixture ruleFixture = new RuleFixture();
        ruleFixture.RuleType = (string)joF["RuleType"];
        ruleFixture.Rules = new List<Rule>();

        foreach (JObject joR in joF["Rules"])
        {
          if (ruleFixture.RuleType == "replace")
            ruleFixture.Rules.Add(joR.ToObject<ReplaceRule>(serializer));
          else if (ruleFixture.RuleType == "append")
            ruleFixture.Rules.Add(joR.ToObject<AppendRule>(serializer));
          else
            // error
            Console.WriteLine("The rule database contains rules that are not defined within the core system. \n Please revise the source code.");
        }

        ruleData.RuleFixtures.Add(ruleFixture);
      }

      return ruleData;
    }

    public override bool CanWrite
    {
      get
      {
        return true;
      }
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      var ruleData = value as RuleData;
      writer.Formatting = Formatting.Indented;
      writer.WriteStartObject();
      writer.WritePropertyName("ApprovedRuleTypes");
      serializer.Serialize(writer, ruleData.ApprovedRuleTypes);
      writer.WritePropertyName("RuleFixtures");
      serializer.Serialize(writer, ruleData.RuleFixtures);
      writer.WriteEndObject();
    }
  } 
}

/// This attempt tried if the read json string part could be deserialized into a ReplaceRule
///  otherwise it would try with the other rules.
//object readRule = serializer.Deserialize<ReplaceRule>(reader);

//if (readRule == null)
//{
//  readRule = serializer.Deserialize<OtherRule>(reader);
//}

//var ruleFixture = value as RuleFixture;
//writer.Formatting = Formatting.Indented;
//writer.WriteStartObject();
//writer.WritePropertyName("RuleType");
//serializer.Serialize(writer, ruleFixture.RuleType);
//writer.WritePropertyName("Rules");
//serializer.Serialize(writer, ruleFixture.Rules);
//writer.WriteEndObject();


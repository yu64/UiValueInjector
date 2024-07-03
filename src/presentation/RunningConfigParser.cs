
using System.Collections.Immutable;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using UiValueInjector.Domain;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace UiValueInjector.Presentation;


internal class RunningConfigParser
{

    internal RunningConfigParser()
    {
        //なし
    }


    public RunningConfig ParseFromYaml(string yaml)
    {
        string json = this.ToJsonFromYaml(yaml);
        return this.ParseFromJson(json);
    }

#pragma warning disable CS8602 // null 参照の可能性があるものの逆参照です。
    public RunningConfig ParseFromJson(string json)
    {
        try
        {
            var root = JsonNode.Parse(json);

            return new RunningConfig(
                rules: root["rules"].AsArray().Select((rule) => new Rule(

                    name: new RuleName(rule["name"].GetString()),
                    timing: rule["timing"].GetEnum<TimingType>(),
                    value: new RuleValue(rule["value"].GetString()),
                    
                    selectors: rule["selectors"].AsArray().Select((selector) => new ElementSelector(

                        type: selector["type"].GetEnum<ElementSelectorType>(),
                        value: selector["value"].GetString()

                    )).ToImmutableList()
                )).ToImmutableList()
            );
        }
        catch
        {
            throw;
        }
        
    }
#pragma warning restore CS8602 // null 参照の可能性があるものの逆参照です。



    private string ToJsonFromYaml(string yaml)
    {
        var deserializer = new Deserializer();
        var yamlObject = deserializer.Deserialize(yaml);
        var serializer = new SerializerBuilder()
            .JsonCompatible()
            .Build();
        return serializer.Serialize(yamlObject).Trim();
    }




}


file static class JsonNodeExt
{
    public static string GetString(this JsonNode? node)
    {
        if(node == null)
        {
            throw new Exception("JsonNode is null");
        }

        return node.GetValue<string>();
    }

    public static E GetEnum<E>(this JsonNode? node)
    {
        return (E)Enum.Parse(typeof(E), node.GetString());
    }


}
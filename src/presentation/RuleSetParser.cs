
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


internal class ConfigParser
{

    internal ConfigParser()
    {
        
    }



    public RuleSet ParseFromFile(string path, Encoding charset, string[] args)
    {
        string configText = File.ReadAllText(
            path, 
            charset
        );

        var configExt = Path.GetExtension(path);

        return configExt switch
        {
            ".json" => this.ParseFromJson(configText, args),
            ".yaml" => this.ParseFromYaml(configText, args),
            _ => throw new Exception("unsupport config")
        };
    }

    public RuleSet ParseFromYaml(string yaml, string[] args)
    {
        string json = this.ToJsonFromYaml(yaml);
        return this.ParseFromJson(json, args);
    }

#pragma warning disable CS8602 // null 参照の可能性があるものの逆参照です。
    public RuleSet ParseFromJson(string json, string[] args)
    {
        try
        {
            var root = JsonNode.Parse(json);

            return new RuleSet(
                rules: root["rules"].AsArray().Select((rule) => new Rule(

                    name: new RuleName(rule["name"].GetString(args)),
                    timing: rule["timing"].GetEnum<TimingType>(),
                    value: new RuleValue(rule["value"].GetString(args)),
                    
                    selectors: rule["selectors"].AsArray().Select((selector) => new ElementSelector(

                        type: selector["type"].GetString(args),
                        value: selector["value"].GetString(args)

                    )).ToImmutableHashSet()
                )).ToImmutableHashSet()
            );
        }
        catch(Exception e)
        {
            throw new Exception("Fail Parse Config", e);
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

    public static string GetString(this JsonNode? node, string[] args)
    {
        if(node == null)
        {
            throw new Exception("JsonNode is null");
        }

        return String.Format(node.GetValue<string>(), args);
    }

    public static E GetEnum<E>(this JsonNode? node)
    {
        return (E)Enum.Parse(typeof(E), node.GetString());
    }

    public static T GetObj<T>(this JsonNode? node, Func<string, T> func)
    {
        return func(node.GetString());
    }


}
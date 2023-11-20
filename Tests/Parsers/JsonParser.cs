// using System;
using Newtonsoft.Json;
using TextReader = Newtonsoft.Json.JsonTextReader;

// using System.Text.Json;

namespace Tests.Parsers;

public class JsonParser
{
    // public static T Parser<T>(List<string> fileLocation, string fileName)
    // {
    //     var location = fileLocation.ToList();
    //     location.Add(fileName);

    //     using var reader = new StreamReader(Path.Combine(location.ToArray()));
    //     string json = reader.ReadToEnd();

    //     T? parsedObject = JsonSerializer.Deserialize<T>(
    //         json,
    //         new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
    //     );

    //     if (parsedObject is null)
    //         throw new Exception($"Error parsing {typeof(T)}");

    //     return parsedObject;
    // }

    public static T Parser<T>(List<string> fileLocation, string fileName)
    {
        var location = fileLocation.Append(fileName);

        using var reader = new StreamReader(Path.Combine(location.ToArray()));
        string json = reader.ReadToEnd();

        TextReader textReader = new(new StringReader(json));

        T? parsedObject = JsonSerializer.Create().Deserialize<T>(textReader);

        if (parsedObject is null)
            throw new Exception($"Error parsing {typeof(T)}");

        return parsedObject;
    }

    internal static string ToJson(object newOrders)
    {
        return System.Text.Json.JsonSerializer.Serialize(newOrders);
    }
}

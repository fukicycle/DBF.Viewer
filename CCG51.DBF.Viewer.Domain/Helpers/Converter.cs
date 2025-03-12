using System;

namespace CCG51.DBF.Viewer.Domain.Helpers;

public static class Converter
{
    public static IReadOnlyCollection<Dictionary<string, string?>> ToDictionary(this IEnumerable<string?[]> values, string[] headers)
    {
        var result = new List<Dictionary<string, string?>>();
        foreach (var value in values)
        {
            result.Add(headers.Zip(value, (h, v) => new { h, v }).ToDictionary(a => a.h, a => a.v));
        }
        return result;
    }
}

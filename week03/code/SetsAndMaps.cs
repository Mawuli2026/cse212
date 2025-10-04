using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

public static class SetsAndMaps
{
    // Problem 1: FindPairs
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var result = new List<string>();

        foreach (var word in words)
        {
            if (word[0] == word[1]) continue; // skip same-char words
            var reversed = new string(new[] { word[1], word[0] });

            if (seen.Contains(reversed))
            {
                result.Add($"{word} & {reversed}");
            }
            seen.Add(word);
        }

        return result.ToArray();
    }

    // Problem 2: SummarizeDegrees
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            var degree = fields[3].Trim();

            if (!degrees.ContainsKey(degree))
            {
                degrees[degree] = 0;
            }
            degrees[degree]++;
        }

        return degrees;
    }

    // Problem 3: IsAnagram
    public static bool IsAnagram(string word1, string word2)
    {
        string Normalize(string s) =>
            new string(s.ToLower().Where(char.IsLetterOrDigit).ToArray());

        var w1 = Normalize(word1);
        var w2 = Normalize(word2);

        if (w1.Length != w2.Length) return false;

        var counts = new Dictionary<char, int>();

        foreach (var c in w1)
        {
            if (!counts.ContainsKey(c))
                counts[c] = 0;
            counts[c]++;
        }

        foreach (var c in w2)
        {
            if (!counts.ContainsKey(c)) return false;
            counts[c]--;
            if (counts[c] < 0) return false;
        }

        return counts.Values.All(v => v == 0);
    }

    // Problem 5: EarthquakeDailySummary
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        var json = client.GetStringAsync(uri).Result;
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        return featureCollection.Features
            .Where(f => f.Properties != null && f.Properties.Mag.HasValue)
            .Select(f => $"{f.Properties.Place} - Mag {f.Properties.Mag.Value}")
            .ToArray();
    }
}

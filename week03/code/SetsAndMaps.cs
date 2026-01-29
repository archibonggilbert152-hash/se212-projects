using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    // --------------------------------------------------
    // PROBLEM 1: Find Pairs
    // --------------------------------------------------
    public static List<string> FindPairs(string[] words)
    {
        HashSet<string> seen = new();
        List<string> result = new();

        foreach (string word in words)
        {
            char a = word[0];
            char b = word[1];

            // Skip same-character words like "aa"
            if (a == b)
                continue;

            string reversed = $"{b}{a}";

            if (seen.Contains(reversed))
            {
                // REQUIRED FORMAT per tests
                result.Add($"{word} & {reversed}");
            }
            else
            {
                seen.Add(word);
            }
        }

        return result;
    }

    // --------------------------------------------------
    // PROBLEM 2: Degree Summary
    // --------------------------------------------------
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        Dictionary<string, int> summary = new();

        foreach (string line in File.ReadAllLines(filename))
        {
            string[] parts = line.Split(',');

            if (parts.Length < 4)
                continue;

            string degree = parts[3].Trim();

            if (summary.ContainsKey(degree))
                summary[degree]++;
            else
                summary[degree] = 1;
        }

        return summary;
    }

    // --------------------------------------------------
    // PROBLEM 3: Anagrams
    // --------------------------------------------------
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
            return false;

        Dictionary<char, int> counts = new();

        foreach (char c in word1)
        {
            if (counts.ContainsKey(c))
                counts[c]++;
            else
                counts[c] = 1;
        }

        foreach (char c in word2)
        {
            if (!counts.ContainsKey(c))
                return false;

            counts[c]--;

            if (counts[c] < 0)
                return false;
        }

        return true;
    }

    // --------------------------------------------------
    // PROBLEM 5: Earthquakes
    // --------------------------------------------------
    public static string[] EarthquakeDailySummary(string _)
    {
        using HttpClient client = new();

        string json = client.GetStringAsync(
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson"
        ).Result;

        FeatureCollection data =
            JsonSerializer.Deserialize<FeatureCollection>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

        List<string> results = new();

        foreach (var feature in data.Features)
        {
            results.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
        }

        return results.ToArray();
    }
}

// --------------------------------------------------
// JSON DATA CLASSES (DEFINE ONCE ONLY)
// --------------------------------------------------
public class FeatureCollection
{
    public List<Feature> Features { get; set; }
}

public class Feature
{
    public Properties Properties { get; set; }
}

public class Properties
{
    public string Place { get; set; }
    public double? Mag { get; set; }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

/// <summary>
/// A table that can parse formatted strings, replacing each key attribute with its value
/// </summary>
[Serializable]
public class StringTable : SerializableDictionary<string, string>
{
    static readonly Regex keyRegex = new ("<<.*>>", RegexOptions.Compiled);

    /// <param name="text">Text with key codes</param>
    /// <returns>The text with each keycode replaced by its value</returns>
    public string Parse(string text)
    {
        StringBuilder builder = new(text);

        foreach(var match in keyRegex.Matches(text).Cast<Match>())
            builder
                .Remove(match.Index, match.Length)
                .Insert(match.Index, this[match.Value[2..^2]]);
        

        return builder.ToString();
    }
}

[Serializable]
public class ObjectTable : SerializableDictionary<string, GameObject>
{
    public GameObject Instantiate(string name, Transform parent = null)
        => GameObject.Instantiate(this[name], parent);
    
}

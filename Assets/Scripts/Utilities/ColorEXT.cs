using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ColorUtility;

public static class ColorEXT
{
    /// <returns><see cref="UnityEngine.Color">Color</see> in HTML RGB format (no '#') </returns>
    public static string Hex(this Color color)
        => ToHtmlStringRGB(color);

    /// <returns>text string as a Rich Text string in the chosen color</returns>
    public static string Color(this string text, Color color)
        => $"<color=#{color.Hex()}>{text}</color>";
}

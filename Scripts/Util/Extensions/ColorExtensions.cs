using UnityEngine;
using System.Collections;

//From: https://github.com/foolmoron/PicosRapture/blob/master/Assets/Scripts/Extensions/ColorExtensions.cs
//Credit to this guy github.com/foolmoron for making these extensions public

public static class ColorExtensions
{
    public static Color withAlpha(this Color color, float alpha)
    {
        color.a = alpha;
        return color;
    }
}
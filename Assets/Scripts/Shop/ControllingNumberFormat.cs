using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllingNumberFormat : MonoBehaviour
{
    private static string[] _numes = new[]
    {
        "",
        "K",
        "M",
        "B",
        "T"
    };

    public static string NumberFormat( float num)
    {
        if (num == 0)
            return "0";

        num = Mathf.Round(num);

        int i = 0;
        while (i + 1 < _numes.Length && num >= 1000f)
        {
            num /= 1000f;
            i++;
        }

        return num.ToString(format: "#.##") + _numes[i];
    }
}

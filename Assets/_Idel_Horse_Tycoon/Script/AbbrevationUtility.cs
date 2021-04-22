using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class AbbrevationUtility
{
    private static readonly SortedDictionary<int, string> abbrevations = new SortedDictionary<int, string>
            {
                {1000,"K"},
                {1000000, "M" },
                {1000000000, "B" }
            };

    public static string AbbreviateNumber(float number)
    {
        for (int i = abbrevations.Count - 1; i >= 0; i--)
        {
            KeyValuePair<int, string> pair = abbrevations.ElementAt(i);
            if (Mathf.Abs(number) >= pair.Key)
            {
                float roundedNumber = /*Mathf.FloorToInt(*/number / pair.Key/*)*/;

                string[] x = (roundedNumber.ToString(".0")).Split('.');



                if(int.Parse(x[1])>0)
                return x[0]+"."+ x[1] + pair.Value;
                else
                    return x[0] + pair.Value;


            }
        }
        return number.ToString();
    }
}

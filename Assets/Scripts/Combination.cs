using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination
{
    private List<int> combination;

    public Combination()
    {
        combination = new List<int> { 2, 4, 6, 8};
    }

    public int GetCombinationDigit(int digitNumber)
    {
        if (digitNumber < 0)
        {
            return 0;
        }

        if (digitNumber >= combination.Count)
        {
            return 0;
        }

        return combination[digitNumber];
    }

    public int GetCombinationLength()
    {
        return combination.Count;
    }
}

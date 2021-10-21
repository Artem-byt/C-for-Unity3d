using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NumberofRequiredBonusUnits
{
    private static int _reqiuredBonusunits = 0;
    private static int _currentlevelrequiredbonusunits = 0;

    public static void ClearUnits()
    {
        _reqiuredBonusunits = 0;
        _currentlevelrequiredbonusunits = 0;
    }

    public static void AddUnit()
    {
        _reqiuredBonusunits++;
    }

    public static void AddCurrentLvlUnit()
    {
        _currentlevelrequiredbonusunits++;
    }

    public static int GetUnit()
    {
        return _reqiuredBonusunits;
    }

    public static int GetCurrentUnit()
    {
        return _currentlevelrequiredbonusunits;
    }
}

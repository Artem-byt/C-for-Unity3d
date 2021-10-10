using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberofRequiredBonusUnits
{
    private int _reqiuredBonusunits = 0;
    private  int _currentlevelrequiredbonusunits = 0;

    public  void ClearUnits()
    {
        _reqiuredBonusunits = 0;
        _currentlevelrequiredbonusunits = 0;
    }

    public void AddUnit()
    {
        _reqiuredBonusunits++;
    }

    public void AddCurrentLvlUnit()
    {
        _currentlevelrequiredbonusunits++;
    }

    public int GetUnit()
    {
        return _reqiuredBonusunits;
    }

    public int GetCurrentUnit()
    {
        return _currentlevelrequiredbonusunits;
    }
}

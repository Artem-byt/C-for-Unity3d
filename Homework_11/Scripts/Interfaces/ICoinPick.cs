using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ICoinPick
{
    public event Action<int> OnBonusPickedUp;

    public void ChangeCoin(int coin);
}

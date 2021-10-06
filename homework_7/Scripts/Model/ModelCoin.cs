using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelCoin : ICoin
{
    public int CurrentCoin { get; set; }

    public ModelCoin (int currentcoin)
    {
        CurrentCoin = currentcoin;
    }
}

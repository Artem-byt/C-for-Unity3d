using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinView : MonoBehaviour, ICoinView
{
    private Text _coin;

    private void Start()
    {
        _coin = GetComponent<Text>();
    }

    public void UpdateCoin(ICoin coin)
    {
        _coin.text = coin.CurrentCoin.ToString();
    }
}

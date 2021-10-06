using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : IExecute
{
    private ICoin _model;
    private ICoinView _view;

    public CoinController(ICoin model, ICoinView view, ICoinPick coinPick)
    {
        _model = model;
        _view = view;
        coinPick.OnBonusPickedUp += ChangeCoin;
    }

    public void ChangeCoin(int coin)
    {
        _model.CurrentCoin += coin;
    }

    public void Execute()
    {
        _view.UpdateCoin(_model);
    }
}

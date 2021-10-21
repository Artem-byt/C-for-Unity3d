using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInitialization: IInitialize
{
    private GameObject _canvas;

    public CanvasInitialization(ICanvasFactory canvasFactory)
    {
        _canvas = canvasFactory.CreateCanvas();
    }

    public void Initialize()
    {

    }
    
    public CoinView GetCoinViewComponent()
    {
        return _canvas.GetComponentInChildren<CoinView>();
    }

    public GameObject GetCanvas()
    {
        return _canvas;
    }
}

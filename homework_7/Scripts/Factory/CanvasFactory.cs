using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFactory : ICanvasFactory
{
    private GameObject _canvas;

    public CanvasFactory(GameObject canvasPrefab)
    {
        _canvas = canvasPrefab;
    }

    public GameObject CreateCanvas()
    {
        return Object.Instantiate(_canvas);
    }
}

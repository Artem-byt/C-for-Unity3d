using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GamePlay", menuName = "GamePlay / New PStartMenuCanvas")]
public class StartMenuCanvasInfo : ScriptableObject
{
    [SerializeField] private List<GameObject> _canvasMenu;

    public List<GameObject> canvasMenu => _canvasMenu;
}

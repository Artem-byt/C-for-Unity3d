using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GamePlay", menuName = "GamePlay / New CanvasInfo")]
public class CanvasInfo : ScriptableObject
{
    [SerializeField] private GameObject _CanvasPrefab;
    [SerializeField] private GameObject _EventSystemPrefab;

    public GameObject CanvasPrefab => _CanvasPrefab;
    public GameObject EventSystemPrefab => _EventSystemPrefab;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GamePlay", menuName = "GamePlay / New PointsInfo")]
public class PointsInfo : ScriptableObject
{
    [SerializeField] private Transform[] _points;

    public Transform[] points => _points;
}

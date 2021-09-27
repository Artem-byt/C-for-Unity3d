using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelInfo", menuName = "GamePlay/New BonusInfo")]
public class BonusInfo : ScriptableObject
{
    [SerializeField] private GameObject[] _BonusPrefabs;
    [SerializeField] private Transform[] _bonusRespawns;

    public GameObject[] BonusPrefabs => _BonusPrefabs;

    public Transform[] bonusRespawns => _bonusRespawns;
}

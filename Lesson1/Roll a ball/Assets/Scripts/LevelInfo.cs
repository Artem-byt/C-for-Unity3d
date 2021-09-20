using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelInfo", menuName = "GamePlay/New LevelInfo")]
public class LevelInfo : ScriptableObject
{
    [SerializeField] private GameObject _EnemyPrefab;
    [SerializeField] private GameObject _PositiveBonusPrefab;
    [SerializeField] private GameObject _NegativeBonusPrefab;
    [SerializeField] private GameObject _ReqiredBonusPrefab;

    public GameObject enemyPrefab => this._EnemyPrefab;
    public GameObject positiveBonusPrefab => this._PositiveBonusPrefab;
    public GameObject negativeBonusPrefab => this._NegativeBonusPrefab;
    public GameObject requiredBonusPrefab => this._ReqiredBonusPrefab;
}

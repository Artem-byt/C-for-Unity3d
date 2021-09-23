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
    [SerializeField] private GameObject _PlayerPrefab;
    [SerializeField] private GameObject _Lvl1Prefab;
    [SerializeField] private Transform[] _EnemyPoints;
    [SerializeField] private Transform[] _RespawnBonuses;
    [SerializeField] private Transform _Startlvl;
    [SerializeField] private Transform _Endlvl;

    public GameObject enemyPrefab => this._EnemyPrefab;
    public GameObject positiveBonusPrefab => this._PositiveBonusPrefab;
    public GameObject negativeBonusPrefab => this._NegativeBonusPrefab;
    public GameObject requiredBonusPrefab => this._ReqiredBonusPrefab;
    public GameObject playerPrefab => this._PlayerPrefab;
    public GameObject lvl1Prefab => this._Lvl1Prefab;
    public Transform[] enemypoints => this._EnemyPoints;
    public Transform[] respawnBonuses => this._RespawnBonuses;
    public Transform startlvl => this._Startlvl;
    public Transform endlvl => this._Endlvl;
}

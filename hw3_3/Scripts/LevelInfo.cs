using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelInfo", menuName = "GamePlay/New LevelInfo")]
public class LevelInfo : ScriptableObject
{
    [SerializeField] private GameObject _EnemyPrefab;
    [SerializeField] private GameObject _PlayerPrefab;
    [SerializeField] private GameObject[] _Lvl;
    public GameObject enemyPrefab => this._EnemyPrefab;
    public GameObject playerPrefab => this._PlayerPrefab;
    public GameObject[] lvl => this._Lvl;
}

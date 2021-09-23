using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlCreator : MonoBehaviour
{
    private GameObject[] _PositiveBonuses;
    private GameObject[] _NegativeBonuses;
    private GameObject[] _RequiredBonuses;
    private Transform[] _SpawnBonuses;
    private Transform[] _EnemyPoints;
    private LevelInfo[] _LevelInformation;
    private int _numberOfRequiredBonuses;
    private GameObject _Enemy;
    private GameObject _LVL;
    private GameObject _Player;
    private Transform _StartLevel;

    public GameObject[] positiveBonuses { get { return _PositiveBonuses; } }
    public GameObject[] negativeBonuses { get { return _NegativeBonuses; } }
    public GameObject[] requiredBonuses { get { return _RequiredBonuses; } }
    public Transform[] spawnBonuses { get { return _SpawnBonuses; } }
    public int NumberOfRequiredBonuses { get { return _numberOfRequiredBonuses; } }
    public Transform[] enemyPoints { get { return _EnemyPoints; } }
    public GameObject enemy { get { return _Enemy; } }
    public GameObject player { get { return _Player; } }
    public Transform startLevel { get { return _StartLevel; } }

    void Awake()
    {
        _LevelInformation = Resources.LoadAll<LevelInfo>("");
    }
    public void LevelGenerate(int numberoflvl, bool flagDestruct)
    {
        if (flagDestruct) Destruct();

        _StartLevel = _LevelInformation[numberoflvl].startlvl;
        _LVL = Instantiate(_LevelInformation[numberoflvl].lvl1Prefab, _LevelInformation[0].lvl1Prefab.transform.position, Quaternion.identity);
        _numberOfRequiredBonuses = 0;
        _EnemyPoints = _LevelInformation[numberoflvl].enemypoints;
        _SpawnBonuses = _LevelInformation[numberoflvl].respawnBonuses;
        _PositiveBonuses = new GameObject[(_SpawnBonuses.Length) / 2];
        _NegativeBonuses = new GameObject[(_SpawnBonuses.Length - 1) / 2];
        _RequiredBonuses = new GameObject[(_SpawnBonuses.Length - 2) / 2];
        int l = 0;
        int j = 0;
        int typeofbonusforreaspawn = 0;
        for (int i = 0; i < _SpawnBonuses.Length; i++)
        {
            if (typeofbonusforreaspawn == 0)
            {
                _PositiveBonuses[l] = Instantiate(_LevelInformation[numberoflvl].positiveBonusPrefab, _SpawnBonuses[i].position, Quaternion.identity);
                l++;
            }
            else if (typeofbonusforreaspawn == 1)
            {
                _NegativeBonuses[j] = Instantiate(_LevelInformation[numberoflvl].negativeBonusPrefab, _SpawnBonuses[i].position, Quaternion.identity);
                j++;
            }
            else if (typeofbonusforreaspawn == 2)
            {
                _RequiredBonuses[_numberOfRequiredBonuses] = Instantiate(_LevelInformation[numberoflvl].requiredBonusPrefab, _SpawnBonuses[i].position, Quaternion.identity);
                _numberOfRequiredBonuses++;
            }
            typeofbonusforreaspawn = (typeofbonusforreaspawn + 1) % 3;
        }
        _Enemy = Instantiate(_LevelInformation[0].enemyPrefab, _EnemyPoints[UnityEngine.Random.Range(0, _EnemyPoints.Length - 1)].position, Quaternion.identity);
        if (_Player == null) _Player = Instantiate(_LevelInformation[0].playerPrefab, _LevelInformation[0].startlvl.position, Quaternion.identity);
        else _Player.transform.position = _StartLevel.position;
    }

    public void Destruct()
    {
        DestroyImmediate(_Enemy, true);
        for (int i = 0; i < _PositiveBonuses.Length; i++)
        {
            if(_PositiveBonuses[i] != null) DestroyImmediate(_PositiveBonuses[i], true);
        }
        for (int i = 0; i < _NegativeBonuses.Length; i++)
        {
           if (_NegativeBonuses[i] != null) DestroyImmediate(_NegativeBonuses[i], true);
        }
        for (int i = 0; i < _RequiredBonuses.Length; i++)
        {
           if (_RequiredBonuses[i] != null) DestroyImmediate(_RequiredBonuses[i], true);
        }
        DestroyImmediate(_LVL, true);
    }

}

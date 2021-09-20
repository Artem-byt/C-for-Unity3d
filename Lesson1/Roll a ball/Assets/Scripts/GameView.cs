using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;


public class GameView : MonoBehaviour
{
    #region Переменные для реализации движения игрока (масштабирование камеры, направление движения, вращение камерой вокруг игрока, объект - Игрок, объект - камера)
    private float _xMouse;
    private float _yMouse;
    private float _mouseScrollWheel;

    private float _speed = 1f;
    private Vector3 _direction;
    private string Player = nameof(Player);
    private GameObject _gameObjectCamera;
    private GameObject _gameObjectPlayer;
    public float xMouse { get { return _xMouse; } }
    public float yMouse { get { return _yMouse; } }
    public float mouseScrollWheel { get { return _mouseScrollWheel; } }

    public delegate void MovingDataPlayer(object value);
    public event MovingDataPlayer MovingPlayer;



    public Vector3 direction{ get { return _direction; } }
    public GameObject gameObjectCamera  { get { return _gameObjectCamera; } }

    public GameObject gameObjectPlayer { get { return _gameObjectPlayer; } }

    public float speed { get { return _speed; } set { _speed = value; } }
    private string MainCamera = nameof(MainCamera);
    private string RequiredBonus = nameof(RequiredBonus);
    #endregion

    #region Переменные для реализации бонусов
    private GameObject[] _PositiveBonuses;
    private GameObject[] _NegativeBonuses;
    private GameObject[] _RequiredBonuses;
    private GameObject _CollisionGameObject;

    public delegate void MovingSpeedDataPlayer(object value);
    public event MovingSpeedDataPlayer MovingSpeedPlayer;

    private string PositiveBonus = nameof(PositiveBonus);
    private string NegativeBonus = nameof(NegativeBonus);
    private string _TypeofBonus;

    public string typeofBonus { get { return _TypeofBonus; } }

    public GameObject[] positiveBonuses { get { return _PositiveBonuses; } }
    public GameObject[] negativeBonuses { get { return _NegativeBonuses; } }
    public GameObject[] requiredBonuses { get { return _RequiredBonuses; } }

    public GameObject collisionGameOgject
    {
        get { return _CollisionGameObject; }
    }
    #endregion

    #region Реализация спавна бонусов в разных местах и проход врага по карте
    private GameObject[] _EnemyPoints;
    private GameObject[] _SpawnBonuses;
    private GameObject _StartLevel;
    private GameObject _EndLevel;

    private GameObject _Enemy;
    private GameObject _PositiveBonusPrefab;
    private GameObject _NegativeBonusPrefab;
    private GameObject _RequiredBonusPrefab;

    public delegate void LevelWork(object value);
    public event LevelWork LevelWorkforEnemy;

    public delegate void PlayerCatch(object value);
    public event PlayerCatch _playercatched;

    public GameObject[] enemyPoints { get { return _EnemyPoints; } }
    public GameObject[] spawnBonuses { get { return _SpawnBonuses; } }
    public GameObject startLevel { get { return _StartLevel; } }
    public GameObject endLevel { get { return _EndLevel; } }
    public GameObject enemy { get { return _Enemy; } }

    private string EnemyPoint = nameof(EnemyPoint);
    private string RespawnBonus = nameof(RespawnBonus);
    private string StartLevel = nameof(StartLevel);
    private string EndLevel = nameof(EndLevel);
    private string Enemy = nameof(Enemy);
    #endregion

    private LevelInfo[] _LevelInformation;
    public void Awake()
    {
        _EnemyPoints = GameObject.FindGameObjectsWithTag(EnemyPoint);
        _SpawnBonuses = GameObject.FindGameObjectsWithTag(RespawnBonus);
        _StartLevel = GameObject.FindGameObjectWithTag(StartLevel);
        _EndLevel = GameObject.FindGameObjectWithTag(EndLevel);

        LevelGenerate();

        _PositiveBonuses = GameObject.FindGameObjectsWithTag(PositiveBonus);
        _NegativeBonuses = GameObject.FindGameObjectsWithTag(NegativeBonus);
        _RequiredBonuses = GameObject.FindGameObjectsWithTag(RequiredBonus);
        _gameObjectCamera = GameObject.FindGameObjectWithTag(MainCamera);
        _gameObjectPlayer = GameObject.FindGameObjectWithTag(Player);
    }


    public void Update()
    {
        InputData();
        MovingPlayer?.Invoke(this);
        LevelWorkforEnemy?.Invoke(this);

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Enemy))
        {

            _playercatched?.Invoke(this);
        }
        else
        {
            if (_PositiveBonuses.Contains(collision.gameObject)) CollisionAction(collision, PositiveBonus);
            else if (_NegativeBonuses.Contains(collision.gameObject)) CollisionAction(collision, NegativeBonus);
            else if (_RequiredBonuses.Contains(collision.gameObject)) CollisionAction(collision, RequiredBonus);
        }
    }


    public void LevelGenerate()
    {
        _LevelInformation = Resources.LoadAll<LevelInfo>("");
        _PositiveBonusPrefab = _LevelInformation[0].positiveBonusPrefab;
        _NegativeBonusPrefab = _LevelInformation[0].negativeBonusPrefab;
        _RequiredBonusPrefab = _LevelInformation[0].requiredBonusPrefab;

        int typeofbonusforreaspawn = 0;
        foreach(GameObject spawn in _SpawnBonuses)
        {
            if (typeofbonusforreaspawn == 0) Instantiate(_PositiveBonusPrefab, spawn.transform.position, Quaternion.identity);
            else if (typeofbonusforreaspawn == 1) Instantiate(_NegativeBonusPrefab, spawn.transform.position, Quaternion.identity);
            else if (typeofbonusforreaspawn == 2) Instantiate(_RequiredBonusPrefab, spawn.transform.position, Quaternion.identity);
            typeofbonusforreaspawn = (typeofbonusforreaspawn + 1) % 3;
        }
        _Enemy = Instantiate(_LevelInformation[0].enemyPrefab, _EnemyPoints[UnityEngine.Random.Range(0, _EnemyPoints.Length - 1)].transform.position, Quaternion.identity);
    }

    public void CollisionAction(Collision collision, string typeofbonus)
    {
        _CollisionGameObject = collision.gameObject;
        _TypeofBonus = typeofbonus;
        MovingSpeedPlayer?.Invoke(this);
        Destroy(collision.gameObject);
        Invoke("SetDefault", 10f);
    }
     public void SetDefault()
    {
        _speed = 1f;
    }

    public void InputData()
    {
        _direction = _gameObjectCamera.transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        _xMouse = Input.GetAxis("Mouse X");
        _yMouse = Input.GetAxis("Mouse Y");
        _mouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");
    }

    ~GameView() { }
    
}

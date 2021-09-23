using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using interfaces;

namespace roll_a_ball
{
    public class GameView : MonoBehaviour, ISceneMethods
    {
        #region Переменные для реализации движения игрока (масштабирование камеры, направление движения, вращение камерой вокруг игрока, объект - Игрок, объект - камера)
        private float _xMouse;
        private float _yMouse;
        private float _mouseScrollWheel;

        private float _speed = 1f;
        private Vector3 _direction;
        private GameObject _gameObjectCamera;
        private GameObject _gameObjectPlayer;

        public float Speed { get { return _speed; } set { _speed = value; } }
        public float XMouse { get { return _xMouse; } }
        public float YMouse { get { return _yMouse; } }
        public float MouseScrollWheel { get { return _mouseScrollWheel; } }
        public Vector3 Direction { get { return _direction; } }
        public GameObject GameObjectCamera { get { return _gameObjectCamera; } }
        public GameObject GameObjectPlayer { get { return _gameObjectPlayer; } }

        #endregion

        #region Переменные для реализации бонусов

        private int _typeofBonus;
        public int TypeofBonus { get { return _typeofBonus; } }

        #endregion

        #region Реализация спавна бонусов в разных местах и проход врага по карте

        private Transform _EndLevel;

        private LvlCreator _LvlCreator;

        public LvlCreator lvlCreator { get { return _LvlCreator; } set { _LvlCreator = value; } }
        public Transform endLevel { get { return _EndLevel; } }

        #endregion

        #region События
        public delegate void LevelWork(object value);
        public event LevelWork LevelWorkforEnemy;

        public delegate void PlayerCatch(object value);
        public event PlayerCatch _playercatched;

        public delegate void MovingDataPlayer(object value);
        public event MovingDataPlayer MovingPlayer;

        public delegate void MovingSpeedDataPlayer(object value);
        public event MovingSpeedDataPlayer MovingSpeedPlayer;

        public delegate void MovingSetDefaultSpeedPlayer(object value);
        public event MovingSetDefaultSpeedPlayer MovingSetSpeedPlayer;

        #endregion

        private LevelInfo[] _LevelInformation;
        public void Awake()
        {
            _LevelInformation = Resources.LoadAll<LevelInfo>("");
            _EndLevel = _LevelInformation[0].endlvl;

            _gameObjectCamera = Camera.main.gameObject;
            _gameObjectPlayer = gameObject;
        }


        public void Update()
        {
            InputData();
            MovingPlayer?.Invoke(this);
            LevelWorkforEnemy?.Invoke(this);
            //if (Vector3.Distance(_gameObjectPlayer.transform.position, _EndLevel.position) < 3f)
            //{
            //    _LvlCreator.LevelGenerate(0, true);
            //}
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<EnemyIndentificationComponent>())
            {
                _playercatched?.Invoke(this);
            }
            else
            {
                if (collision.gameObject.GetComponent<PositiveBonusIdentificationComponent>()) CollisionAction(collision.gameObject, 0);
                else if (collision.gameObject.GetComponent<NegativeBonusIdentificationComponent>()) CollisionAction(collision.gameObject, 1);
                else if (collision.gameObject.GetComponent<RequiredBonusIdentificationComponent>()) CollisionAction(collision.gameObject, 2);
            }
        }

        public void CollisionAction(GameObject collisiongameobject, int typeofbonus)
        {
            _typeofBonus = typeofbonus;
            MovingSpeedPlayer?.Invoke(this);
            Destroy(collisiongameobject);
            StartCoroutine(SetSpeedDefault());
        }

        private IEnumerator SetSpeedDefault()
        {
            yield return new WaitForSeconds(10f);
            Debug.Log("Set");
            MovingSetSpeedPlayer?.Invoke(this);
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
}
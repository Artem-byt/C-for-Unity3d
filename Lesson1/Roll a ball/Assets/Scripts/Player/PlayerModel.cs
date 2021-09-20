using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using interfaces;


public class PlayerModel: ICameraMove
{
    private float _speed { get; set; } = 1f;

    private RaycastHit _hit;
    private float _xMouse { get; set; }
    private float _yMouse { get; set; }
    private float _mouseScrollWheel { get; set; }
    private Vector3 _direction { get; set; }

    public float xMouse { get { return _xMouse; } set { _xMouse = value; } }
    public float yMouse { get { return _yMouse; } set { _yMouse = value; } }
    public float mouseScrollWheel { get { return _mouseScrollWheel; } set { _mouseScrollWheel = value; } }
    public float speed { get { return _speed; } set { _speed = value; } }

    public Vector3 direction { get { return _direction; } set { _direction = value; } }

    private float sensitivity = 3; // чувствительность мышки
    private float limit = 0; // ограничение вращения по Y
    private Vector3 offset = new Vector3(0, 1, 0);
    private float zoom = 1f; // чувствительность при увеличении, колесиком мышки
    private float zoomMax = 6; // макс. увеличение
    private float zoomMin = 3; // мин. увеличение
    private float X, Y;

    //private int _maskObstacles = LayerMask.NameToLayer("Wall");


    public void Move(GameObject _gameobjectPlayer)
    {
        if (_gameobjectPlayer.GetComponent<Rigidbody>())
        {
            _gameobjectPlayer.GetComponent<Rigidbody>().AddForce(_direction * _speed);
        }
        
    }

    public void CameraMove(GameObject gameObjectCamera, GameObject _gameobjectPlayer)
    {
        if (_mouseScrollWheel > 0) { offset.z += zoom;}
        else if (_mouseScrollWheel < 0) { offset.z -= zoom;}
        offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));
        X = gameObjectCamera.transform.localEulerAngles.y + _xMouse * sensitivity;
        Y += _yMouse * sensitivity;
        Y = Mathf.Clamp(Y, -limit, limit);
        gameObjectCamera.transform.localEulerAngles = new Vector3(-Y, X, 0);
        gameObjectCamera.transform.position = gameObjectCamera.transform.localRotation * offset + _gameobjectPlayer.transform.position;
        CheckWall(gameObjectCamera, _gameobjectPlayer);
    }

    public void CheckWall(GameObject gameObjectCamera, GameObject _gameobjectPlayer)
    {
        if (Physics.Raycast(_gameobjectPlayer.transform.position, gameObjectCamera.transform.position - _gameobjectPlayer.transform.position, out _hit, Vector3.Distance(gameObjectCamera.transform.position, _gameobjectPlayer.transform.position))) //_maskobstackles
        {
            gameObjectCamera.transform.position = _hit.point;
        }

    }

    ~PlayerModel() { }

}

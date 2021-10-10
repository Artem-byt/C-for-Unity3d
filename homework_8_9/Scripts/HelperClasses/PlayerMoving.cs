using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class PlayerMoving : IPlayerMove, ISetSpeedPlayer
{
    private GameObject _player;
    private Camera _camera;
    private float _speed;
    private Vector3 _move;


    public PlayerMoving(GameObject player , Camera camera)
    {
        _speed = 1f;
        _player = player;
        _camera = camera;
    }

    public void PlayerMove(float x, float y, float z)
    {
        _move = _camera.transform.TransformDirection(x, y, z);
        if (_player.TryGetComponent<Rigidbody>(out var _rigidbodyofplayer))
        {
            _rigidbodyofplayer.AddForce(_move * _speed);
        }
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }


 }

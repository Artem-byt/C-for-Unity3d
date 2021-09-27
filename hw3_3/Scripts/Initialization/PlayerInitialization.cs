using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInitialization: IInitialize, IGetPlayer
{
    private Transform _player;
    private CameraMoving _cameramoving;
    private IPlayerMove _playermove;

    public PlayerInitialization(IPlayerFactory playerfactory, Vector3 _playerposition, Camera camera)
    {
        _player = playerfactory.CreatePlayer();
        _player.position = _playerposition;
        _cameramoving = new CameraMoving(_player.gameObject, camera);
        _playermove = new PlayerMoving(_player.gameObject, camera);
    }
    public void Initialize()
    {
        
    }

    public IPlayerMove GetPlayerMoves()
    {
        return _playermove;
    }

    public ICameraMove GetCameraMoves()
    {
        return _cameramoving;
    }

    public GameObject GetPlayer()
    {
        return _player.gameObject;
    }

    public ISetSpeedPlayer GetAndSetSpeed()
    {
        return _playermove;
    }
}

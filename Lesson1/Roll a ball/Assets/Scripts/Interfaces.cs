using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace interfaces
{
    public interface ICameraMove
    {
        public void CheckWall(GameObject gameObjectCamera, GameObject _gameobjectPlayer);
        public void CameraMove(GameObject gameObjectCamera, GameObject _gameobjectPlayer);
        public void Move(GameObject _gameobjectPlayer);
    }
}


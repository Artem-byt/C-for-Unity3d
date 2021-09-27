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

    public interface ISceneMethods
    {
        public void CollisionAction(GameObject collisiongameobject, int typeofbonus);
        public void InputData();
    }

    public interface IEnemy
    {
        public void EnemyMovement();
        public void PlayerCatched();
    }

    public interface IBonus
    {
        public void BonusEffect(float currentspeed);
        public void NegativeEffect();
        public void PositiveEffect();
    }
}


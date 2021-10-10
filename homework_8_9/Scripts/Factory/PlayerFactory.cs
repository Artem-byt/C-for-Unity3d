using UnityEngine;

public class PlayerFactory : IPlayerFactory
{
    private GameObject _player;
    public PlayerFactory(GameObject _playerPrefab)
    {
        _player = _playerPrefab;
    }

    public Transform CreatePlayer()
    {
        return Object.Instantiate(_player).transform;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using roll_a_ball;

public class PlayManager : MonoBehaviour
{
    private GameProcess _playermovement;

    public void Start()
    { 
        _playermovement = new GameProcess();
        _playermovement.Run(gameObject);
    }
}

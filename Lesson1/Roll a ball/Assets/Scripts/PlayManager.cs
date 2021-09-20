using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public GameProcess _plauermovement;
    public void Start()
    {
        _plauermovement = new GameProcess();
        _plauermovement.Run();
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    private Controllers _controllers;

    void Start()
    {
        //List<int> variant = new List<int>() { 1, 1, 2, 2, 2, 3 };
        //Dictionary<int, int> result = new Dictionary<int, int>();
        //result = variant.GetSeemsElementsNumberVariant2();
        //foreach(KeyValuePair<int, int> element in result)
        //{
        //    Debug.Log(element.Key + "  " + element.Value);
        //}
        //HW7Extensions.DoExerciseNumber4Lambda();
        //Debug.Log("dhdhndfnbdndn".NumberOfSymbolsInStringVariant1());
        //Debug.Log("dhdhndfnbdndn".NumberOfSymbolsInStringVariant2());
        _controllers = new Controllers();
        new GameInitialization(_controllers, 0);
        _controllers.Initialize();
    }


    void Update()
    {
        _controllers.Execute();
    }

    private void OnDestroy()
    {
        _controllers.CleanUp();
    }
}

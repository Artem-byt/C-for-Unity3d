using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeleteActionInitialize : IRadarDeleteIcon
{
    public event Action<GameObject> DeleteCompletedBonus;

    public void GetDelete(GameObject gameObject)
    {
        DeleteCompletedBonus?.Invoke(gameObject);
    }
}

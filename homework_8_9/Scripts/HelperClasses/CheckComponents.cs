using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CheckComponents
{
    public static void CheckComponent<T>(GameObject gameObject) where T: Component
    {
        if (!gameObject.TryGetComponent<T>(out var component))
        {
            gameObject.AddComponent<T>();
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputScroll: IMouseInitialize
{
    public event Action<float> MouseeOnChange = delegate (float f) { };

    public void GetMouseAxis()
    {
        MouseeOnChange.Invoke(Input.GetAxis(PlayInputAxisManager.ScrollWheel));
    }
}

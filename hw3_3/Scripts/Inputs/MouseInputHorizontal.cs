using System;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputHorizontal: IMouseInitialize
{
    public event Action<float> MouseeOnChange = delegate (float f) { };

    public void GetMouseAxis()
    {
        MouseeOnChange.Invoke(Input.GetAxis(PlayInputAxisManager.XMouse));
    }
}

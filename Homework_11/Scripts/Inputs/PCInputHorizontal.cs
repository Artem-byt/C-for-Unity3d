using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCInputHorizontal: IInputInitialize
{
    public event Action<float> AxisOnChange = delegate (float f) { };


    public void GetAxis()
    {
        AxisOnChange.Invoke(Input.GetAxis(PlayInputAxisManager.Horizontal));
    }
}

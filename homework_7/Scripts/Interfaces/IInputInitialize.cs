using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputInitialize
{
    public event Action<float> AxisOnChange;

    public void GetAxis();
}

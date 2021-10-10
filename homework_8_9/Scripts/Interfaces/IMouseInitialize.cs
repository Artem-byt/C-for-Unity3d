using System;
using System.Collections.Generic;
using UnityEngine;

public interface IMouseInitialize
{
    public event Action<float> MouseeOnChange;

    public void GetMouseAxis();
    
}

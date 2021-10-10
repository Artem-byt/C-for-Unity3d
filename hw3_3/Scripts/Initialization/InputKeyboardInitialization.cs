using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyboardInitialization: IInitialize
{
    private IInputInitialize _horizontal;
    private IInputInitialize _vertical;

    public InputKeyboardInitialization()
    {
        _horizontal = new PCInputHorizontal();
        _vertical = new PCInputVertical();
    }

    public void Initialize()
    {
    }

    public (IInputInitialize horizontal, IInputInitialize vertical) GetInput()
    {
        return (_horizontal, _vertical);
    }
}

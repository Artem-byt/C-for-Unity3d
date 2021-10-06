using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController: IExecute
{
    private IInputInitialize _horizontal;
    private IInputInitialize _verical;

    public InputController((IInputInitialize horizpntal, IInputInitialize vertical) input)
    {
        _horizontal = input.horizpntal;
        _verical = input.vertical;
    }

    public void Execute()
    {
        _horizontal.GetAxis();
        _verical.GetAxis();;
    }
}

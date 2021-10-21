using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMouseController: IExecute
{
    private IMouseInitialize _xmouse;
    private IMouseInitialize _ymouse;
    private IMouseInitialize _scrollwheel;

    public InputMouseController((IMouseInitialize xmouse, IMouseInitialize ymouse, IMouseInitialize scrollwheel) mouseinput)
    {
        _xmouse = mouseinput.xmouse;
        _ymouse = mouseinput.ymouse;
        _scrollwheel = mouseinput.scrollwheel;
    }

    public void Execute()
    {
        _xmouse.GetMouseAxis();
        _ymouse.GetMouseAxis();
        _scrollwheel.GetMouseAxis();
    }
}

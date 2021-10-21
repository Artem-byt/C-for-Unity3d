using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMouseInitialization: IInitialize
{
    private IMouseInitialize _xmouse;
    private IMouseInitialize _ymouse;
    private IMouseInitialize _scrollwheel;

    public InputMouseInitialization()
    {
        _xmouse = new MouseInputHorizontal();
        _ymouse = new MouseInputVertical();
        _scrollwheel = new MouseInputScroll();
    }
    public void Initialize()
    {
    }

    public ( IMouseInitialize xmouse, IMouseInitialize ymouse, IMouseInitialize scrollwheel) GetMouseInput()
    {
        return ( _xmouse, _ymouse, _scrollwheel);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController: IExecute, ICleanUp
{
    private ICameraMove _playermoving;

    private float _Xmouse;
    private float _Ymouse;
    private float _Scrollwheel;
    private IMouseInitialize _xmouse;
    private IMouseInitialize _ymouse;
    private IMouseInitialize _scrollwheel;




    public CameraController((IMouseInitialize xmouse, IMouseInitialize ymouse, IMouseInitialize scrollwheel) mouseinput, ICameraMove playermoving)
    {
        _playermoving = playermoving;
        _xmouse = mouseinput.xmouse;
        _ymouse = mouseinput.ymouse;
        _scrollwheel = mouseinput.scrollwheel;
        _xmouse.MouseeOnChange += GetXMouse;
        _ymouse.MouseeOnChange += GetYMOuse;
        _scrollwheel.MouseeOnChange += GetScrollMouse;
    }

    public void GetXMouse(float value)
    {
        _Xmouse = value;
    }

    public void GetYMOuse(float value)
    {
        _Ymouse = value;
    }

    public void GetScrollMouse(float value)
    {
        _Scrollwheel = value;
    }
    public void Execute()
    {
        _playermoving.CameraMove(_Xmouse, _Ymouse, _Scrollwheel);
    }

    public void CleanUp()
    {
        _xmouse.MouseeOnChange -= GetXMouse;
        _ymouse.MouseeOnChange -= GetYMOuse;
        _scrollwheel.MouseeOnChange -= GetScrollMouse;
    }

    
}

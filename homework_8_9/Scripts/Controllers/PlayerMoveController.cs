using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController: IExecute, ICleanUp
{
    private float _Horizontal;
    private float _Vertical;
    private IInputInitialize _horizontal;
    private IInputInitialize _vertical;
    private IPlayerMove _playerMoving;

    public PlayerMoveController((IInputInitialize horizontal, IInputInitialize vertical) input, IPlayerMove playermoving)
    {
        _horizontal = input.horizontal;
        _vertical = input.vertical;
        _horizontal.AxisOnChange += GetHorizontalInput;
        _vertical.AxisOnChange += GetVerticalInput;
        _playerMoving = playermoving;
    }

    public void GetHorizontalInput(float value)
    {
        _Horizontal = value;
    }

    public void GetVerticalInput(float value)
    {
        _Vertical = value;
    }

    public void Execute()
    {
        _playerMoving.PlayerMove(_Horizontal, 0, _Vertical);
    }

    public void CleanUp()
    {
        _horizontal.AxisOnChange -= GetHorizontalInput;
        _vertical.AxisOnChange -= GetVerticalInput;
    }
}

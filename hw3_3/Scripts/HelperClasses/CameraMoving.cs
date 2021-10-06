using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving: ICameraMove
{
    private GameObject _player;
    private Camera _camera;

    private float sensitivity = 3; // чувствительность мышки
    private float limit = 0; // ограничение вращения по Y
    private Vector3 offset = new Vector3(0, 1, 0);
    private float zoom = 1f; // чувствительность при увеличении, колесиком мышки
    private float zoomMax = 6; // макс. увеличение
    private float zoomMin = 3; // мин. увеличение
    private float X, Y;
    private RaycastHit _hit;

    public CameraMoving(GameObject player, Camera camera)
    {
        _player = player;
        _camera = camera;
    }

    public void CameraMove(float _Xmouse, float _Ymouse, float _Scrollwheel)
    {
        if (_Scrollwheel > 0) { offset.z += zoom; }
        else if (_Scrollwheel < 0) { offset.z -= zoom; }
        offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));
        X = _camera.transform.localEulerAngles.y + _Xmouse * sensitivity;
        Y += _Ymouse * sensitivity;
        Y = Mathf.Clamp(Y, -limit, limit);
        _camera.transform.localEulerAngles = new Vector3(-Y, X, 0);
        _camera.transform.position = _camera.transform.localRotation * offset + _player.transform.position;
        CheckWall();
    }



    public void CheckWall()
    {
        if (Physics.Raycast(_player.transform.position, _camera.transform.position - _player.transform.position, out _hit, Vector3.Distance(_camera.transform.position, _player.transform.position)))
        {
            _camera.transform.position = _hit.point;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadarController : IExecute
{
	private Transform _playerPos; // Позиция главного героя
	private readonly float _mapScale = 2;
	private List<RadarObject> _radObjects = new List<RadarObject>();
	private Transform _canvasview; 

	public RadarController(List<RadarObject> radObjects, Transform canvasview)
    {
		_playerPos = Camera.main.transform;
		_radObjects = radObjects;
		_canvasview = canvasview.GetComponentInChildren<Image>().transform;
	}

	private void DrawRadarDots() // Синхронизирует значки на миникарте с реальными объектами
	{
		foreach (RadarObject radObject in _radObjects)
		{
			Vector3 radarPos = (radObject.Owner.position - _playerPos.position);
			float distToObject = Vector3.Distance(_playerPos.position, radObject.Owner.position) * _mapScale;
			float deltay = Mathf.Atan2(radarPos.x, radarPos.z) * Mathf.Rad2Deg - 270 - _playerPos.eulerAngles.y;
			radarPos.x = distToObject * Mathf.Cos(deltay * Mathf.Deg2Rad) * -1;
			radarPos.z = distToObject * Mathf.Sin(deltay * Mathf.Deg2Rad);
			radObject.Icon.transform.SetParent(_canvasview);
			radObject.Icon.transform.position = new Vector3(radarPos.x, radarPos.z, 0) + _canvasview.position;
		}
	}

	public void Execute()
    {
		if (Time.frameCount % 2 == 0)
		{
			DrawRadarDots();
		}
	}
}

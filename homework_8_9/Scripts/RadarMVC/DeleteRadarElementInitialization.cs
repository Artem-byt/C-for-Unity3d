using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteRadarElementInitialization : IInitialize
{

    private List<RadarObject> _radObjects = new List<RadarObject>();
	private IRadarDeleteIcon _radarDeleteIcon;

	public DeleteRadarElementInitialization(List<RadarObject> radObjects, IRadarDeleteIcon radarDeleteIcon)
    {
		_radObjects = radObjects;
		_radarDeleteIcon = radarDeleteIcon;
		_radarDeleteIcon.DeleteCompletedBonus += RemoveRadarObject;
	}
	public void RemoveRadarObject(GameObject o)
	{
		List<RadarObject> newList = new List<RadarObject>();
		foreach (RadarObject t in _radObjects)
		{
			if (t.Owner == o.transform)
			{
				Object.Destroy(t.Icon);
				continue;
            }
            else
            {
				newList.Add(t);
			}
			
		}
		_radObjects.RemoveRange(0, _radObjects.Count);
		_radObjects.AddRange(newList);
	}

	public IRadarDeleteIcon GetRadarDeleteIcon()
    {
		return _radarDeleteIcon;

	}

	public List<RadarObject> GetRadarObjects()
    {
		return _radObjects;

	}

	public void Initialize() 
    {
    }

}

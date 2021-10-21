using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadarInitialization : IInitialize
{

    public static List<RadarObject> RadObjects = new List<RadarObject>();

	public RadarInitialization(List<Transform> bonuses)
    {
		RegisterRadarObject(bonuses);
	}

	public void RegisterRadarObject(List<Transform> bonuses)
	{
		
		foreach (Transform element in bonuses)
		{
			Image image = Object.Instantiate(Resources.Load<Image>("RadarObject"));
			RadObjects.Add(new RadarObject { Owner = element, Icon = image });
		}
	}

	public List<RadarObject> GetRadarObjects()
    {
		return RadObjects;
    }


	public void Initialize()
    {

    }
}

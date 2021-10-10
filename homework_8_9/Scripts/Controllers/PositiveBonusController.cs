using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PositiveBonusController : IExecute
{
    private List<Transform> _positiveBonuses;
    private GameObject _player;
    private ISetSpeedPlayer _setspeed;
    private IRadarDeleteIcon _radardeleteIcon;
    private float currenttime;
    private float starttime;

    private const float distancebetweenplayerandbonus = 4f;

    public PositiveBonusController(List<Transform> bonuses, GameObject player, ISetSpeedPlayer setspeed, IRadarDeleteIcon radarDeleteIcon)
    {
        _radardeleteIcon = radarDeleteIcon;
        _setspeed = setspeed;
        _player = player;
        _positiveBonuses = new List<Transform>();
        currenttime = Time.time;
        for (int i = 0; i< bonuses.Count; i++)
        {
            if (bonuses[i].GetComponent<PositiveBonusIdentificator>())
            {
                _positiveBonuses.Add(bonuses[i]);
            }
        }
    }

    public void Execute()
    {

        for(int i = 0; i < _positiveBonuses.Count; i++)
        {
            if ((_player.transform.position - _positiveBonuses[i].position).magnitude < distancebetweenplayerandbonus)
            {
                starttime = Time.time;
                currenttime = Time.time;
                _radardeleteIcon.GetDelete(_positiveBonuses[i].gameObject);
                UnityEngine.Object.Destroy(_positiveBonuses[i].gameObject);
                _positiveBonuses.RemoveAt(i);
                _setspeed.SetSpeed(10f);
            }

        }

        currenttime += Time.deltaTime;
        if((currenttime - starttime) > 10f)
        {
            _setspeed.SetSpeed(1f);
        }

    }
}

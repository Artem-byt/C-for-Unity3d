using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeBonusController : IExecute
{
    private List<Transform> _negativeBonuses;
    private GameObject _player;
    private ISetSpeedPlayer _setspeed;
    private IRadarDeleteIcon _radardeleteIcon;
    private float currenttime;
    private float starttime;

    public NegativeBonusController(List<Transform> bonuses, GameObject player, ISetSpeedPlayer setspeed, IRadarDeleteIcon radarDeleteIcon)
    {
        _radardeleteIcon = radarDeleteIcon;
        _player = player;
        _setspeed = setspeed;
        _negativeBonuses = new List<Transform>();
        currenttime = Time.time;

        for (int i = 0; i < bonuses.Count; i++)
        {
            if (bonuses[i].GetComponent<NegativeBonusIdentificator>())
            {
                _negativeBonuses.Add(bonuses[i]);
            }
        }
    }

    public void Execute()
    {

        for (int i = 0; i < _negativeBonuses.Count; i++)
        {
            if (Vector3.Distance(_player.transform.position, _negativeBonuses[i].position) < 2f)
            {
                starttime = Time.time;
                currenttime = Time.time;
                _radardeleteIcon.GetDelete(_negativeBonuses[i].gameObject);
                Object.Destroy(_negativeBonuses[i].gameObject);
                _negativeBonuses.RemoveAt(i);
                _setspeed.SetSpeed(0.5f);
            }

        }

        currenttime += Time.deltaTime;
        if ((currenttime - starttime) > 10f)
        {
            _setspeed.SetSpeed(1f);
        }

    }
}

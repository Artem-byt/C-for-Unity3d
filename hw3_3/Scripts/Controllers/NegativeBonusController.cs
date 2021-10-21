using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeBonusController : IExecute
{
    private List<Transform> _positiveBonuses;
    private GameObject _player;
    private ISetSpeedPlayer _setspeed;
    private float currenttime;
    private float starttime;

    public NegativeBonusController(List<Transform> bonuses, GameObject player, ISetSpeedPlayer setspeed)
    {
        _player = player;
        _setspeed = setspeed;
        _positiveBonuses = new List<Transform>();
        currenttime = Time.time;

        for (int i = 0; i < bonuses.Count; i++)
        {
            if (bonuses[i].GetComponent<NegativeBonusIdentificator>())
            {
                _positiveBonuses.Add(bonuses[i]);
            }
        }
    }

    public void Execute()
    {

        for (int i = 0; i < _positiveBonuses.Count; i++)
        {
            if (Vector3.Distance(_player.transform.position, _positiveBonuses[i].position) < 2f)
            {
                starttime = Time.time;
                currenttime = Time.time;
                Object.Destroy(_positiveBonuses[i].gameObject);
                _positiveBonuses.RemoveAt(i);
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

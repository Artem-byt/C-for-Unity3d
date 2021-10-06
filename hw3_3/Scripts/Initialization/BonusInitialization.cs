using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusInitialization : IInitialize, IGetBonuses
{
    private List<Transform> _bonuses;

    public BonusInitialization(IBonusFactory bonusfactory)
    {
        _bonuses = bonusfactory.CreateBonus();
    }

    public void Initialize()
    {

    }

    public List<Transform> GetBonuses()
    {
        return _bonuses;
    }
}

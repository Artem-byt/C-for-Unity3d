using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelFactory
{
    public Transform CreateLevel(int numberoflvl);
}

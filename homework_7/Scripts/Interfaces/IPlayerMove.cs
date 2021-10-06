using UnityEngine;
public interface IPlayerMove: ISetSpeedPlayer
{
    public void PlayerMove(float x, float y, float z);
}

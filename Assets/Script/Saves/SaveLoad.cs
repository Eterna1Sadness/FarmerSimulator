using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    PlayerData data = SaveSystem.LoadPlayer();
    PlayerMovement player = new PlayerMovement();

    public void SavePlayer()
    {
        //SaveSystem.SavePlayer(player);

    }

    public void LoadPlayer()
    {
        Vector2 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];

        transform.position = new Vector3(position.x, position.y, 0);
    }
}

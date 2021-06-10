using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public float[] playerPosition;

    public float maxPositionX;
    public float maxPositionY;
    public float minPositionX;
    public float minPositionY;
    public float smooting;

    public float time;

    public string scene;

    public PlayerData(PlayerMovement player, CameraMovement camera, DayTimeController timeController, GameSceneManager currentScene)
    {
        playerPosition = new float[2];
        playerPosition[0] = player.transform.position.x;
        playerPosition[1] = player.transform.position.y;

        maxPositionX = camera.maxPosition.x;
        maxPositionY = camera.maxPosition.y;
        minPositionX = camera.minPosition.x;
        minPositionY = camera.minPosition.y;
        smooting = camera.smoothing;

        time = timeController.time;

        scene = currentScene.currentScene;
    }
}

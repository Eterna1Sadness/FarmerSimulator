using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedTile : ToolAction
{
    public override bool OnApplyToTileMap(Vector3Int gridPosition, TileMapReadController tileMapReadController)
    {
        if(tileMapReadController.cropsManager.Check(gridPosition) == false)
        {
            return false;
        }

        tileMapReadController.cropsManager.Seed(gridPosition);

        return true;
    }
}

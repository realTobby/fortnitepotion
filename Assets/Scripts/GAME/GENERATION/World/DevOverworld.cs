using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DevOverworld : IGenerationTemplate
{
    List<TileData> resultData = new List<TileData>();

    public List<TileData> Generate()
    {
        int baseGroundCount = Random.Range(5, 10);

        int posXOffset = 0;
        int posYOffset = 0;

        int randStartX = Random.Range(0, 3);
        int randStartY = Random.Range(0, 3);

        for(int i = 0; i < baseGroundCount+1;i++)
        {
            int width = Random.Range(10, 20);
            int height = Random.Range(10, 20);

            randStartX = randStartX + posXOffset;
            randStartY = randStartY + posYOffset;

            AddBaseGround(randStartX, randStartY, width, height);

            posXOffset = posXOffset + Random.Range(-3, 3);
            posYOffset = posYOffset + Random.Range(-3, 3);

        }

        CleanBorderTiles();


        return resultData;
    }

    private void CleanBorderTiles()
    {
        foreach(TileData tileData in resultData.ToList())
        {
            if(tileData.IsWalkable == false)
            {
                if (ShouldBeWalkable(tileData))
                {
                    resultData.Where(x => x.X == tileData.X && x.Y == tileData.Y).FirstOrDefault().IsWalkable = true;
                }
            }
            
        }
    }

    private bool ShouldBeWalkable(TileData data)
    {
        // get neighbours with x/y
        // if exactly 6 neighbours the tile should be actually walkable

        Vector2Int n1 = new Vector2Int(data.X - 1, data.Y - 1);
        Vector2Int n2 = new Vector2Int(data.X, data.Y - 1);
        Vector2Int n3 = new Vector2Int(data.X + 1, data.Y - 1);

        Vector2Int n4 = new Vector2Int(data.X - 1, data.Y);
        Vector2Int n5 = new Vector2Int(data.X + 1, data.Y);

        Vector2Int n6 = new Vector2Int(data.X - 1, data.Y + 1);
        Vector2Int n7 = new Vector2Int(data.X, data.Y + 1);
        Vector2Int n8 = new Vector2Int(data.X + 1, data.Y + 1);

        int walkableCount = 0;

        if (CheckTileWalkable(n1)) walkableCount++;
        if (CheckTileWalkable(n2)) walkableCount++;
        if (CheckTileWalkable(n3)) walkableCount++;
        if (CheckTileWalkable(n4)) walkableCount++;
        if (CheckTileWalkable(n5)) walkableCount++;
        if (CheckTileWalkable(n6)) walkableCount++;
        if (CheckTileWalkable(n7)) walkableCount++;
        if (CheckTileWalkable(n8)) walkableCount++;

        if(walkableCount >= 5)
        {
            return true;
        }

        return false;

    }

    private bool CheckTileWalkable(Vector2Int pos)
    {
        if(DoesTileExistAt(pos))
        {
            if (resultData.Where(x => x.X == pos.x && x.Y == pos.y).FirstOrDefault().IsWalkable) return true;
        }

        return false;
    }

    private bool DoesTileExistAt(Vector2Int pos)
    {
        return resultData.Exists(tile => tile.X == pos.x && tile.Y == pos.y);
    }

    private void AddBaseGround(int posx, int posy, int width, int height)
    {
        for (int y = posy; y < posy+height + 1; y++)
        {
            for (int x = posx; x < posx + width + 1; x++)
            {
                TileData nextTile = new TileData();
                nextTile.X = x;
                nextTile.Y = y;
                nextTile.IsWalkable = true;
                if (x == posx || x == posx + width || y == posy || y == posy + height)
                {
                    nextTile.IsWalkable = false;
                }


                if (DoesTileExistAt(new Vector2Int(x, y)))
                {
                    resultData.Remove(resultData.Find(tile => tile.X == x && tile.Y == y));
                }

                resultData.Add(nextTile);
            }
        }
    }


}

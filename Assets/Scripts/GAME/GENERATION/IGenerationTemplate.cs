using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGenerationTemplate
{
    List<TileData> Generate();
}

public class TileData
{
    public int X;
    public int Y;
    public bool IsWalkable;
}


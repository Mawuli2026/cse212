using System;
using System.Collections.Generic;

public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    private bool[] CurrentCell => _mazeMap[(_currX, _currY)];

    public void MoveLeft()
    {
        if (!CurrentCell[0])
            throw new InvalidOperationException("Can't go that way!");
        _currX -= 1;
    }

    public void MoveRight()
    {
        if (!CurrentCell[1])
            throw new InvalidOperationException("Can't go that way!");
        _currX += 1;
    }

    public void MoveUp()
    {
        if (!CurrentCell[2])
            throw new InvalidOperationException("Can't go that way!");
        _currY -= 1;
    }

    public void MoveDown()
    {
        if (!CurrentCell[3])
            throw new InvalidOperationException("Can't go that way!");
        _currY += 1;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}

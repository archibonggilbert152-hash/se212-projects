/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
using System;
using System.Collections.Generic;

public class Maze
{
    private (int x, int y) _current;
    private Dictionary<(int, int), bool[]> _map;

    // --------------------------------------------------
    // REQUIRED CONSTRUCTOR
    // --------------------------------------------------
    public Maze((int x, int y) start,
                Dictionary<(int, int), bool[]> map)
    {
        _current = start;
        _map = map;
    }

    // --------------------------------------------------
    // REQUIRED STATUS FORMAT
    // --------------------------------------------------
    public string GetStatus()
    {
        return $"Current location (x={_current.x}, y={_current.y})";
    }

    // --------------------------------------------------
    // MOVEMENT METHODS (throw on invalid)
    // --------------------------------------------------
    public void MoveLeft()
    {
        if (!_map[_current][0])
            throw new InvalidOperationException("Can't go that way!");

        _current = (_current.x - 1, _current.y);
    }

    public void MoveRight()
    {
        if (!_map[_current][1])
            throw new InvalidOperationException("Can't go that way!");

        _current = (_current.x + 1, _current.y);
    }

    public void MoveUp()
    {
        if (!_map[_current][2])
            throw new InvalidOperationException("Can't go that way!");

        _current = (_current.x, _current.y + 1);
    }

    public void MoveDown()
    {
        if (!_map[_current][3])
            throw new InvalidOperationException("Can't go that way!");

        _current = (_current.x, _current.y - 1);
    }
}

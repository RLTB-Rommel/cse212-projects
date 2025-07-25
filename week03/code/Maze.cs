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

/// /// I will now do Problem 4 involving Maze

/// I understand that maze is a dictionary where each key is a (x, y) coordinate
/// the boolean tells whether a move in a certain direction is allowed from that tile
/// I will maintain the current position as (x,y)
/// the implementation logic will be:
/// a) check if the direction is allowed from the current tile
/// b) If allowed update the current position (x, y)
/// c) If not allowed throw an InvalidOperationException

/// the movemovent is limited to inside the maze (1 <= x <= 6, 1 <= Y <= 6 )
/// the four methods to use will be MoveLeft(), MoveRight(), MoveUp(), MoveDown()

/// The process will be:
/// 1. Check if the direction is valid using the maze dictionary
/// 2. If it is a yes, update x or y
/// 3. If no, throw an exception

/// Example In MoveLeft():
/// - use the current position to look up the allowed directions in the maze
/// - if the left direction is true, subtract 1 from x, which means move x
/// - if false, throw an error because there's a wall

/// coordinate of (x, y) maps to bool[] of :
/// [left, right, up, down]
/// index 0 can move left
/// index 1 can move right
/// index 2 can move up
/// index 3 can move down 

/// I ran the test and found out that I can't change the InvalidOperationException message since it's an automated grading. So I used the expected message for the error which is:
/// "Can't go that way!"
/// I also need to add boundary protection code to the program
/// I ran the test and the Maze movements passed


public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // FILL IN CODE
        // the directionns array contains 4 boolean values:
        //[0] = left, [1] = right, [2] = up, [3] = down
        bool[] directions = _mazeMap[(_currX, _currY)]; //this get the allowed directions for the current (x, y) location
        if (directions[0])// if this is true then it is acceptable to move left
        {
            //moving left means the new position if we move left;
            //moving left means decreasing the x coordinate by 1
            var newKey = (_currX - 1, _currY);

            //now to check, if the new position exists in the maze map
            //even if the direction is allowed, we must verify that the destination cell exists
            if (_mazeMap.ContainsKey(newKey))
                _currX--;//decrease x to move left
            else
                throw new InvalidOperationException("Can't go that way!");// if the new cell doesn't exists throws an error
        }
        else
        {
                throw new InvalidOperationException("Can't go that way!");// if the direction is not allowed throw an error because there is a wall.

        }

    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // FILL IN CODE
        // I will just copy the code above and just change small details to make it work for moving right
        bool[] directions = _mazeMap[(_currX, _currY)]; //this get the allowed directions for the current (x, y) location
        if (directions[1])// changed [0] to [1], if this is true then it is acceptable to move right
        {
            //moving right means the new position if we move right;
            //moving right means increasing the x coordinate by 1
            var newKey = (_currX + 1, _currY);

            //now to check, if the new position exists in the maze map
            //even if the direction is allowed, we must verify that the destination cell exists
            if (_mazeMap.ContainsKey(newKey))
                _currX++;//increase x to move right
            else
                throw new InvalidOperationException("Can't go that way!");// if the new cell doesn't exists throw an error
        }
        else
        {
                throw new InvalidOperationException("Can't go that way!");// if the direction[1] is not allowed throw an error because there is a wall.

        }

    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // FILL IN CODE
        // Similarly, I will just copy the code above and just change small details to make it work for moving up
        bool[] directions = _mazeMap[(_currX, _currY)]; //this get the allowed directions for the current (x, y) location
        if (directions[2])// changed [1] to [2], if this is true then it is acceptable to move up
        {
            //moving up means the new position if we move up;
            //moving up means decreasing the y coordinate by 1
            var newKey = (_currX, _currY -1);

            //now to check, if the new position exists in the maze map
            //even if the direction is allowed, we must verify that the destination cell exists
            if (_mazeMap.ContainsKey(newKey))
                _currY--;//decrease Y to go up
            else
                throw new InvalidOperationException("Can't go that way!");// if the new cell doesn't exists throw an error
        }
        else
        {
                throw new InvalidOperationException("Can't go that way!");// if the direction[2] is not allowed throw an error because there is a wall.

        }

    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // FILL IN CODE
        //I will just copy the code which is directly above this then just change small details to make it work for moving 
        bool[] directions = _mazeMap[(_currX, _currY)]; //this get the allowed directions for the current (x, y) location
        if (directions[3])// changed [2] to [3], if this is true then it is acceptable to move up
        {
            //moving down means the new position if we move down;
            //moving down means increasing the y coordinate by 1
            var newKey = (_currX, _currY +1);

            //now to check, if the new position exists in the maze map
            //even if the direction is allowed, we must verify that the destination cell exists
            if (_mazeMap.ContainsKey(newKey))
                _currY++;//increase Y to go up
            else
                throw new InvalidOperationException("Can't go that way!");// if the new cell doesn't exists throw an error
        }
        else
        {
                throw new InvalidOperationException("Can't go that way!");// if the direction[3] is not allowed throw an error because there is a wall.

        }

    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";// this just returns the current coordinates  in a readable string format
    }
}
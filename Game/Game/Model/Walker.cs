using System.Collections.Generic;
using System.Windows;

namespace Game.Model
{
    /// <summary>
    /// Class meant to be extended by moving Props. Handles movement. Creating an instance of this class is not possible
    /// </summary>
    internal class Walker : Prop
    {
        protected bool canMoveThroughWalls = false;
        protected double movementSpeed;

        /// <summary>
        /// Creates the walker
        /// </summary>
        /// <param name="positionPoint">The point of the Walker</param>
        protected Walker(Point positionPoint) : base(positionPoint)
        {
        }

        /// <summary>
        /// Checks if a walker can and wants to move and then moves it
        /// </summary>
        /// <param name="horizontal">The Horizontal direction(Left, Right or none)</param>
        /// <param name="vertical">The Vertical direction(Up, Down or none)</param>
        /// <param name="obstacles">A list of all the Obstacles the walker can't move through</param>
        protected void Move(HorizontalDirection horizontal, VerticalDirection vertical, List<Obstacle> obstacles)
        {
            //if both directions are none the walker doesn't want to move
            if (horizontal == HorizontalDirection.none && vertical == VerticalDirection.none)
                return;
            var y = Position.Y;
            var x = Position.X;

            //get if the walker wants to move and check if the walker is at one of the edges if so don't allow it to move through the edge
            var moveRight = horizontal == HorizontalDirection.right && x + Size.X + movementSpeed < World.windowWidth;
            var moveLeft = horizontal == HorizontalDirection.left && x - movementSpeed >= 0;
            var moveDown = vertical == VerticalDirection.down && y + Size.Y + movementSpeed < World.windowHeight;
            var moveUp = vertical == VerticalDirection.up && y - movementSpeed >= 0;
            //some Walkers like Enemy.Ghost can move through walls so skip all obstacle collision detection for these Walkers
            if (!canMoveThroughWalls)
                foreach (var obstacle in obstacles)
                {
                    //if all directions are false stop the loop
                    if (!(moveUp || moveDown || moveLeft || moveRight))
                        break;
                    //check if the walker is not colliding with an object to its right
                    if (moveRight && Position.X + Size.X + movementSpeed > obstacle.Position.X &&
                        Position.X + Size.X + movementSpeed < obstacle.Position.X + obstacle.Size.X &&
                        Position.Y < obstacle.Position.Y + obstacle.Size.Y && obstacle.Position.Y < Position.Y + Size.Y)
                        moveRight = false;
                    else if (moveLeft && Position.X - movementSpeed < obstacle.Position.X + obstacle.Size.X &&
                             Position.X - movementSpeed > obstacle.Position.X &&
                             Position.Y < obstacle.Position.Y + obstacle.Size.Y &&
                             obstacle.Position.Y < Position.Y + Size.Y) moveLeft = false;
                    if (moveDown && Position.Y + Size.Y + movementSpeed > obstacle.Position.Y &&
                        Position.Y + Size.Y + movementSpeed < obstacle.Position.Y + obstacle.Size.Y &&
                        Position.X < obstacle.Position.X + obstacle.Size.X && obstacle.Position.X < Position.X + Size.X)
                        moveDown = false;
                    else if (moveUp && Position.Y - movementSpeed < obstacle.Position.Y + obstacle.Size.Y &&
                             Position.Y - movementSpeed > obstacle.Position.Y &&
                             Position.X < obstacle.Position.X + obstacle.Size.X &&
                             obstacle.Position.X < Position.X + Size.X) moveUp = false;
                }

            //if the Walker is still allowed to move move it
            if (moveUp) y -= movementSpeed;
            if (moveDown) y += movementSpeed;
            if (moveLeft) x -= movementSpeed;
            if (moveRight) x += movementSpeed;
            Position = new Point(x, y);
        }

        /// <summary>
        /// Enumerator for horizontal direction
        /// </summary>
        protected enum HorizontalDirection
        {
            left,
            right,
            none
        }
        /// <summary>
        /// Enumerator for vertical direction
        /// </summary>
        protected enum VerticalDirection
        {
            up,
            down,
            none
        }
    }
}
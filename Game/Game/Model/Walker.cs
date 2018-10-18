using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using Point = System.Windows.Point;

namespace Game.Model
{
    class Walker : Prop
    {
        protected enum HorizontalDirection { left,right, none};
        protected enum VerticalDirection { up, down, none}
        protected bool canMoveThroughWalls = false;
        protected double movementSpeed;

        protected Walker(Point positionPoint) : base(positionPoint)
        {

        }

        protected Walker(Point position, Point size, string image) : base(position, size, image)
        {
            Position = position;
            Size = size;
            Image = image;
        }

        protected Walker(Point position, string image) : base(position, image)
        {
            Position = position;
            Image = image;
        }

        /// <summary>
        /// Checks if a walker can and wants to move and then moves it
        /// </summary>
        /// <param name="horizontal">The Horizontal direction(Left, Right or none)</param>
        /// <param name="vertical">The Vertical direction(Up, Down or none)</param>
        /// <param name="obstacles">A list of all the obstacles the walker can't move through</param>
        protected void Move(HorizontalDirection horizontal, VerticalDirection vertical, List<Obstacle> obstacles)
        {
            //if both directions are none the walker doesn't want to move
            if (horizontal == Walker.HorizontalDirection.none && vertical == Walker.VerticalDirection.none)
                return;
            double y = Position.Y;
            double x = Position.X;
            
            //get if the walker wants to move and check if the walker is at one of the edges if so don't allow it to move through the edge
            bool moveRight = horizontal == HorizontalDirection.right && x + Size.X + movementSpeed < World.windowWidth;
            bool moveLeft = horizontal == HorizontalDirection.left && x - movementSpeed >= 0;
            bool moveDown = vertical == VerticalDirection.down && y + Size.Y + movementSpeed < World.windowHeight;
            bool moveUp = vertical == VerticalDirection.up && y - movementSpeed >= 0;
            //some Walkers like Enemy.Ghost can move through walls so skip all obstacle collision detection for these Walkers
            if (!canMoveThroughWalls)
            {
                foreach (Obstacle obstacle in obstacles)
                {
                    //if all directions are false stop the loop
                    if (!(moveUp || moveDown || moveLeft || moveRight))
                        break;
                    //check if the walker is not colliding with an object to its right
                    if (moveRight && 
                        //checks if x AND y position in the next tick overlap with the object
                        ((Position.X + Size.X + movementSpeed > obstacle.Position.X) && (Position.X + Size.X + movementSpeed < obstacle.Position.X + obstacle.Size.X) &&
                        (Position.Y < obstacle.Position.Y + obstacle.Size.Y) && (obstacle.Position.Y < Position.Y + Size.Y)))
                    {
                        moveRight = false;
                    }
                    else if (moveLeft && ((Position.X - movementSpeed < obstacle.Position.X + obstacle.Size.X) && (Position.X - movementSpeed > obstacle.Position.X) &&
                        (Position.Y < obstacle.Position.Y + obstacle.Size.Y) && (obstacle.Position.Y < Position.Y + Size.Y)))
                    {
                        moveLeft = false;
                    }
                    if (moveDown && ((Position.Y + Size.Y + movementSpeed > obstacle.Position.Y) && (Position.Y + Size.Y + movementSpeed < obstacle.Position.Y + obstacle.Size.Y) &&
                        (Position.X < obstacle.Position.X + obstacle.Size.X) && (obstacle.Position.X < Position.X + Size.X)))
                    {
                        moveDown = false;
                    }
                    else if (moveUp && ((Position.Y - movementSpeed < obstacle.Position.Y + obstacle.Size.Y) && (Position.Y - movementSpeed > obstacle.Position.Y) &&
                        (Position.X < obstacle.Position.X + obstacle.Size.X) && (obstacle.Position.X < Position.X + Size.X)))
                    {
                        moveUp = false;
                    }
                    

                }
            }
            //if the Walker is still allowed to move move it
            if (moveUp)
            {
                y -= movementSpeed;
            }
            if (moveDown)
            {
                y+= movementSpeed;
            }
            if (moveLeft)
            {
                x-= movementSpeed;
            }
            if (moveRight)
            {
                x += movementSpeed;
            }
            Position = new Point(x, y);
        }
    }
}
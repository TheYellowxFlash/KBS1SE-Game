using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = System.Windows.Point;

namespace Game.Model
{
    class Walker : Prop
    {
        public enum HorizontalDirection { left,right, none};
        public enum VerticalDirection { up, down, none}

        public Walker(Point point) : base(point)
        {

        }

        public void Move(HorizontalDirection horizontal, VerticalDirection vertical, List<Obstacle> obstacles, double movementSpeed,bool canMoveThroughWalls = false)
        {
            //if both directions are none the walker doesn't want to move
            if (horizontal == Walker.HorizontalDirection.none && vertical == Walker.VerticalDirection.none)
                return;
            double y = Position.Y;
            double x = Position.X;
            
            bool moveRight = horizontal == HorizontalDirection.right;
            bool moveLeft = horizontal == HorizontalDirection.left;
            bool moveDown = vertical == VerticalDirection.down;
            bool moveUp = vertical == VerticalDirection.up;
            if (!canMoveThroughWalls)
            {
                foreach (var obstacle in obstacles)
                {

                    if (moveRight && (Position.X + Size.X == obstacle.Position.X && (
                        ((Position.Y + Size.Y < obstacle.Position.Y + obstacle.Size.Y) && (Position.Y + Size.Y > obstacle.Position.Y)) ||
                        ((Position.Y < obstacle.Position.Y + obstacle.Size.Y) && (Position.Y > obstacle.Position.Y)))
                        ))
                    {
                        moveRight = false;
                    }
                    else if (moveLeft && (Position.X == obstacle.Position.X + obstacle.Size.X && (
                        ((Position.Y + Size.Y < obstacle.Position.Y + obstacle.Size.Y) && (Position.Y + Size.Y > obstacle.Position.Y)) ||
                        ((Position.Y < obstacle.Position.Y + obstacle.Size.Y) && (Position.Y > obstacle.Position.Y)))
                        ))
                    {
                        moveLeft = false;
                    }
                    if (moveDown && (Position.Y + Size.Y == obstacle.Position.Y && (
                        ((Position.X + Size.X < obstacle.Position.X + obstacle.Size.X) && (Position.X + Size.X > obstacle.Position.X)) ||
                        ((Position.X < obstacle.Position.X + obstacle.Size.X) && (Position.X > obstacle.Position.X)))
                        ))
                    {
                        moveDown = false;
                    }
                    else if (moveUp && (Position.Y == obstacle.Position.Y + obstacle.Size.Y && (
                        ((Position.X + Size.X < obstacle.Position.X + obstacle.Size.X) && (Position.X + Size.X > obstacle.Position.X)) ||
                        ((Position.X < obstacle.Position.X + obstacle.Size.X) && (Position.X > obstacle.Position.X)))
                        ))
                    {
                        moveUp = false;
                    }
                    //if all directions are false stop the loop
                    if (!(moveUp || moveDown || moveLeft || moveRight))
                        break;

                }
            }
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

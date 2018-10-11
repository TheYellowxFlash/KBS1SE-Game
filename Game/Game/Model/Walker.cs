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
        public bool canMoveThroughWalls = false;
        public double movementSpeed;

        public Walker(Point positionPoint) : base(positionPoint)
        {

        }

        public Walker(Point position, Point size, String image) : base(position, size, image)
        {
            Position = position;
            Size = size;
            Image = image;
        }

        public Walker(Point position, String image) : base(position, image)
        {
            Position = position;
            Image = image;
        }

        protected void Move(HorizontalDirection horizontal, VerticalDirection vertical, List<Obstacle> obstacles)
        {
            //if both directions are none the walker doesn't want to move
            if (horizontal == Walker.HorizontalDirection.none && vertical == Walker.VerticalDirection.none)
                return;
            double y = Position.Y;
            double x = Position.X;
            
            bool moveRight = horizontal == HorizontalDirection.right && x + Size.X != World.windowWidth;
            bool moveLeft = horizontal == HorizontalDirection.left && x != 0;
            bool moveDown = vertical == VerticalDirection.down && y + Size.Y != World.windowHeight;
            bool moveUp = vertical == VerticalDirection.up && y != 0;
            if (!canMoveThroughWalls)
            {
                foreach (var obstacle in obstacles)
                {
                    //if all directions are false stop the loop
                    if (!(moveUp || moveDown || moveLeft || moveRight))
                        break;

                    if (moveRight && (Position.X + Size.X == obstacle.Position.X && 
                        (Position.Y < obstacle.Position.Y + obstacle.Size.Y) && (obstacle.Position.Y < Position.Y + Size.Y)))
                    {
                        moveRight = false;
                    }
                    else if (moveLeft && (Position.X == (int)(obstacle.Position.X + obstacle.Size.X) && 
                        (Position.Y < obstacle.Position.Y + obstacle.Size.Y) && (obstacle.Position.Y < Position.Y + Size.Y)))
                    {
                        moveLeft = false;
                    }
                    if (moveDown && (Position.Y + Size.Y == (int)(obstacle.Position.Y) && 
                        (Position.X < obstacle.Position.X + obstacle.Size.X) && (obstacle.Position.X < Position.X + Size.X)))
                    {
                        moveDown = false;
                    }
                    //a.start < b.end && b.start < a.end;
                    else if (moveUp && (Position.Y == (int)(obstacle.Position.Y + obstacle.Size.Y) && (Position.X < obstacle.Position.X + obstacle.Size.X) && (obstacle.Position.X < Position.X + Size.X)))
                    {
                        moveUp = false;
                    }
                    

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

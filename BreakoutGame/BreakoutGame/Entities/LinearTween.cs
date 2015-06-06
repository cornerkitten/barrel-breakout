using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mabv.Breakout.Entities
{
    public class LinearTween
    {
        private ITransform transform;
        private Vector2 stepToEnd;
        private Vector2 startLocation;
        private Vector2 endLocation;
        private bool isMovingToStart;
        private bool isMovingToEnd;

        public LinearTween(ITransform transform, float speed, Vector2 startLocation, Vector2 endLocation)
        {
            this.transform = transform;
            this.startLocation = startLocation;
            this.endLocation = endLocation;
            this.stepToEnd = (this.endLocation - this.startLocation) * speed;
            this.isMovingToEnd = false;
            this.isMovingToStart = false;
        }

        public void Init()
        {
            transform.Location = startLocation;
            isMovingToStart = false;
            isMovingToEnd = false;
        }

        public void Update()
        {
            if (isMovingToStart)
            {
                Vector2 newLocation = transform.Location - stepToEnd;
                if (isPassingTarget(transform.Location, newLocation, startLocation))
                {
                    transform.Location = startLocation;
                    isMovingToStart = false;
                }
                else
                {
                    transform.Location = newLocation;
                }
            }
            if (isMovingToEnd)
            {
                Vector2 newLocation = transform.Location + stepToEnd;
                if (isPassingTarget(transform.Location, newLocation, endLocation))
                {
                    transform.Location = endLocation;
                    isMovingToEnd = false;
                }
                else
                {
                    transform.Location = newLocation;
                }
            }
        }

        public void MoveToStart()
        {
            this.isMovingToEnd = false;
            this.isMovingToStart = true;
        }

        public void MoveToEnd()
        {
            this.isMovingToStart = false;
            this.isMovingToEnd = true;
        }

        private bool isPassingTarget(Vector2 startLocation, Vector2 targetLocation, Vector2 testLocation)
        {
            bool isPassingX = (startLocation.X <= testLocation.X && testLocation.X <= targetLocation.X) || (startLocation.X >= testLocation.X && testLocation.X >= targetLocation.X);
            bool isPassingY = (startLocation.Y <= testLocation.Y && testLocation.Y <= targetLocation.Y) || (startLocation.Y >= testLocation.Y && testLocation.Y >= targetLocation.Y);

            return (isPassingX && isPassingY);
        }
    }
}

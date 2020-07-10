using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public interface IControlObjectWithSpecificKeys
    {
        void ChangeVelocityOrAngleRotationAngle(KeyCode key, float valueAngleOrVelocity);
    }
    public class ControlObjectWithSpecificKeys : IControlObjectWithSpecificKeys
    {
        private StrategyForChangeAngleAndVelocity strategy;
        public ControlObjectWithSpecificKeys()
        {
            strategy = new StrategyForChangeAngleAndVelocity();
        }
        public float angle { get; private set; }
        public float velocity { get; private set;}
        public float angleRotation { get; private set; }
        public void ChangeVelocityOrAngleRotationAngle(KeyCode key, float valueAngleOrVelocity)
        {
            if ((key == KeyCode.RightArrow || key == KeyCode.LeftArrow))
            {
                this.angle = strategy.StrategyTochange(key, valueAngleOrVelocity);
            }
            if (key == KeyCode.DownArrow || key == KeyCode.UpArrow)
            {
                this.velocity = strategy.StrategyTochange(key, valueAngleOrVelocity);
            }
            if (key == KeyCode.A || key == KeyCode.D)
            {
                this.angleRotation = strategy.StrategyTochange(key, valueAngleOrVelocity);
            }
        }
    }
}

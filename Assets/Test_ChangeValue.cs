using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
  
    public class PropertiesToChange
    {
        public float angle { get; set; }
        public float velocity { get; set; }
        public float angleRotation { get; set; }
    }
    public class StrategyForChangeAngleAndVelocity
    {
        private IChangeVelocityAndAngle ichangeVelocityAngle;
        public StrategyForChangeAngleAndVelocity()
        {
            this.ichangeVelocityAngle = new ChangeValueVelocityAndAngle();
        }
        public float StrategyTochange(KeyCode key, float valueToChange)
        {
            if (key == KeyCode.RightArrow || key == KeyCode.LeftArrow)
            {
                return ichangeVelocityAngle.WhenKeyPressChangeValueAngle(key, valueToChange);
            }
            if (key == KeyCode.DownArrow || key == KeyCode.UpArrow)
            {
                return ichangeVelocityAngle.WhenKeyPressChangeValueVelocity(key, valueToChange);
            }
            if (key == KeyCode.A || key == KeyCode.D)
            {
                return ichangeVelocityAngle.WhenKeyPressChangeValueVelocity(key, valueToChange);
            }
            return valueToChange;
        }
       

    }
}

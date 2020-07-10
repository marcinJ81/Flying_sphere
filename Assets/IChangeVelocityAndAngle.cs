using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Reflection;

namespace Assets
{
 
    public interface IChangeVelocityAndAngle
    {
       float  WhenKeyPressChangeValueAngle(KeyCode key, float angle);
       float  WhenKeyPressChangeValueVelocity(KeyCode key, float velocity);
       float WhenKeyPressChangeValue(KeyCode key, float valueToChange);
       float WhenKeyPressChangeValueAngleRotation(KeyCode key, float angleRotation);
    }

    public class ChangeValueVelocityAndAngle : IChangeVelocityAndAngle
    {
        public float WhenKeyPressChangeValue(KeyCode key, float valueToChange)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow))
            {
                   return valueToChange += 1;
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                    return valueToChange -= 1;
            }
            return valueToChange;
        }

        public float WhenKeyPressChangeValueAngle(KeyCode key, float angle)
        {          
            if (Input.GetKey(KeyCode.RightArrow))
            {
               
                if (angle < SGlobalBpropertiesValue.MAX_ANGLE)
                {
                   angle += 1;
                    return angle;
                }
            }
            //decrease angle
            if (Input.GetKey(KeyCode.LeftArrow))
            {
               
                if (angle > SGlobalBpropertiesValue.MIN_ANGLE)
                {
                   angle -= 1;
                    return angle;
                }
            }
            return angle;
        }

        public float WhenKeyPressChangeValueAngleRotation(KeyCode key, float angleRotation)
        {
            if (Input.GetKey(KeyCode.D))
            {

                if (angleRotation < SGlobalBpropertiesValue.MAX_ANGLE_ROTATION)
                {
                    angleRotation += 1;
                    return angleRotation;
                }
            }
            //decrease angle
            if (Input.GetKey(KeyCode.A))
            {

                if (angleRotation > SGlobalBpropertiesValue.MIN_ANGLE_ROTATION)
                {
                    angleRotation -= 1;
                    return angleRotation;
                }
            }
            return angleRotation;
        }

        public float WhenKeyPressChangeValueVelocity(KeyCode key,  float velocity)
        {
            
            //decrease velocity
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (velocity > SGlobalBpropertiesValue.MIN_VELOCITY)
                {
                    velocity -= 1;
                    return velocity;
                }
            }
            //increase velocity
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (velocity < SGlobalBpropertiesValue.MAX_VELOCITY)
                {
                    velocity += 1;
                    return velocity;
                }
            }
            return velocity;
        }
    }
}

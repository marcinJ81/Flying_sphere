using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    /// <summary>
    /// https://www.altcontroldelete.pl/artykuly/konstrukcyjny-wzorzec-projektowy-singleton-implementacja-w-c-/
    /// </summary>
    public sealed class SGlobalBpropertiesValue
    {
         static  SGlobalBpropertiesValue()
        {
            MIN_ANGLE = 1f;
            MAX_ANGLE = 89f;
            MIN_VELOCITY = 1f;
            MAX_VELOCITY = 100f;
            MAX_SWING_ANGLE = 189f;
            MIN_SWING_ANGLE = 1f;
            START_SWING_ANGLE = 90f;
            MIN_ANGLE_ROTATION = 0F;
            MAX_ANGLE_ROTATION = 180F;
        }
        private SGlobalBpropertiesValue() { }

        public static float MIN_ANGLE { get; private set; }
        public static float MAX_ANGLE { get; private set; }
        public static float MIN_VELOCITY { get; private set; }
        public static float MAX_VELOCITY { get; private set; }
        public static float MAX_SWING_ANGLE { get; private set; }
        public static float MIN_SWING_ANGLE { get; private set; }
        public static float START_SWING_ANGLE { get; private set; }
        public static float MIN_ANGLE_ROTATION { get; private set; }
        public static float MAX_ANGLE_ROTATION { get; private set; }

    }
}

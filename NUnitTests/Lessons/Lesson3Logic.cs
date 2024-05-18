namespace NUnitTests.Lessons
{
    //Lesson Suite Logic
    public class Lesson3Logic
    {
        #region[TestSetup]

        public int Speed { get; set; }
        public int Acceleration { get; set; }
        public string? Alert { get; set; }
        public bool IsDecelerationChargeActive { get; set; }
        public int Deceleration { get; set; }
        public int DecelerationCharge { get; set; }
        public int Charge { get; set; }

        //Mock values - change at will
        public int CurrentSpeed = 50;
        public int CurrentAcceleration = 50;
        public int CurrentDeceleration = 30;

        // Default values, change with caution
        internal static int MaxSpeed = 100;
        internal static int MinSpeed = 60;
        internal static int MaxAcceleration = 90;

        public static readonly int CriticalCharge = 10;
        public static readonly int CriticalOvercharge = 98;
        public bool AccelerationAllowed;
        public bool DecelerationChargeMode = true;
        #endregion

        #region[Methods]

        public void GetAcceleration()
        {
            //TODO set acceleration as CurrentAcceleration
            //Acceleration = CurrentAcceleration;
            Acceleration = CurrentAcceleration;
        }

        public void GetSpeed()
        {
            //TODO if acceleration is more than 0 set speed as current speed
            if (Acceleration > 0)
            {

                //Speed = CurrentSpeed;
                Speed = CurrentSpeed;
            }
        }
        public void GetDeceleration()
        {
            //TODO if acceleration is more than 0 set deceleration as CurrentSpeed - CurrentDeceleration
            if (Acceleration > 0)
            {

                //Deceleration = CurrentSpeed - CurrentDeceleration;
                Deceleration = CurrentSpeed - CurrentDeceleration;
            }
        }
        public void SetSpeedAlert(int speed, int maxSpeed)
        {
            //TODO if current speed EXCEEDS max speed AND acceleration is more than 0 show speed alert
            if (CurrentSpeed > maxSpeed && Acceleration > 0)
            {
                //Alert = "Take caution! Speed limit overdue " + (speed - maxSpeed) + "!";
                Alert = "Take caution! Speed limit overdue " + (speed - maxSpeed) + "!";
            }
        }
        public void SetChargeAlert()
        {   //TODO if Charge lower or equal critical charge show alert
            //if (Charge <= CriticalCharge)
            //{
            //    Alert = "Take caution! Charge Low at " + Charge + "%!";
            //}

            if (Charge <= CriticalCharge)
            {
                Alert = "Take caution! Charge Low at " + Charge + "%!";
            }
            //TODO if Charge higher or equal CriticalOvercharge show alert

            //if (Charge >= CriticalOvercharge)
            //{
            //    Alert = "Charge Full! Deceleration charging disabled.";
            //}

            if (Charge >= CriticalOvercharge)
            {
                Alert = "Charge Full! Deceleration charging disabled.";
            }
        }

        public void Accelerate(int acceleratePedalValue)
        {
            if (Speed <= MaxSpeed + 20)
            {
                AccelerationAllowed = true;
            }

            while (AccelerationAllowed)
            {
                // Only continue accelerating if it's allowed and Speed has not exceeded the limit
                Acceleration = acceleratePedalValue;

                Speed = (Speed <= MaxSpeed + 20) ? (Speed + 1) : (Speed); // (if true) ? (then do this) : (if false)
                if (Speed > MaxSpeed + 20) { break; }
                //Acceleration = acceleratePedalValue;
                //if (Speed <= MaxSpeed + 20)
                //{ Speed++ };
                //else { break; }
            }
        }

        /// <summary>
        /// Activates or deactivates the deceleration charge based on the current charge level relative to a specified critical overcharge threshold.
        /// </summary>
        /// <param name="isActive">A boolean value indicating whether the deceleration charge should be attempted to activate.</param>
        /// <param name="criticalOvercharge">An integer representing the critical overcharge threshold which must not be exceeded for activation.</param>
        /// <returns>A boolean indicating the activation status of the deceleration charge. Returns true if the charge is activated, otherwise false.</returns>
        public bool DecelerationChargeActivation(bool isActive, int criticalOvercharge)
        {

            IsDecelerationChargeActive = isActive && Charge < criticalOvercharge;
            return IsDecelerationChargeActive;
            //if (isActive && Charge < criticalOvercharge)
            //{
            //    return IsDecelerationChargeActive = true;
            //}
            //else
            //{
            //    return IsDecelerationChargeActive = false;
            //}
        }

        /// <summary>
        /// Calculates and returns the deceleration charge power based on the current speed and acceleration.
        /// If the feature is active, the deceleration charge is computed by subtracting the current acceleration from the current speed.
        /// If the feature is not active, the method returns 0.
        /// </summary>
        /// <param name="isActive">A boolean flag indicating whether the deceleration charge feature should be active.</param>
        /// <returns>The deceleration charge if the feature is active, otherwise 0.</returns>
        public int GetDecelerationChargePower(bool isActive)
        {

            DecelerationCharge = isActive ? CurrentSpeed - CurrentAcceleration : 0;
            return DecelerationCharge;
            //if (isActive)
            //{
            //    DecelerationCharge = CurrentSpeed - CurrentAcceleration;
            //    return DecelerationCharge;
            //}
            //else
            //{
            //    return DecelerationCharge = 0;
            //}
        }
        #endregion
    }
}

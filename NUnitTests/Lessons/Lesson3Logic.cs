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
        public static int MaxSpeed = 100;
        public static int MinSpeed = 60;
        public static int MaxAceleration = 90;
        public static readonly int CriticalCharge = 10;
        public static readonly int CriticalOvercharge = 98;
        public bool AccelerationAllowed;
        public bool DecelerationChargeMode = true;
        #endregion

        #region[Methods]

        public void GetAcceleration()
        {
            //TODO set acceleration as CurrentAcceleration
            Acceleration = CurrentAcceleration;
        }

        public void GetSpeed()
        {
            //TODO if acceleration is more than 0 set speed as current speed
            if (Acceleration > 0)
            {
                Speed = CurrentSpeed;
            }
        }

        public void GetDeceleration()
        {
            //TODO if acceleration is more than 0 set deceleration as CurrentSpeed - CurrentDeceleration
            if (Acceleration > 0)
            {
                Deceleration = CurrentSpeed - CurrentDeceleration;
            }
        }

        public void SetSpeedAlert(int speed, int maxSpeed)
        {
            //TODO if current speed EXCEEDS maxsspeed AND acceleration is more than 0 show speed alert
            if (CurrentSpeed >= maxSpeed && Acceleration > 0)
            {
                Alert = "Take caution! Speed limit overdue " + (speed - maxSpeed) + "!";
            }
        }

        public void SetChargeAlert()
        {   //TODO if Charge lower or equal critical charge show alert
            if (Charge <= CriticalCharge)
            {
                Alert = "Take caution! Charge Low at " + Charge + "%!";
            }
            //TODO if Charge higher or equal CriticalOvercharge show alert
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

                if (Speed <= MaxSpeed + 20)
                {
                    Speed++;
                }
                else { break; }
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
            if (isActive && Charge < criticalOvercharge)
            {
                return IsDecelerationChargeActive = true;
            }
            else
            {
                return IsDecelerationChargeActive = false;
            }
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
            if (isActive)
            {
                DecelerationCharge = CurrentSpeed - CurrentAcceleration;
                return DecelerationCharge;
            }
            else
            {
                return DecelerationCharge = 0;
            }
        }
        #endregion

        #region[TestCases]
        //TODO: TestCases
        //Test Case 1: Test Acceleration
        //Description: Ensure that the method GetAcceleration correctly retrieves the current acceleration value.
        //Steps:
        //Initialize an instance of Lesson3Logic.
        //Call the GetAcceleration method.
        //Verify that the Acceleration property matches CurrentAcceleration.

        //Test Case 2: Test GetSpeed with Positive Acceleration
        //Description: Verify that GetSpeed correctly assigns the current speed to the Speed property when the acceleration is positive.
        //Steps:
        //Set CurrentAcceleration to a positive value.
        //Call the GetSpeed method.
        //Check that Speed equals CurrentSpeed.

        //Test Case 3: Test GetDeceleration
        //Description: Check if GetDeceleration correctly calculates deceleration as the difference between current speed and deceleration.
        //Steps:
        //Set a known value for CurrentSpeed and CurrentDeceleration.
        //Invoke GetDeceleration.
        //Ensure Deceleration equals CurrentSpeed - CurrentDeceleration.

        //Test Case 4: Speed Alert on Exceeding Max Speed
        //Description: Validate that SetSpeedAlert generates the correct alert when the speed exceeds the maximum speed.
        //Steps:
        //Set CurrentSpeed to exceed MaxSpeed.
        //Execute SetSpeedAlert.
        //Confirm that SpeedAlert contains the appropriate warning message.

        //Test Case 5: Low Charge Alert
        //Description: Test SetChargeAlert for generating a low charge alert when charge falls below the critical level.
        //Steps:
        //Set Charge to just below CriticalCharge.
        //Call SetChargeAlert.
        //Check that SpeedAlert includes the low charge warning.

        //Test Case 6: Full Charge Alert
        //Description: Check that SetChargeAlert correctly alerts when charge exceeds critical overcharge level.
        //Steps:
        //Set Charge above CriticalOvercharge.
        //Call SetChargeAlert.
        //Verify that SpeedAlert warns about full charge and deceleration charge being disabled.

        //Test Case 7: Deceleration Charge Activation Safety
        //Description: Test the logic for enabling or disabling the deceleration charge feature based on the charge level.
        //Steps:
        //Set Charge below CriticalOvercharge.
        //Invoke DecelerationChargeActivation with isActive as true.
        //Confirm that IsDecelerationChargeActive is true.

        //Test Case 8: Deceleration Charge Deactivation Safety
        //Description: Ensure that deceleration charging is disabled when charge exceeds the safe threshold.
        //Steps:
        //Set Charge above CriticalOvercharge.
        //Call DecelerationChargeActivation with isActive as true.
        //Ensure IsDecelerationChargeActive is false.

        //Test Case 9: Compute Deceleration Charge Power When Active
        //Description: Validate that GetDecelerationChargePower computes the correct power when the feature is active.
        //Steps:
        //Ensure DecelerationChargeMode is true.
        //Call GetDecelerationChargePower with isActive set to true.
        //Check that the returned value equals CurrentSpeed - CurrentAcceleration.

        //Test Case 10: Compute Deceleration Charge Power When Inactive
        //Description: Check that GetDecelerationChargePower returns 0 when the feature is not active.
        //Steps:
        //Ensure DecelerationChargeMode is true.
        //Invoke GetDecelerationChargePower with isActive set to false.
        //Verify that the result is 0.
        #endregion

    }
}

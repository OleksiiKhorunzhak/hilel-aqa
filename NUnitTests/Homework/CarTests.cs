using NUnitTests.Lessons;

namespace NUnitTests.Homework
{
    public class CarTests : Lesson3Logic
    {
        //TODO: Finish car tests here or in Lesson3Logic file following example
        #region[TestCases]
        //TODO: TestCases

        //Test Case 1: Test Acceleration
        [Test, Description("Ensure that the method GetAcceleration correctly retrieves the current acceleration value.")]
        [Order(1)]
        public void TestAcceleration()
        {
            //Steps:
            //Initialize an instance of Lesson3Logic.
            //Call the GetAcceleration method.
            GetAcceleration();
            //Verify that the Acceleration property matches CurrentAcceleration.
            Assert.That(Acceleration, Is.EqualTo(CurrentAcceleration), "Acceleration is not equal to CurrentAcceleration");
        }

        //Test Case 2: Test GetSpeed with Positive Acceleration
        [Test, Description("Verify that GetSpeed correctly assigns the current speed to the Speed property when the acceleration is positive.")]
        [Order(2)]
        public void TestGetSpeed()
        {
            //Steps:
            //Set CurrentAcceleration to a positive value.
            CurrentAcceleration = MaxAcceleration;
            //Call the GetSpeed method.
            GetSpeed();
            //Check that Speed equals CurrentSpeed.
            Assert.That(Speed, Is.EqualTo(CurrentSpeed));
        }

        //Test Case 3: Test GetDeceleration
        [Test, Description("Check if GetDeceleration correctly calculates deceleration as the difference between current speed and deceleration.")]
        [Order(3)]
        public void TestGetDeceleration()
        {
            //Steps:
            //Set a known value for CurrentSpeed and CurrentDeceleration.
            CurrentSpeed = MinSpeed;
            CurrentDeceleration = 0;
            //Invoke GetDeceleration.
            GetDeceleration();
            //Ensure Deceleration equals CurrentSpeed - CurrentDeceleration.
            Assert.That(Deceleration, Is.EqualTo(CurrentSpeed), "Deceleration is not equal to CurrentSpeed");
        }


        //Test Case 4: Speed Alert on Exceeding Max Speed
        [Test, Description("Validate that SetSpeedAlert generates the correct alert when the speed exceeds the maximum speed.")] 
        [Order(4)]
        public void SpeedAlertExceedingMaxSpeed()
        {
            //Steps:
            //Set CurrentSpeed to exceed MaxSpeed.
            CurrentSpeed = MaxSpeed + 1;
            //Execute SetSpeedAlert.
            SetSpeedAlert(CurrentSpeed, MaxSpeed);
            //Confirm that SpeedAlert contains the appropriate warning message.
            Assert.That(Alert, Is.EqualTo("Take caution! Speed limit overdue " + (CurrentSpeed - MaxSpeed) + "!"), "SpeedAlert is not contains the appropriate warning message");
        }


        //Test Case 5: Low Charge Alert
        [Test, Order(5), Description("Test SetChargeAlert for generating a low charge alert when charge falls below the critical level.")]
        public void LowChargeAlert()
        {
            //Steps:
            //Set Charge to just below CriticalCharge.
            Charge = CriticalCharge - 1;
            //Call SetChargeAlert.
            SetChargeAlert();
            //Check that SpeedAlert includes the low charge warning.
            Assert.That(Alert, Is.EqualTo("Take caution! Charge Low at " + Charge + "%!"), "SpeedAlert is not includes the low charge warning");
        }

        //Test Case 6: Full Charge Alert
        [Test,Order(6), Description("Check that SetChargeAlert correctly alerts when charge exceeds critical overcharge level.")]
        public void FullChargeAlert()
        {
            //Steps:
            //Set Charge above CriticalOvercharge.
            Charge = CriticalOvercharge + 1;
            //Call SetChargeAlert.
            SetChargeAlert();
            //Verify that SpeedAlert warns about full charge and deceleration charge being disabled.
            Assert.That(Alert, Is.EqualTo("Charge Full! Deceleration charging disabled."), "SpeedAlert is not warns about full charge and deceleration charge being disabled");
        }

        //Test Case 7: Deceleration Charge Activation Safety
        [Test, Order(7), Description("Test the logic for enabling or disabling the deceleration charge feature based on the charge level.")]
        public void DecelerationChargeActivationSafety()
        {
            //Steps:
            //Set Charge below CriticalOvercharge.
            Charge = CriticalOvercharge - 1;
            //Invoke DecelerationChargeActivation with isActive as true.
            DecelerationChargeActivation(true, CriticalOvercharge);
            //Confirm that IsDecelerationChargeActive is true. 
            Assert.That(IsDecelerationChargeActive, Is.True, "IsDecelerationChargeActive is false");
        }

        //Test Case 8: Deceleration Charge Deactivation Safety
        [Test, Order(8), Description("Ensure that deceleration charging is disabled when charge exceeds the safe threshold.")]
        public void DecelerationChargeDeactivationSafety()
        {
            //Steps:
            //Set Charge above CriticalOvercharge.
            Charge = CriticalOvercharge + 1;
            //Call DecelerationChargeActivation with isActive as true.
            DecelerationChargeActivation(true, CriticalOvercharge);
            //Ensure IsDecelerationChargeActive is false.
            Assert.That(IsDecelerationChargeActive, Is.False, "IsDecelerationChargeActive is true");
        }

        //Test Case 9: Compute Deceleration Charge Power When Active
        [Test, Order(9), Description("Validate that GetDecelerationChargePower computes the correct power when the feature is active.")]
        public void ComputeDecelerationChargePowerWhenActive()
        {
            //Steps:
            //Ensure DecelerationChargeMode is true.
            Assert.That(DecelerationChargeMode, Is.True, "DecelerationChargeMode is false");
            //Call GetDecelerationChargePower with isActive set to true.
            GetDecelerationChargePower(true);
            //Check that the returned value equals CurrentSpeed - CurrentAcceleration.
            Assert.That(DecelerationCharge, Is.EqualTo(CurrentSpeed - CurrentAcceleration), "DecelerationCharge returns wrong value");
        }

        //Test Case 10: Compute Deceleration Charge Power When Inactive
        [Test, Order(10), Description("Check that GetDecelerationChargePower returns 0 when the feature is not active")]
        public void ComputeDecelerationChargePowerWhenInactive()
        {
            //Steps:
            //Ensure DecelerationChargeMode is true.
            Assert.That(DecelerationChargeMode, Is.True, "DecelerationChargeMode is false");
            //Invoke GetDecelerationChargePower with isActive set to false.
            GetDecelerationChargePower(false);
            //Verify that the result is 0.
            Assert.That(DecelerationCharge, Is.Zero, "DecelerationCharge is not 0");
        }
        #endregion
    }
}

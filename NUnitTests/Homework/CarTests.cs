using NUnitTests.Lessons;

namespace NUnitTests.Homework
{
    public class CarTests : Lesson3Logic
    {
        //TODO: Finish car tests here or in Lesson3Logic file folowing example
       #region[TestCases]
        //TODO: TestCases
        //Test Case 1: Test Acceleration
        //Description: Ensure that the method GetAcceleration correctly retrieves the current acceleration value.
        //Steps:
        //Initialize an instance of Lesson3Logic.
        //Call the GetAcceleration method.
        //Verify that the Acceleration property matches CurrentAcceleration.
        [Test, Description("Ensure that Acceleration correctly retrieves the current acceleration")]
        [Order(1)]
        public void TestAcceleration()
        {
            CurrentAcceleration = 50;
            Accelerate(CurrentAcceleration);
            Assert.That(Acceleration, Is.EqualTo(CurrentAcceleration));
        }
        
        //Test Case 2: Test GetSpeed with Positive Acceleration
        //Description: Verify that GetSpeed correctly assigns the current speed to the Speed property when the acceleration is positive.
        //Steps:
        [Test, Description("Verify that GetSpeed correctly assigns the current speed to the Speed property when the acceleration is positive.")]
        [Order(2)]
        public void TestGetSpeed()
        {
            //Set CurrentAcceleration to a positive value.
            Accelerate(CurrentAcceleration);
            //Call the GetSpeed method.
            GetSpeed();
            //Check that Speed equals CurrentSpeed.
            Assert.That(Speed, Is.EqualTo(CurrentSpeed));
        }


        //Test Case 3: Test GetDeceleration
        //Description: Check if GetDeceleration correctly calculates deceleration as the difference between current speed and deceleration.
        //Steps:
        //Set a known value for CurrentSpeed and CurrentDeceleration.
        //Invoke GetDeceleration.
        //Ensure Deceleration equals CurrentSpeed - CurrentDeceleration.
        [Test, Description("Check if GetDeceleration correctly calculates deceleration as the difference between current speed and deceleration.")]
        [Order(3)]
        public void TestGetDeceleration()
        {   
            //Set a known value for CurrentSpeed and CurrentDeceleration.
            CurrentSpeed = 80;
            CurrentDeceleration = 60;
            //Invoke GetDeceleration.
            Accelerate(CurrentAcceleration);
            GetDeceleration();
            //Ensure Deceleration equals CurrentSpeed - CurrentDeceleration.
            Assert.That(Deceleration, Is.EqualTo(CurrentSpeed - CurrentDeceleration));
        }

        //Test Case 4: Speed Alert on Exceeding Max Speed
        //Description: Validate that SetSpeedAlert generates the correct alert when the speed exceeds the maximum speed.
        //Steps:
        //Set CurrentSpeed to exceed MaxSpeed.
        //Execute SetSpeedAlert.
        //Confirm that SpeedAlert contains the appropriate warning message.
        [Test]
        [Order(4)]
        public void TestSpeedAlertOnExceedingMaxSpeed()
        {
            //Set CurrentSpeed to exceed MaxSpeed.
            CurrentSpeed = 120;
            Acceleration = 50; // Set acceleration to a positive value as a part of IF statement in SetSpeedAlert method.
            //Execute SetSpeedAlert.
            SetSpeedAlert(speed: CurrentSpeed, MaxSpeed);
            //Confirm that SpeedAlert contains the appropriate warning message.
            Assert.That(Alert, Is.EqualTo("Take caution! Speed limit overdue " + (CurrentSpeed - MaxSpeed) + "!"), "Speed limit exceeded");
        }

        //Test Case 5: Low Charge Alert
        //Description: Test SetChargeAlert for generating a low charge alert when charge falls below the critical level.
        //Steps:
        //Set Charge to just below CriticalCharge.
        //Call SetChargeAlert.
        //Check that SetChargeAlert includes the low charge warning.

        [Test, Description("Test SetChargeAlert for generating a low charge alert when charge falls below the critical level.")]
        [Order(5)]
        public void TestLowChargeAlert()
        {
            //Set Charge to just below CriticalCharge.
            Charge = 9;
            //Call SetChargeAlert.
            SetChargeAlert();
            //Check that SpeedAlert includes the low charge warning.
            Assert.That(Alert, Is.EqualTo("Take caution! Charge Low at " + Charge + "%!"), "Low charge warning is missing.");
        }

        //Test Case 6: Full Charge Alert
        //Description: Check that SetChargeAlert correctly alerts when charge exceeds critical overcharge level.
        //Steps:
        //Set Charge above CriticalOvercharge.
        //Call SetChargeAlert.
        //Verify that SetChargeAlert warns about full charge and deceleration charge being disabled.
        [Test, Description("Check that SetChargeAlert correctly alerts when charge exceeds critical overcharge level.")]
        [Order(6)]
        public void TestFullChargeAlert()
        {
            //Set Charge above CriticalOvercharge.
            Charge = 100;
            //Call SetChargeAlert.
            SetChargeAlert();
            //Verify that SpeedAlert warns about full charge and deceleration charge being disabled.
            Assert.That(Alert, Is.EqualTo("Charge Full! Deceleration charging disabled."), "Full charge warning is missing.");
        }

        //Test Case 7: Deceleration Charge Activation Safety
        //Description: Test the logic for enabling or disabling the deceleration charge feature based on the charge level.
        //Steps:
        //Set Charge below CriticalOvercharge.
        //Invoke DecelerationChargeActivation with isActive as true.
        //Confirm that IsDecelerationChargeActive is true.
        [Test, Description("Test the logic for enabling or disabling the deceleration charge feature based on the charge level.")]
        [Order(7)]
        public void TestDecelerationChargeActivationSafety()
        {
            //Set Charge below CriticalOvercharge.
            Charge = 90;
            //Invoke DecelerationChargeActivation with isActive as true.
            DecelerationChargeActivation(true, CriticalOvercharge);
            //Confirm that IsDecelerationChargeActive is true.
            Assert.That(IsDecelerationChargeActive, Is.True, "Deceleration charge is not active.");
        }

        //Test Case 8: Deceleration Charge Deactivation Safety
        //Description: Ensure that deceleration charging is disabled when charge exceeds the safe threshold.
        //Steps:
        //Set Charge above CriticalOvercharge.
        //Call DecelerationChargeActivation with isActive as true.
        //Ensure IsDecelerationChargeActive is false.
        [Test, Description("Ensure that deceleration charging is disabled when charge exceeds the safe threshold.")]
        [Order(8)]
        public void TestDecelerationChargeDeactivationSafety()
        {
            //Set Charge above CriticalOvercharge.
            Charge = 100;
            //Call DecelerationChargeActivation with isActive as true.
            DecelerationChargeActivation(true, CriticalOvercharge);
            //Ensure IsDecelerationChargeActive is false.
            Assert.That(IsDecelerationChargeActive, Is.False, "Deceleration charge is active.");
        }

        //Test Case 9: Compute Deceleration Charge Power When Active
        //Description: Validate that GetDecelerationChargePower computes the correct power when the feature is active.
        //Steps:
        //Ensure DecelerationChargeMode is true.
        //Call GetDecelerationChargePower with isActive set to true.
        //Check that the returned value equals CurrentSpeed - CurrentAcceleration.
        [Test, Description("Validate that GetDecelerationChargePower computes the correct power when the feature is active.")]
        [Order(9)]
        public void TestComputeDecelerationChargePowerWhenActive()
        {
            //Ensure DecelerationChargeMode is true.
            DecelerationChargeMode = true;
            //Call GetDecelerationChargePower with isActive set to true.
            GetDecelerationChargePower(true);
            //Check that the returned value equals CurrentSpeed - CurrentAcceleration.
            Assert.That(DecelerationCharge, Is.EqualTo(CurrentSpeed - CurrentAcceleration), "Deceleration charge power is incorrect.");
        }

        //Test Case 10: Compute Deceleration Charge Power When Inactive
        //Description: Check that GetDecelerationChargePower returns 0 when the feature is not active.
        //Steps:
        //Ensure DecelerationChargeMode is true.
        //Invoke GetDecelerationChargePower with isActive set to false.
        //Verify that the result is 0.
        [Test, Description("Check that GetDecelerationChargePower returns 0 when the feature is not active.")]
        [Order(10)]
        public void TestComputeDecelerationChargePowerWhenInactive()
        {
            //Ensure DecelerationChargeMode is true.
            DecelerationChargeMode = true;
            //Invoke GetDecelerationChargePower with isActive set to false.
            GetDecelerationChargePower(false);
            //Verify that the result is 0.
            Assert.That(DecelerationCharge, Is.EqualTo(0), "Deceleration charge power is incorrect.");
        }
        #endregion

    }
}

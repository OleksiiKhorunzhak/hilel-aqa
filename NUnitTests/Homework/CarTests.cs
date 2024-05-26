using NUnitTests.Lessons;

namespace NUnitTests.Homework
{
    public class CarTests : Lesson3Logic
    {
        #region[TestCases]

        //Test Case 1: Test Acceleration
        [Order(1)]
        [Test, Description ("Ensure that the method GetAcceleration correctly retrieves the current acceleration value")]
        public void TestAcceleration()
        {
            GetAcceleration();

            Assert.That(Acceleration, Is.EqualTo(CurrentAcceleration));
        }

        //Test Case 2: Test GetSpeed with Positive Acceleration
        [Order(2)]
        [Test, Description ("Verify that GetSpeed correctly assigns the current speed to the Speed property when the acceleration is positive.")]
        public void TestGetSpeedWithPositiveAcceleration()
        {
            GetSpeed();
            
            Assert.That(Speed, Is.EqualTo(CurrentSpeed));
        }

        //Test Case 3: Test GetDeceleration
        [Order(3)]
        [Test, Description("Check if GetDeceleration correctly calculates deceleration as the difference between current speed and deceleration.")]
        public void TestGetDeceleration()
        {
            //Step1:
            //Set a known value for CurrentSpeed and CurrentDeceleration - Anna's note: it's already set in the Lesson3Logic file.
            
            GetDeceleration();
            var expectedDeceleration = CurrentSpeed - CurrentDeceleration;

            Assert.That(Deceleration, Is.EqualTo(expectedDeceleration));
        }

        //Test Case 4: Speed Alert on Exceeding Max Speed 
        [Order(4)]
        [Test, Description("Validate that SetSpeedAlert generates the correct alert when the speed exceeds the maximum speed.")]
        public void TestCorrectSpeedAlertDisplayingOnExceedingMaxSpeed()
        {
            CurrentSpeed = MaxSpeed + 20;
            var expectedMaxSpeedAlertText = "Take caution! Speed limit overdue " + (CurrentSpeed - MaxSpeed) + "!";
            
            SetSpeedAlert(CurrentSpeed, MaxSpeed);

            Assert.That(Alert, Is.EqualTo(expectedMaxSpeedAlertText));
        }

        //Test Case 5: Low Charge Alert
        [Order(5)]
        [Test, Description("Test SetChargeAlert for generating a low charge alert when charge falls below the critical level")]
        public void TestLowChargeAlert()
        {
            Charge = 9;
            var expectedLowChargeAlertText = "Take caution! Charge Low at " + Charge + "%!";
           
            SetChargeAlert();
            
            Assert.That(Alert, Is.EqualTo(expectedLowChargeAlertText));
        }

        //Test Case 6: Full Charge Alert
        [Order(6)]
        [Test, Description("Check that SetChargeAlert correctly alerts when charge exceeds critical overcharge level")]
        public void TestFullChargeAlert()
        {
            Charge = 99;
            var expectedFullChargeAlertText = "Charge Full! Deceleration charging disabled.";
           
            SetChargeAlert();
            
            Assert.That(Alert, Is.EqualTo(expectedFullChargeAlertText));
        }

        //Test Case 7: Deceleration Charge Activation Safety
        [Order(7)]
        [Test, Description("Test the logic for enabling or disabling the deceleration charge feature based on the charge level")]
        public void TestDecelerationChargeActivation()
        {
            Charge = 95;
            bool isActive = true;

            DecelerationChargeActivation(isActive, CriticalOvercharge);

            Assert.That(IsDecelerationChargeActive, Is.True);
        }

        //Test Case 8: Deceleration Charge Deactivation Safety
        [Order(8)]
        [Test, Description("Ensure that deceleration charging is disabled when charge exceeds the safe threshold.")]
        public void TestDecelerationChargeDeactivation()
        {
            Charge = 99;
            var isActive = true;

            DecelerationChargeActivation(isActive, CriticalOvercharge);

            Assert.That(IsDecelerationChargeActive, Is.False);
        }

        //Test Case 9: Compute Deceleration Charge Power When Active
        [Order(9)]
        [Test, Description("Validate that GetDecelerationChargePower computes the correct power when the feature is active")]
        public void TestDecelerationChargePowerWhenActive()
        {
            //Ensure DecelerationChargeMode is true - Anna's note: why? it's not used anywhere...
            Assert.That(DecelerationChargeMode, Is.True);

            var isActive = true;
            var expectedDecelerationCharge = CurrentSpeed - CurrentAcceleration;

            var actualDecelerationCharge = GetDecelerationChargePower(isActive);

            Assert.That(actualDecelerationCharge, Is.EqualTo(expectedDecelerationCharge));
        }


        //Test Case 10: Compute Deceleration Charge Power When Inactive
        [Order(10)]
        [Test, Description("Check that GetDecelerationChargePower returns 0 when the feature is not active")]
        public void TestDecelerationChargePowerWhenInactive()
        {
            //Ensure DecelerationChargeMode is true - Anna's note: why? it's not used anywhere...
            Assert.That(DecelerationChargeMode, Is.True);

            var isActive = false;
            var expectedDecelerationCharge = 0;

            var actualDecelerationCharge = GetDecelerationChargePower(isActive);

            Assert.That(actualDecelerationCharge, Is.EqualTo(expectedDecelerationCharge));
        }
        #endregion
    }
}
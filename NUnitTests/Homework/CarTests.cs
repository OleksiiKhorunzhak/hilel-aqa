using System.Security.Cryptography.X509Certificates;
using NUnitTests.Lessons;

namespace NUnitTests.Homework
{
    public class CarTests : Lesson3Logic
    {
        //TODO: Finish car tests here or in Lesson3Logic file folowing example
        [Order(1)]
        [Test, Description("Ensure that Acceleration correctly retrieves the current acceleration")]
        public void TestAcceleration()
        {
            CurrentAcceleration = 50;
            Accelerate(CurrentAcceleration);
            Assert.That(Acceleration, Is.EqualTo(CurrentAcceleration));
        }

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
        [Test]
        [Order(2)]
        public void TestGetSpeed()
        {
            //Set CurrentAcceleration to a positive value.
            CurrentAcceleration = 50;
            //Call the GetSpeed method.
            GetSpeed();
            //Check that Speed equals CurrentSpeed.
            Assert.That(Speed, Is.EqualTo(CurrentSpeed));
        }


        //Test Case 3: Test GetDeceleration
        //Description: Check if GetDeceleration correctly calculates deceleration as the difference between current speed and deceleration.
        //Steps:
        [Test]
        [Order(3)]
        public void TestGetDeceleration()
        {
            //Set a known value for CurrentSpeed and CurrentDeceleration.
            CurrentSpeed = 50;
            CurrentDeceleration = 30;
            //Invoke GetDeceleration.
            GetDeceleration();
            //Ensure Deceleration equals CurrentSpeed - CurrentDeceleration.
            Assert.That(Deceleration, Is.EqualTo(CurrentSpeed - CurrentDeceleration));
        }



        //Test Case 4: Speed Alert on Exceeding Max Speed
        //Description: Validate that SetSpeedAlert generates the correct alert when the speed exceeds the maximum speed.
        //Steps:
        [Test]
        [Order(4)]
        public void TestSpeedAlertOnExceedingMaxSpeed()

        {
            //Set CurrentSpeed to exceed MaxSpeed.
            CurrentSpeed = 101;
            //Execute SetSpeedAlert.
            if (CurrentSpeed > MaxSpeed)
            {
                SetSpeedAlert(CurrentSpeed,MaxSpeed);
            }

            //Confirm that SpeedAlert contains the appropriate warning message.
            var speedAlertMessage = "Take caution! Speed limit overdue " + (CurrentSpeed - MaxSpeed) + "!";
            Assert.That(Alert, Is.EqualTo(speedAlertMessage));
        }



        //Test Case 5: Low Charge Alert
        //Description: Test SetChargeAlert for generating a low charge alert when charge falls below the critical level.
        //Steps:
        [Test]
        [Order(5)]
        public void TestLowChargeAlert()
        {
            //Set Charge to just below CriticalCharge.
            Charge = 9;
            //Call SetChargeAlert.
            if (Charge < CriticalCharge)
            {
                SetChargeAlert();
            }
            //Check that ChargeAlert includes the low charge warning.
           var chargeAlertMessage = "Take caution! Charge Low at " + Charge + "%!";
            Assert.That(Alert,Is.EqualTo(chargeAlertMessage));
        }



        //Test Case 6: Full Charge Alert
        //Description: Check that SetChargeAlert correctly alerts when charge exceeds critical overcharge level.
        //Steps:
        [Test]
        [Order(6)]
        public void TestFullChargeAlert()
        {
            //Set Charge above CriticalOvercharge.
            Charge = 99;
            //Call SetChargeAlert.
            if (Charge > CriticalCharge)
            {
                SetChargeAlert();
            }
            //Verify that ChargeAlert warns about full charge and deceleration charge being disabled.
            var fullChargeAlertMessage = "Charge Full! Deceleration charging disabled.";
            Assert.That(Alert, Is.EqualTo(fullChargeAlertMessage));
        }



        //Test Case 7: Deceleration Charge Activation Safety
        //Description: Test the logic for enabling or disabling the deceleration charge feature based on the charge level.
        //Steps:
        [Test]
        [Order(7)]
        public void TestDecelerationChargeActivation()
        {
            //Set Charge below CriticalOvercharge.
            Charge = 97;
            //Invoke DecelerationChargeActivation with isActive as true.
            var isActive = true;
            DecelerationChargeActivation(isActive, CriticalOvercharge);
            //Confirm that IsDecelerationChargeActive is true.
            Assert.That(IsDecelerationChargeActive, Is.EqualTo(true));

        }



        //Test Case 8: Deceleration Charge Deactivation Safety
        //Description: Ensure that deceleration charging is disabled when charge exceeds the safe threshold.
        //Steps:
        [Test]
        [Order(8)]
        public void TestDecelerationChargeDeactivation()
        {
            //Set Charge above CriticalOvercharge.
            Charge = 99;
            //Call DecelerationChargeActivation with isActive as true.
            var isActive = true;
            DecelerationChargeActivation(isActive, CriticalOvercharge);
            //Ensure IsDecelerationChargeActive is false.
            Assert.That(IsDecelerationChargeActive, Is.EqualTo(false));
        }




        //Test Case 9: Compute Deceleration Charge Power When Active
        //Description: Validate that GetDecelerationChargePower computes the correct power when the feature is active.
        //Steps:
        [Test]
        [Order(9)]
        public void TestDecelerationChargePowerActive()
        {
            //Ensure DecelerationChargeMode is true.
            DecelerationChargeMode = true;
            //Call GetDecelerationChargePower with isActive set to true.
            var isActive = true;
            GetDecelerationChargePower(isActive);
            //Check that the returned value equals CurrentSpeed - CurrentAcceleration.
            Assert.That(DecelerationCharge, Is.EqualTo(CurrentSpeed - CurrentAcceleration));
        }



        //Test Case 10: Compute Deceleration Charge Power When Inactive
        //Description: Check that GetDecelerationChargePower returns 0 when the feature is not active.
        //Steps:
        [Test]
        [Order(10)]
        public void TestDecelerationChargePowerInactive()
        {
            //Ensure DecelerationChargeMode is true.
            DecelerationChargeMode = true;
            //Invoke GetDecelerationChargePower with isActive set to false.
            var isActive = false;
            GetDecelerationChargePower(isActive);
            //Verify that the result is 0.
            Assert.That(DecelerationCharge, Is.EqualTo(0));
        }


        
        #endregion

    }
}

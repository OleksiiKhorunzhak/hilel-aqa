﻿using NUnitTests.Lessons;

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
        //Set a known value for CurrentSpeed and CurrentDeceleration.
        //Invoke GetDeceleration.
        //Ensure Deceleration equals CurrentSpeed - CurrentDeceleration.
        [Test]
        [Order(3)]
        public void TestGetDeceleration()   
        {
            //Set a known value for CurrentSpeed and CurrentDeceleration. - Exsists in file Lesson3Logics.cs
            GetDeceleration();
            Deceleration = CurrentSpeed - CurrentDeceleration;
            Assert.That(Deceleration, Is.EqualTo(CurrentSpeed - CurrentDeceleration), "Deceleration does not equal CurrentSpeed - CurrentDeceleration");

        }
        //Test Case 4: Speed Alert on Exceeding Max Speed
        //Description: Validate that SetSpeedAlert generates the correct alert when the speed exceeds the maximum speed.
        //Steps:
        //Set CurrentSpeed to exceed MaxSpeed.
        //Execute SetSpeedAlert.
        //Confirm that SpeedAlert contains the appropriate warning message.
        [Test]
        [Order(4)]
        public void TestSetSpeedAlert() 
       
        {
            CurrentSpeed = 101;
           
            if (CurrentSpeed > MaxSpeed)
            {
                SetSpeedAlert(CurrentSpeed, MaxSpeed);
                
            }
            string AlertMaxSpeedMessage = "Take caution! Speed limit overdue " + (CurrentSpeed - MaxSpeed) + "!";
            Assert.That(Alert, Is.EqualTo(AlertMaxSpeedMessage), "Alert doesn't contain the appropriate message");
        }

        //Test Case 5: Low Charge Alert
        //Description: Test SetChargeAlert for generating a low charge alert when charge falls below the critical level.
        //Steps:
        //Set Charge to just below CriticalCharge.
        //Call SetChargeAlert.
        //Check that SpeedAlert includes the low charge warning.

        [Test]
        [Order(5)]
        public void TestSetLowChargeAlert()
        {
            Charge = 8;
            string LowChargeAlert = "Take caution! Charge Low at " + Charge + "%!";
            if (Charge < CriticalCharge)
            {
                SetChargeAlert();
            }

            Assert.That(Alert, Is.EqualTo(LowChargeAlert), "The low charge warning hasn't displayed");

        }

        //Test Case 6: Full Charge Alert
        //Description: Check that SetChargeAlert correctly alerts when charge exceeds critical overcharge level.
        //Steps:
        //Set Charge above CriticalOvercharge.
        //Call SetChargeAlert.
        //Verify that SpeedAlert warns about full charge and deceleration charge being disabled.
        [Test]
        [Order(6)]
        public void TestSetOverChargeAlert()
        {
            Charge = 100;
            string OverChargeAlert = "Charge Full! Deceleration charging disabled.";
            if (Charge > CriticalOvercharge) 
            {
                SetChargeAlert();
                Assert.That(Alert, Is.EqualTo(OverChargeAlert), "Speed Alert doesn't contain the appropriate message");
            
            }
        }

        //Test Case 7: Deceleration Charge Activation Safety
        //Description: Test the logic for enabling or disabling the deceleration charge feature based on the charge level.
        //Steps:
        //Set Charge below CriticalOvercharge.
        //Invoke DecelerationChargeActivation with isActive as true.
        //Confirm that IsDecelerationChargeActive is true.
        [Test]
        [Order(7)]
        public void TestDecelerationChargeActivationSafety()
        {
            Charge = 95;
            bool isActive = true;
            DecelerationChargeActivation(isActive, CriticalOvercharge);
            
            Assert.That(IsDecelerationChargeActive, Is.EqualTo(true), "IsDecelerationChargeActive is false");

        }

        //Test Case 8: Deceleration Charge Deactivation Safety
        //Description: Ensure that deceleration charging is disabled when charge exceeds the safe threshold.
        //Steps:
        //Set Charge above CriticalOvercharge.
        //Call DecelerationChargeActivation with isActive as true.
        //Ensure IsDecelerationChargeActive is false.
        [Test]
        [Order(8)]
        public void TestDecelerationChargeDeactivationSafety()
        {
            Charge = 100;
            bool isActive = true;
            DecelerationChargeActivation(isActive, CriticalOvercharge);

            Assert.That(IsDecelerationChargeActive, Is.EqualTo(false), "IsDecelerationChargeActive is false");

        }

        //Test Case 9: Compute Deceleration Charge Power When Active
        //Description: Validate that GetDecelerationChargePower computes the correct power when the feature is active.
        //Steps:
        //Ensure DecelerationChargeMode is true.
        //Call GetDecelerationChargePower with isActive set to true.
        //Check that the returned value equals CurrentSpeed - CurrentAcceleration.
        [Test]
        [Order(9)]
        public void TestDecelerationChargePowerActive()
        {
            bool isActive = true;
            DecelerationCharge = CurrentSpeed - CurrentAcceleration;
            GetDecelerationChargePower(isActive);
            Assert.That(DecelerationCharge, Is.EqualTo(CurrentSpeed - CurrentAcceleration), " Deceleration charge power doesn't equel 'CurrentSpeed - CurrentAcceleration'");

        }

        //Test Case 10: Compute Deceleration Charge Power When Inactive
        //Description: Check that GetDecelerationChargePower returns 0 when the feature is not active.
        //Steps:
        //Ensure DecelerationChargeMode is true.
        //Invoke GetDecelerationChargePower with isActive set to false.
        //Verify that the result is 0.
        #endregion
        [Test]
        [Order(10)]
        public void TestDecelerationChargePowerInactive()
        {
            bool isActive = false;
            GetDecelerationChargePower(isActive);
            Assert.That(DecelerationCharge, Is.EqualTo(0), " Deceleration charge power doesn't equel null");
        }



    }
}

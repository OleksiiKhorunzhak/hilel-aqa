using System.Security.Cryptography.X509Certificates;
using NUnitTests.Lessons;

namespace NUnitTests.Homework
{
    public class CarTests : Lesson3Logic
    {

        //TODO: Finish car tests here or in Lesson3Logic file folowing example
        //Test Case 1: Test Acceleration
        //Description: Ensure that the method GetAcceleration correctly retrieves the current acceleration value.

        [Test, Description("Ensure that Acceleration correctly retrieves the current acceleration")]
        [Order(1)]
        public void TestAcceleration()
        {
            //Initialize an instance of Lesson3Logic.
            CurrentAcceleration = 50;

            //Call the GetAcceleration method.
            Accelerate(CurrentAcceleration);

            //Verify that the Acceleration property matches CurrentAcceleration.
            Assert.That(Acceleration, Is.EqualTo(CurrentAcceleration));
        }

        //Test Case 2: Test GetSpeed with Positive Acceleration
        //Description: Verify that GetSpeed correctly assigns the current speed to the Speed property when the acceleration is positive.
        //Steps:
        [Test]
        [Order(2)]
        public void TestGetSpeed()
        {
            //Set CurrentAcceleration to a positive value.
            CurrentAcceleration = 110;
            //Call the GetSpeed method.
            GetSpeed();
            //Check that Speed equals CurrentSpeed.
            Assert.That(Speed, Is.EqualTo(CurrentSpeed));
        }


        //Test Case 3: Test GetDeceleration
        //Description: Check if GetDeceleration correctly calculates deceleration as the difference between current speed and deceleration.
        [Test]
        [Order(3)]
        public void TestGetDeceleration()
        {
            //Steps:
            //Set a known value for CurrentSpeed and CurrentDeceleration.
            //Invoke GetDeceleration.
            //Ensure Deceleration equals CurrentSpeed - CurrentDeceleration.
            GetDeceleration();
            Assert.That(Deceleration, Is.EqualTo(CurrentSpeed - CurrentDeceleration));
        }
        [Test]
        [Order(3)]
        public void TestGetDeceleration()
        {
            //Set a known value for CurrentSpeed and CurrentDeceleration.
            CurrentSpeed = 50;
            CurrentDeceleration = 50;
            //Invoke GetDeceleration.
            GetDeceleration();
            //Ensure Deceleration equals CurrentSpeed - CurrentDeceleration.
            Assert.That(Deceleration == CurrentSpeed - CurrentDeceleration);
        }


        //Test Case 4: Speed Alert on Exceeding Max Speed
        //Description: Validate that SetSpeedAlert generates the correct alert when the speed exceeds the maximum speed.
        [Test]
        [Order(4)]
        public void TestSetSpeedAlert()
        {
            //Steps:
            //Set CurrentSpeed to exceed MaxSpeed.
            //Execute SetSpeedAlert.
            //Confirm that SpeedAlert contains the appropriate warning message.
            CurrentSpeed = MaxSpeed + 30;
            SetSpeedAlert(CurrentSpeed, MaxSpeed);
            Assert.That(Alert, Is.EqualTo("Take caution! Speed limit overdue " + (CurrentSpeed - MaxSpeed) + "!"));
        }
            //Description: Validate that SetSpeedAlert generates the correct alert when the speed exceeds the maximum speed.
            [Test]
            [Order(4)]
            public void TestSetSpeedAlert()
            {
                //Set CurrentSpeed to exceed MaxSpeed.
                CurrentSpeed = MaxSpeed +10;

                //Execute SetSpeedAlert.
                SetSpeedAlert(CurrentSpeed, MaxSpeed);

                string expectedAlertMessage = "Take caution! Speed limit overdue " + (CurrentSpeed - MaxSpeed) + "!";

                //Confirm that SpeedAlert contains the appropriate warning message.
                Assert.That(Alert, Is.EqualTo(expectedAlertMessage));
            }




        //Test Case 5: Low Charge Alert
        //Description: Test SetChargeAlert for generating a low charge alert when charge falls below the critical level.
        [Test]
        [Order(5)]
        public void TestSetChargeAlert()
        {
            //Steps:
            //Set Charge to just below CriticalCharge.
            //Call SetChargeAlert.
            //Check that SpeedAlert includes the low charge warning.
            Charge = CriticalCharge - 1;
            SetChargeAlert();
            Assert.That(Alert, Is.EqualTo("Take caution! Charge Low at " + Charge + "%!"));
        }
              [Test]
              [Order(5)]

        public void TestSetChargeAlert()
        {
            //Set Charge to just below CriticalCharge.
            Charge = CriticalCharge;

            //Call SetChargeAlert.
            SetChargeAlert();

            //Check that SpeedAlert includes the low charge warning
            Assert.That(Alert, Is.EqualTo("Take caution! Charge Low at " + Charge + "%!"));
        }



        //Test Case 6: Full Charge Alert
        //Description: Check that SetChargeAlert correctly alerts when charge exceeds critical overcharge level.
        [Test]
        [Order(6)]
        public void TestSetFullChargeAlert()
        {
            //Steps:
            //Set Charge above CriticalOvercharge.
            //Call SetChargeAlert.
            //Verify that SpeedAlert warns about full charge and deceleration charge being disabled.
            Charge = CriticalOvercharge + 1;
            SetChargeAlert();
            Assert.That(Alert, Is.EqualTo("Charge Full! Deceleration charging disabled."));
        }

        [Test]
        [Order(6)]
        public void TestChargeAlert2()
        {
            //Set Charge above CriticalOvercharge.
            Charge = CriticalOvercharge;

            //Call SetChargeAlert.
            SetChargeAlert();

            //Verify that SpeedAlert warns about full charge and deceleration charge being disabled.
            Assert.That(Alert, Is.EqualTo("Charge Full! Deceleration charging disabled."));
        }


        //Test Case 7: Deceleration Charge Activation Safety
        //Description: Test the logic for enabling or disabling the deceleration charge feature based on the charge level.
        [Test]
        [Order(7)]
        public void TestDeceleration()
        {
            //Steps:
            //Set Charge below CriticalOvercharge.
            //Invoke DecelerationChargeActivation with isActive as true.
            //Confirm that IsDecelerationChargeActive is true.
            Charge = CriticalOvercharge - 2;
            DecelerationChargeActivation(true, CriticalOvercharge);
            Assert.That(IsDecelerationChargeActive);
        }

        [Test]
        [Order(7)]
        public void TestDecelerationActivation()
        {
            //Set Charge below CriticalOvercharge.
            Charge = CriticalOvercharge - 10;

            //Invoke DecelerationChargeActivation with isActive as true.
            DecelerationChargeActivation(true, CriticalOvercharge);

            //Confirm that IsDecelerationChargeActive is true.
            Assert.That(IsDecelerationChargeActive, Is.True);
        }


        //Test Case 8: Deceleration Charge Deactivation Safety
        //Description: Ensure that deceleration charging is disabled when charge exceeds the safe threshold.
        [Test]
        [Order(8)]
        public void TestDecelerationDisabling()
        {
            //Steps:
            //Set Charge above CriticalOvercharge.
            //Call DecelerationChargeActivation with isActive as true.
            //Ensure IsDecelerationChargeActive is false.
            Charge = CriticalOvercharge + 4;
            DecelerationChargeActivation(true, CriticalOvercharge);
            Assert.That(!IsDecelerationChargeActive);
        }
        [Test]
        [Order(8)]
        public void TestDecelerationActivation2()
        {
            //Set Charge above CriticalOvercharge.
            Charge = CriticalOvercharge + 10;

            //Call DecelerationChargeActivation with isActive as true.
            DecelerationChargeActivation(true, CriticalOvercharge);

            //Ensure IsDecelerationChargeActive is false.
            Assert.That(IsDecelerationChargeActive, Is.False);
        }




        //Test Case 9: Compute Deceleration Charge Power When Active
        //Description: Validate that GetDecelerationChargePower computes the correct power when the feature is active.
        [Test]
        [Order(9)]
        public void TestGetDecelerationChargePower()
        {
            //Steps:
            //Ensure DecelerationChargeMode is true.
            //Call GetDecelerationChargePower with isActive set to true.
            //Check that the returned value equals CurrentSpeed - CurrentAcceleration.
            Assert.That(DecelerationChargeMode, Is.EqualTo(true));
            GetDecelerationChargePower(DecelerationChargeMode);
            Assert.That(DecelerationCharge, Is.EqualTo(CurrentSpeed - CurrentAcceleration));
        }
        [Test]
        [Order(9)]
        public void TestGetDecelerationChargePower()
        {
            //Ensure DecelerationChargeMode is true.
             DecelerationChargeMode = true;

            //Call GetDecelerationChargePower with isActive set to true.
            GetDecelerationChargePower(true);

            //Check that the returned value equals CurrentSpeed - CurrentAcceleration.
            Assert.That(DecelerationCharge == CurrentSpeed - CurrentAcceleration);
        }


        //Test Case 10: Compute Deceleration Charge Power When Inactive
        //Description: Check that GetDecelerationChargePower returns 0 when the feature is not active.
        [Test]
        [Order(10)]
        public void TestGetDecelerationChargePowerInactive()
        {
            //Steps:
            //Ensure DecelerationChargeMode is true.
            //Invoke GetDecelerationChargePower with isActive set to false.
            //Verify that the result is 0.
            Assert.That(DecelerationChargeMode, Is.EqualTo(true));
            GetDecelerationChargePower(false);
            Assert.That(DecelerationCharge, Is.EqualTo(0));
        }
            #endregion
        }
        [Test]
        [Order(10)]
        public void TestGetDecelerationChargePower2()
        {

            //Ensure DecelerationChargeMode is true.
            DecelerationChargeMode = true;

            //Invoke GetDecelerationChargePower with isActive set to false.
            GetDecelerationChargePower(false);

            //Verify that the result is 0.
            Assert.That(DecelerationCharge == CurrentSpeed - CurrentAcceleration);
        }
    }
}


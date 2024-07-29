using NUnitTests.Lessons;

namespace NUnitTests.Homework
{
    public class CarTests : Lesson3Logic
    {
        [Test, Description("Ensure that Acceleration correctly retrieves the current acceleration")]
        public void TestAcceleration()
        {
            //Initialize an instance of Lesson3Logic.
            CurrentAcceleration = 50;

            //Call the GetAcceleration method.
            Accelerate(CurrentAcceleration);
        }

        [Order(1)]
        [Test, Description("Ensure that Acceleration correctly retrieves the current acceleration")]
        public void TestAccelerationVerification()
        {
            //Steps:
            //Initialize an instance of Lesson3Logic.
            //Call the GetAcceleration method.
            //Verify that the Acceleration property matches CurrentAcceleration.
            CurrentAcceleration = 50;
            Accelerate(CurrentAcceleration);
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
            //Steps:
            //Set a known value for CurrentSpeed and CurrentDeceleration.
            //Invoke GetDeceleration.
            //Ensure Deceleration equals CurrentSpeed - CurrentDeceleration.
            GetDeceleration();
            Assert.That(Deceleration, Is.EqualTo(CurrentSpeed - CurrentDeceleration));
        }


        [Order(3)]
        [Test]
        public void TestGetDeceleration()
        {
            //Set a known value for CurrentSpeed and CurrentDeceleration.
            CurrentSpeed = 50;
            CurrentDeceleration = 50;
            //Invoke GetDeceleration.
            GetDeceleration();
            //Ensure Deceleration equals CurrentSpeed - CurrentDeceleration.
            Assert.That(Deceleration == CurrentSpeed - CurrentDeceleration);
            CurrentDeceleration = 50;
            //Invoke GetDeceleration.
            GetDeceleration();
        }

        //Description: Validate that SetSpeedAlert generates the correct alert when the speed exceeds the maximum speed.
        [Order(4)]
        [Test]
        public void TestSetSpeedAlert()
        {
            //Set CurrentSpeed to exceed MaxSpeed.
            CurrentSpeed = MaxSpeed + 10;

            //Execute SetSpeedAlert.
            SetSpeedAlert(CurrentSpeed, MaxSpeed);

            string expectedAlertMessage = "Take caution! Speed limit overdue " + (CurrentSpeed - MaxSpeed) + "!";

            //Confirm that SpeedAlert contains the appropriate warning message.
            Assert.That(Alert, Is.EqualTo(expectedAlertMessage));
        }

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
        public void LowChargeAlert()
        {
            int charge = 8;
            Charge = charge;
            if (charge <= CriticalCharge)
            {
                SetChargeAlert();
            }
            Assert.That(Alert,Is.EqualTo("Take caution! Charge Low at " + Charge + "%!"));
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


        //Test Case 8: Deceleration Charge Deactivation Safety
        //Description: Ensure that deceleration charging is disabled when charge exceeds the safe threshold.
        [Test]
        [Order(9)]
        public void TestDecelerationActivation3()

        {

            //Set Charge above CriticalOvercharge.
            Charge = CriticalOvercharge + 10;

            //Call DecelerationChargeActivation with isActive as true.
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
            //Call GetDecelerationChargePower with isActive set to true.
            //Check that the returned value equals CurrentSpeed - CurrentAcceleration.
            Assert.That(DecelerationChargeMode, Is.EqualTo(true));
            GetDecelerationChargePower(DecelerationChargeMode);
            Assert.That(DecelerationCharge, Is.EqualTo(CurrentSpeed - CurrentAcceleration));
        }
    }
}

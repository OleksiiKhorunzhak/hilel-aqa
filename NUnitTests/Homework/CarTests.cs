using NUnitTests.Lessons;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;

namespace NUnitTests.Homework
{
    public class CarTests : Lesson3Logic
    {

		#region[TestCases]
		//Test Case 1: Test Acceleration
		//Description: Ensure that the method GetAcceleration correctly retrieves the current acceleration value.
		//Steps:
		//Initialize an instance of Lesson3Logic.
		//Call the GetAcceleration method.
		//Verify that the Acceleration property matches CurrentAcceleration.

		[Order(1)]
		[Test, Description("Ensure that Acceleration correctly retrieves the current acceleration")]
		public void TestAcceleration()
		{
			CurrentAcceleration = 50;
			Accelerate(CurrentAcceleration);
			Assert.That(Acceleration, Is.EqualTo(CurrentAcceleration));
		}

		//Test Case 2: Test GetSpeed with Positive Acceleration
		//Description: Verify that GetSpeed correctly assigns the current speed to the Speed property when the acceleration is positive.
		//Steps:
		//Set CurrentAcceleration to a positive value.
		//Call the GetSpeed method.
		//Check that Speed equals CurrentSpeed.

		[Test]
        [Order(2)]
        public void TestGetSpeed()
        {
	        Acceleration = 25;
            CurrentAcceleration = 50;
            GetSpeed();
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

			CurrentSpeed = 90;
			CurrentDeceleration = 30;
			GetDeceleration();
			Assert.That(Deceleration, Is.EqualTo(CurrentSpeed-CurrentDeceleration));
		}


		//Test Case 4: Speed Alert on Exceeding Max Speed
		//Description: Validate that SetSpeedAlert generates the correct alert when the speed exceeds the maximum speed.
		//Steps:
		//Set CurrentSpeed to exceed MaxSpeed.
		//Execute SetSpeedAlert.
		//Confirm that SpeedAlert contains the appropriate warning message.

		[Test]
		[Order(4)]
		public void TestExceedingMaxSpeed()
		{

			CurrentSpeed = 150;
			var expectedAlert = "Take caution! Speed limit overdue " + (CurrentSpeed - MaxSpeed) + "!";
			SetSpeedAlert(CurrentSpeed, MaxSpeed);
			Assert.That(Alert, Is.EqualTo(expectedAlert));

		}


		//Test Case 5: Low Charge Alert
		//Description: Test SetChargeAlert for generating a low charge alert when charge falls below the critical level.
		//Steps:
		//Set Charge to just below CriticalCharge.
		//Call SetChargeAlert.
		//Check that SpeedAlert includes the low charge warning.


		[Test]
		[Order(5)]
		public void TestChargeAlert()
		{
			var StaticCriticalCharge = 10;
			var MyCriticalCharge = 8;
			var expectedAlert = "Take caution! Charge Low at " + Charge + "%!";

			
			if (MyCriticalCharge < StaticCriticalCharge)
			{
				SetChargeAlert();
			}
			Assert.That(Alert, Is.EqualTo(expectedAlert));

		}



		//Test Case 6: Full Charge Alert
		//Description: Check that SetChargeAlert correctly alerts when charge exceeds critical overcharge level.
		//Steps:
		//Set Charge above CriticalOvercharge.
		//Call SetChargeAlert.
		//Verify that SpeedAlert warns about full charge and deceleration charge being disabled.


		[Test]
		[Order(6)]
		public void TestFullChargeAlert()
		{
			int CriticalOvercharge = 98;
			int charge = 129;
			charge = 129;
			string expectedAlert = "Charge Full! Deceleration charging disabled.";

			if (charge >= CriticalOvercharge)
			{
				SetChargeAlert();
			}

			Assert.That(Alert, Is.EqualTo(expectedAlert));
		}


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

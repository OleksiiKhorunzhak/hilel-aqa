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

		[Test]
		[Order(3)]
		public void TestGetDeceleration()
		{
			//Set a known value for CurrentSpeed and CurrentDeceleration.
			CurrentSpeed = 50;
			CurrentDeceleration = 5;
			int expectedValue = CurrentSpeed - CurrentDeceleration;
			//Invoke GetDeceleration.
			GetDeceleration();
			//Ensure Deceleration equals CurrentSpeed - CurrentDeceleration.
			Assert.That(Deceleration, Is.EqualTo(expectedValue), $"Deceleration = {Deceleration} is not equal to {expectedValue}");
		}

		//Test Case 4: Speed Alert on Exceeding Max Speed
		//Description: Validate that SetSpeedAlert generates the correct alert when the speed exceeds the maximum speed.
		
		[Test]
		[Order(4)]
		public void TestExceedingMaxSpeedAlert()
		{
			//Set CurrentSpeed to exceed MaxSpeed.
			CurrentSpeed = 110;
			MaxSpeed = 100;
			Acceleration = 10;
			//Execute SetSpeedAlert.
			SetSpeedAlert(CurrentSpeed, MaxSpeed);
			int expectedLimit = CurrentSpeed - MaxSpeed;
			//Confirm that SpeedAlert contains the appropriate warning message.
			Assert.That(Alert, Is.EquivalentTo($"Take caution! Speed limit overdue {expectedLimit}!"), "Alert is not equal to expected");
		}

		//Test Case 5: Low Charge Alert
		//Description: Test SetChargeAlert for generating a low charge alert when charge falls below the critical level.		
		
		[Test]
		[Order(5)]
		public void TestLowChargeAlert()
		{
			//Set Charge to just below CriticalCharge.
			Charge = 9;
			//Call SetChargeAlert.
			SetChargeAlert();
			//Check that SpeedAlert includes the low charge warning.
			Assert.That(Alert, Is.EquivalentTo($"Take caution! Charge Low at {Charge}%!"), "Alert is not equal to expected");
		}

		//Test Case 6: Full Charge Alert
		//Description: Check that SetChargeAlert correctly alerts when charge exceeds critical overcharge level.
		
		[Test]
		[Order(6)]
		public void TestFullChargeAlert()
		{
			//Set Charge above CriticalOvercharge.
			Charge = 99;
			//Call SetChargeAlert.
			SetChargeAlert();
			//Verify that SpeedAlert warns about full charge and deceleration charge being disabled.
			Assert.That(Alert, Is.EquivalentTo("Charge Full! Deceleration charging disabled."), "Alert is not equal to expected");
		}

		//Test Case 7: Deceleration Charge Activation Safety
		//Description: Test the logic for enabling or disabling the deceleration charge feature based on the charge level.
		
		[Test]
		[Order(7)]
		public void TestDeclarationChargeActivationSafety()
		{
			//Set Charge below CriticalOvercharge.
			Charge = 97;
			//Invoke DecelerationChargeActivation with isActive as true.
			bool isActiveSatus = DecelerationChargeActivation(true, CriticalOvercharge);
			//Confirm that IsDecelerationChargeActive is true.
			Assert.That(isActiveSatus, Is.True, "IsDecelerationChargeActive is not equal to true");
		}

		//Test Case 8: Deceleration Charge Deactivation Safety
		//Description: Ensure that deceleration charging is disabled when charge exceeds the safe threshold.
		
		[Test]
		[Order(8)]
		public void TestDeclarationChargeDeactivationSafety()
		{
			//Set Charge above CriticalOvercharge.
			Charge = 99;
			//Invoke DecelerationChargeActivation with isActive as true.
			bool isActiveSatus = DecelerationChargeActivation(true, CriticalOvercharge);
			//Confirm that IsDecelerationChargeActive is true.
			Assert.That(isActiveSatus, Is.False, "IsDecelerationChargeActive is not equal to false");
		}

		//Test Case 9: Compute Deceleration Charge Power When Active
		//Description: Validate that GetDecelerationChargePower computes the correct power when the feature is active.
		
		[Test]
		[Order(9)]
		public void TestComputeDeclarationChargePowerActive()
		{
			//Ensure DecelerationChargeMode is true.
			Charge = 97;
			bool isActiveSatus = DecelerationChargeActivation(true, CriticalOvercharge);
			//Call GetDecelerationChargePower with isActive set to true.
			int chargePower = GetDecelerationChargePower(isActiveSatus);
			int expectedValue = CurrentSpeed - CurrentAcceleration;
			//Check that the returned value equals CurrentSpeed - CurrentAcceleration.
			Assert.That(chargePower, Is.EqualTo(expectedValue), $"{chargePower} is not equal to expected {expectedValue}");
		}

		//Test Case 10: Compute Deceleration Charge Power When Inactive
		//Description: Check that GetDecelerationChargePower returns 0 when the feature is not active.

		[Test]
		[Order(10)]
		public void TestComputeDeclarationChargePowerInactive()
		{
			//Ensure DecelerationChargeMode is true.
			Charge = 97;
			DecelerationChargeActivation(true, CriticalOvercharge);
			//Invoke GetDecelerationChargePower with isActive set to false.
			int chargePower = GetDecelerationChargePower(false);
			int expectedValue = 0;
			//Verify that the result is 0.
			Assert.That(chargePower, Is.EqualTo(0), $"{chargePower} is not equal to expected {expectedValue}");
		}
		#endregion

	}
}

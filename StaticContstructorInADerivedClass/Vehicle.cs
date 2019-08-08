namespace StaticContstructorInADerivedClass
{
	class Vehicle
	{
		public static string Country;

		public int MaxSpeed;

		public Vehicle(int maxSpeed)
		{
			this.MaxSpeed = maxSpeed;
			Country = "UK";
		}
	}
}

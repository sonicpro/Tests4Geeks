namespace StaticContstructorInADerivedClass
{
	class Car : Vehicle
	{
		public string Transmission;

		public Car(int maxSpeed, string transmission) : base(maxSpeed)
		{
			this.MaxSpeed = 100;
			this.Transmission = transmission;
		}

		static Car()
		{
			Country = "USA";
		}
	}
}

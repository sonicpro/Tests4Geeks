<Query Kind="Program" />

void Main()
{
	using (var d = new dc())
	{
		Console.WriteLine("Do something");
	}
}

// Define other methods and classes here
public class dc :IDisposable
{
	public void Dispose()
	{
		Console.WriteLine("I'm disposed!");
	}
}
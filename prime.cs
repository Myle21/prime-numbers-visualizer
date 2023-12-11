using Godot;
using System;
using System.Drawing;

public partial class prime : Node2D
{
	public ulong Limit = 1100000;

	public static PackedScene Number = ResourceLoader.Load<PackedScene>("res://number.tscn");
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SieveOfAtkin(Limit);
	}

	public void SieveOfAtkin(ulong limit)
	{
		// Initialise the sieve array with
		// false values
		bool[] sieve = new bool[limit + 1];

		for (ulong i = 0; i <= limit; i++)
			sieve[i] = false;

		/* Mark sieve[n] is true if one of the
		following is true:
		a) n = (4*x*x)+(y*y) has odd number
		   of solutions, i.e., there exist
		   odd number of distinct pairs
		   (x, y) that satisfy the equation
		   and    n % 12 = 1 or n % 12 = 5.
		b) n = (3*x*x)+(y*y) has odd number
		   of solutions and n % 12 = 7
		c) n = (3*x*x)-(y*y) has odd number
		   of solutions, x > y and n % 12 = 11 */
		for (ulong x = 1; x * x <= limit; x++)
		{
			for (ulong y = 1; y * y <= limit; y++)
			{

				// Main part of Sieve of Atkin
				ulong n = (4 * x * x) + (y * y);
				if (n <= limit
					&& (n % 12 == 1 || n % 12 == 5))

					sieve[n] ^= true;

				n = (3 * x * x) + (y * y);
				if (n <= limit && n % 12 == 7)
					sieve[n] ^= true;

				n = (3 * x * x) - (y * y);
				if (x > y && n <= limit
						  && n % 12 == 11)
					sieve[n] ^= true;
			}
		}

		// Mark all multiples of squares as
		// non-prime
		for (ulong r = 5; r * r < limit; r++)
		{
			if (sieve[r])
			{
				for (ulong i = r * r;
					 i < limit;
					 i += r * r)
					sieve[i] = false;
			}
		}

		// Print primes using sieve[]
		for (ulong a = 1; a <= limit; a++)
			if (sieve[a] == true)
			{ 
				Node2D instance = Number.Instantiate<Node2D>();
				instance.Call("SetNum", a);
				GetNode("Container").AddChild(instance);
			}
	}
}


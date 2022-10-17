﻿namespace RndDotNet.ObjectMapping.Benchmark.Models;

public class NestedUserDto
{
	public int Id { get; set; }
	public string FirstName { get; set; } = null!;
	public string LastName { get; set; } = null!;
	public string Email { get; set; } = null!;
	public NestedAddressDto Address { get; set; } = null!;
}

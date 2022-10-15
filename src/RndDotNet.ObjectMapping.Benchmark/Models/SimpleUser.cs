namespace RndDotNet.ObjectMapping.Benchmark.Models;

public class SimpleUser
{
	public int Id { get; set; }
	public string Name { get; set; } = null!;
	public bool IsActive { get; set; }
	public string Email { get; set; } = null!;
	public DateTime CreatedAt { get; set; }
}

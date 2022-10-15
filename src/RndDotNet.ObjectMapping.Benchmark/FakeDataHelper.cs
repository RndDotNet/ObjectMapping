using Bogus;
using RndDotNet.ObjectMapping.Benchmark.Models;

namespace RndDotNet.ObjectMapping.Benchmark;

public class FakeDataHelper
{
	public static List<SimpleUser> GetSimpleUsers(int count)
	{
		var faker = new Faker<SimpleUser>()
			.Rules((f, o) =>
			{
				o.Id = f.Random.Number();
				o.Name = f.Name.FullName();
				o.Email = f.Person.Email;
				o.IsActive = f.Random.Bool();
				o.CreatedAt = DateTime.Now;
			});
		return faker.Generate(count);
	}
	
	public static List<NestedUser> GetNestedUsers(int count)
	{
		var faker = new Faker<NestedUser>()
			.Rules((f, o) =>
			{
				o.Id = f.Random.Number();
				o.Email = f.Internet.Email();
				o.FirstName = f.Person.FirstName;
				o.LastName = f.Person.LastName;
				o.Address = new Faker<NestedAddress>().Rules((f2, a) =>
				{
					a.AddressLine1 = f2.Address.StreetAddress();
					a.AddressLine2 = f2.Address.StreetName();
					a.City = f2.Address.City();
					a.Country = f2.Address.Country();
					a.State = f2.Address.State();
					a.ZipCode = f2.Address.ZipCode();
				});
			});
		return faker.Generate(count);
	}

	public static List<FlattenUser> GetFlattenUsers(int count)
	{
		var faker = new Faker<FlattenUser>()
			.Rules((f, o) => o.Address = new Faker<FlattenAddress>()
				.Rules((f2, a) => a.ZipCode = f2.Address.ZipCode()));
		return faker.Generate(count);
	}
	
	public static List<CustomPropertyUser> GetCustomPropertyUsers(int count)
	{
		var faker = new Faker<CustomPropertyUser>()
			.Rules((f, o) =>
			{
				o.FirstName = f.Person.FirstName;
				o.LastName = f.Person.LastName;
			});
		return faker.Generate(count);
	}
	
	public static List<AttributeMappingUser> GetAttributeMappingUsers(int count)
	{
		var faker = new Faker<AttributeMappingUser>()
			.Rules((f, o) => o.CreatedAt = f.Date.Past());
		return faker.Generate(count);
	}
}

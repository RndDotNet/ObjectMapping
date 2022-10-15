using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Mapster;

namespace RndDotNet.ObjectMapping.Benchmark.Models;

[AutoMap(typeof(AttributeMappingUser))]
public class AttributeMappingUserDto
{
	[SourceMember("CreatedAt")]
	[AdaptMember("CreatedAt")]
	public string CreatedDate { get; set; } = null!;
}

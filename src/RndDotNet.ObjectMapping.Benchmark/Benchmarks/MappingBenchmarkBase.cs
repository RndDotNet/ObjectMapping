using AutoMapper;
using BenchmarkDotNet.Attributes;

namespace RndDotNet.ObjectMapping.Benchmark.Benchmarks;

public abstract class MappingBenchmarkBase<TSource>
{
	protected const int Size = 1000;
	protected List<TSource> Source;
	protected IMapper Mapper;
	
	[GlobalSetup]
	public virtual void GlobalSetup()
	{
		Mapper = new MapperConfiguration(ConfigureAutoMapper())
			.CreateMapper();
		Source = GetFillSourceDataDelegate()(Size);
	}

	protected abstract Action<IMapperConfigurationExpression> ConfigureAutoMapper();
	protected abstract Func<int, List<TSource>> GetFillSourceDataDelegate();
}

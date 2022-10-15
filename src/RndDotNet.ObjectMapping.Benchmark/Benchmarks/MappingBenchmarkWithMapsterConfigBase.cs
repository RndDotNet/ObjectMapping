using Mapster;

namespace RndDotNet.ObjectMapping.Benchmark.Benchmarks;

public abstract class MappingBenchmarkWithMapsterConfigBase<TSource, TDestination> : MappingBenchmarkBase<TSource>
{
	public override void GlobalSetup()
	{
		base.GlobalSetup();
		ConfigureMapster()(TypeAdapterConfig<TSource, TDestination>.NewConfig());
	}

	protected abstract Action<TypeAdapterSetter<TSource, TDestination>> ConfigureMapster();
}

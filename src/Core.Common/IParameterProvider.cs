namespace Core.Common
{
    public interface IParameterProvider
    {
		Task<TParmType> GetValue<TParmType>(string key, TParmType defaultValue = default(TParmType));

		Task<TParmType> GetOrCreateValue<TParmType>(string key, TParmType defaultValue = default(TParmType));

		Task<TOptsType> GetOptions<TOptsType>(string key, TOptsType defaultValue = default(TOptsType))
			where TOptsType : class;

		Task<TOptsType> GetOrCreateOptions<TOptsType>(string key, TOptsType defaultValue = default(TOptsType))
			where TOptsType : class;

		Task SetValue<TParmType>(string key, TParmType newValue);

		Task SetOptions<TOptsType>(string key, TOptsType newValue)
			where TOptsType : class;
	}
}

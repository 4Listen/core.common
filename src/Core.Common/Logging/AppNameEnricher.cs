using System.Reflection;
using Serilog.Core;
using Serilog.Events;

namespace Core.Common.Logging
{
	public class AppNameEnricher : ILogEventEnricher
	{
		private readonly string _appName;

		public AppNameEnricher()
		{
			var assemblyEntry = Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly();

			_appName = assemblyEntry
				?.GetName().Name ?? "App.Unnamed";
		}

		public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
		{
			logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ApplicationName", _appName));
			logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("Application", _appName));
		}
	}
}

using GPSTracker.WebApi.Abstractions;

namespace GPSTracker.WebApi.Extensions
{
    public static class EndpointExtension
    {
        public static void RegisterEndpoints(this WebApplication app)
        {
            var endpointInstances = typeof(Program).Assembly.GetTypes()
                .Where(t => typeof(IEndpoint).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IEndpoint>();

            foreach (var endpoint in endpointInstances)
            {
                endpoint.MapEndpoints(app);
            }
        }
    }
}

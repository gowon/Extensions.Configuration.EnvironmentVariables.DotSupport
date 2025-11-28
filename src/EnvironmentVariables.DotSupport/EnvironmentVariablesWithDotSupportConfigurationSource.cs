namespace Extensions.Configuration.EnvironmentVariables.DotSupport;

using Microsoft.Extensions.Configuration;

public class EnvironmentVariablesWithDotSupportConfigurationSource : IConfigurationSource
{
    public string? Prefix { get; set; }

    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        return new EnvironmentVariablesWithDotSupportConfigurationProvider(Prefix);
    }
}
namespace Extensions.Configuration.EnvironmentVariables.DotSupport;

using Microsoft.Extensions.Configuration;

public static class ConfigurationBuilderExtensions
{
    public static IConfigurationBuilder AddEnvironmentVariablesWithDotSupport(
        this IConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Add(new EnvironmentVariablesWithDotSupportConfigurationSource());
        return configurationBuilder;
    }

    public static IConfigurationBuilder AddEnvironmentVariablesWithDotSupport(
        this IConfigurationBuilder configurationBuilder,
        string? prefix,
        string? dotReplacement = EnvironmentVariablesWithDotSupportConfigurationProvider.DotReplacementFragment)
    {
        configurationBuilder.Add(new EnvironmentVariablesWithDotSupportConfigurationSource { Prefix = prefix });
        return configurationBuilder;
    }

    public static IConfigurationBuilder AddEnvironmentVariablesWithDotSupport(this IConfigurationBuilder builder,
        Action<EnvironmentVariablesWithDotSupportConfigurationSource>? configureSource)
    {
        return builder.Add(configureSource);
    }
}
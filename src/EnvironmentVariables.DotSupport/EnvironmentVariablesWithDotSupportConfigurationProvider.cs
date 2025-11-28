namespace Extensions.Configuration.EnvironmentVariables.DotSupport;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

// ref: https://github.com/dotnet/runtime/issues/87130#issuecomment-1583859511
// ref: https://github.com/dotnet/runtime/issues/35989
/// <summary>
///     An environment variable based <see cref="ConfigurationProvider" /> that supports the use of periods (.) in
///     environment variable keys.
/// </summary>
public class EnvironmentVariablesWithDotSupportConfigurationProvider : EnvironmentVariablesConfigurationProvider
{
    internal const string DotReplacementFragment = ":_";

    public EnvironmentVariablesWithDotSupportConfigurationProvider()
    {
    }

    public EnvironmentVariablesWithDotSupportConfigurationProvider(string? prefix) : base(prefix)
    {
    }

    public override void Load()
    {
        base.Load();

        var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        foreach (var kvp in Data)
        {
            if (kvp.Key.Contains(DotReplacementFragment))
            {
                data.Add(kvp.Key.Replace(DotReplacementFragment, "."), kvp.Value);
            }
            else
            {
                data.Add(kvp.Key, kvp.Value);
            }
        }

        Data = data;
    }
}
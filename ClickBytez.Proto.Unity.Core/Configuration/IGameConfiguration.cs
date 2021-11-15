namespace ClickBytez.Proto.Unity.Core.Configuration
{
    public interface IGameConfiguration
    {
        EnvironmentConfiguration Environment { get;}
        WeatherConfiguration Weather { get; }
        OrbitrarySystemConfiguration OrbitrarySystem { get; }
        WorldConfiguration World { get; }
    }
}
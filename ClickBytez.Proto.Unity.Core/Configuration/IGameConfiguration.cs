namespace ClickBytez.Proto.Unity.Core.Configuration
{
    internal interface IGameConfiguration
    {
        EnvironmentConfiguration Environment { get;}
        WeatherConfiguration Weather { get; }
        OrbitrarySystemConfiguration OrbitrarySystem { get; }
    }
}
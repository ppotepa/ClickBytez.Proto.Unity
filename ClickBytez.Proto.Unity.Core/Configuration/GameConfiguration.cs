using UnityEngine;

namespace ClickBytez.Proto.Unity.Core.Configuration
{
    public class GameConfiguration : IGameConfiguration
    {
        [SerializeField]
        [SerializeReference]
        private WorldConfiguration world = new WorldConfiguration();

        [SerializeField]
        [SerializeReference]
        private EnvironmentConfiguration environment = new EnvironmentConfiguration();

        [SerializeField]
        [SerializeReference]
        private WeatherConfiguration weather = new WeatherConfiguration();

        [SerializeField]
        [SerializeReference]
        private OrbitrarySystemConfiguration orbitrarySystem = new OrbitrarySystemConfiguration();

        public EnvironmentConfiguration Environment
        {
            get
            {
                if(environment is null) environment = new EnvironmentConfiguration();
                return environment;
            }
        }

        public WeatherConfiguration Weather
        {
            get
            {
                if (weather is null) weather = new WeatherConfiguration();
                return weather;
            }
        }

        public OrbitrarySystemConfiguration OrbitrarySystem 
        {
            get
            {
                if (orbitrarySystem is null) orbitrarySystem = new OrbitrarySystemConfiguration();
                return orbitrarySystem;
            }
        }

        public WorldConfiguration World
        {
            get
            {
                if (world is null) world = new WorldConfiguration();
                return world;
            }
        }
    }
}

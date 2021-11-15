using UnityEngine;

namespace ClickBytez.Proto.Unity.Core.Configuration
{
    public class OrbitrarySystemConfiguration
    {
        public int NumberOfPlanets = 1;

        [Range(0, 5)]
        public float SunRotX = 0f;
        [Range(0, 5)]
        public float SunRotY = 0f;
        [Range(0, 5)]
        public float SunRotZ = 0f;
    }
}
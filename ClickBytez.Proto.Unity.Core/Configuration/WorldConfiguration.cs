using UnityEngine;

namespace ClickBytez.Proto.Unity.Core.Configuration
{
    public class WorldConfiguration
    {
        [Range(0.01f, 1000f)]
        public float WorldRadius = 1000f;

        [SerializeField]
        [SerializeReference]
        public Mesh EarthMesh;
    }
}
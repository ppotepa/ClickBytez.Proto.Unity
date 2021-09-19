using ClickBytez.Proto.Unity.Core;
using UnityEngine;

namespace ClickBytez.Proto.Unity.Modules.Environment
{
    public class EnvironmentModule : IGameModule, IEnvironment
    {
        private GameObject _sun = default;
        public GameObject Sun
        {
            get
            {
                if (_sun is null)
                {
                    _sun = GameObject.Find("Sun");
                }

                return _sun;
            }
        }
    }
}

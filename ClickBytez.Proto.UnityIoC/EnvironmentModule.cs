using Autofac.Core;
using ClickBytez.Proto.Unity.Core;
using UnityEngine;

namespace ClickBytez.Proto.Unity
{
    public class EnvironmentModule : IGameModule
    {
        private GameObject _sun;
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

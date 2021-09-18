using ClickBytez.Proto.Unity.Core;
using UnityEngine;

namespace ClickBytez.Proto.Unity.Modules.Environment
{
    public class EnvironmentModule : IGameModule
    {
        private static GameObject _sun;
        public static GameObject Sun
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

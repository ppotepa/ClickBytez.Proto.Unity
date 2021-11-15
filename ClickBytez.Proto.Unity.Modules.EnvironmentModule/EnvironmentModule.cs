using ClickBytez.Proto.Unity.Core;
using UnityEngine;

namespace ClickBytez.Proto.Unity.Modules.Environment
{
    public class EnvironmentModule : GameModule
    {
        public static int Priority => 1;
        public GameObject Sun { get; }

        public EnvironmentModule()
        {
            Sun = GameObject.Find("Sun");
        }

        public override void DoWork()
        {
            throw new System.NotImplementedException();
        }

        public override void Initialize()
        {
            throw new System.NotImplementedException();
        }
    }
}

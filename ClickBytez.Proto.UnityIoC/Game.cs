using ClickBytez.Proto.Unity.Core;
using ClickBytez.Proto.Unity.Core.Configuration;
using ClickBytez.Tools.Extensions;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ClickBytez.Proto.Unity
{
    public class Game : IGame
    {
        private readonly IGameConfiguration Configuration;
        private readonly IEnumerable<IGameModule> Modules;

        public Game(IGameConfiguration configuration, IEnumerable<IGameModule> modules)
        {
            Configuration = configuration;
            Modules = modules;
        }

        private static Action[] ExecutionStrategies = new Action[] { InitializeWorld };
        public static Action CurrentStrategy { get; private set; } = InitializeWorld;
        public static Game Instance { get; private set; }

        public List<GameObject> Objects { get; set; } = new List<GameObject>();
        
        public void Tick()
        {
            CurrentStrategy();            
        }

        internal static void InternalTick()
        {
            Instance.Modules.ForEach(module => 
            {
                module.DoWork();
            });
        }

        internal void SetInstance(Game instance)
        {
            if (Instance is null) 
            {
                Instance = instance;
            }

            else throw new InvalidOperationException("Instance already set.");
        }

        private static void InitializeWorld()
        {
            CurrentStrategy = InternalTick;
        }
    }
}

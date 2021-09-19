using ClickBytez.Proto.Unity.Core;
using ClickBytez.Proto.Unity.Core.Extensions;
using ClickBytez.Proto.Unity.Modules.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace ClickBytez.Proto.Unity
{
    public class Game : IGame
    {
        private static Random Random = new Random();
        private GameObject _camera;
        public Game(IEnvironment environment)
        {
            Environment = environment;
        }

        public static Action ExecutionStrategy { get; private set; } = InitializeWorld;
        public static Game Instance { get; private set; }
        public IEnvironment Environment { get; }
        public List<GameObject> Objects { get; set; } = new List<GameObject>();

        private GameObject Camera
        {
            get
            {
                if (_camera is null)
                {
                    _camera = GameObject.Find("Camera");
                }
                return _camera;
            }
        }

        public void Tick()
            => ExecutionStrategy();

        internal static void InternalTick()
        {
            Instance.Camera.transform.position += new Vector3(0.001f, 0.001f, 0.0f);
            Instance.Camera.transform.LookAt(new Vector3(0f, 0f, 0f));

            Instance.Environment.Sun.transform.Rotate(0.01f, 0.01f, 0.01f);
            Instance.Objects.ForEach((@object, index) =>
            {
                @object.transform.Rotate(new Vector3(0.01f * index, -0.02f * index, 0f));
            });
        }

        internal void SetInstance(Game instance)
        {
            if (Instance is null) Instance = instance;
            else throw new InvalidOperationException("Instance already set.");
        }
        private static void InitializeWorld()
        {
            Enumerable.Range(1, 500).ToList().ForEach(index =>
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3((float)Random.NextDouble() * 10f, 1f, (float)Random.NextDouble() * 100f);
                Instance.Objects.Add(cube);
            });

            ExecutionStrategy = InternalTick;
        }
    }
}

using ClickBytez.Proto.Unity.Core;
using ClickBytez.Proto.Unity.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace ClickBytez.Proto.Unity
{
    public class Game : IGame
    {
        public static readonly EnvironmentModule Environment = new EnvironmentModule();
        private static GameObject _camera;
        private static List<GameObject> Objects = new List<GameObject>();
        private static Random Random = new Random();

        public static Action ExecutionStrategy { get; set; } = InitializeWorld;

        private static GameObject Camera
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
            Camera.transform.position += new Vector3(0.001f, 0.001f, 0.0f);
            Camera.transform.LookAt(new Vector3(0f, 0f, 0f));
            Environment.Sun.transform.Rotate(0.01f, 0.01f, 0.01f);

            Objects.ForEach((@object, index) =>
            {
                @object.transform.Rotate(new Vector3(0.01f * index, -0.02f * index, 0f));
            });
        }

        private static void InitializeWorld()
        {
            Mesh testMesh = new Mesh();

            testMesh.vertices = new Vector3[4]
            {
                new Vector3(0, 0, 0),
                new Vector3(100, 0, 0),
                new Vector3(0, 100, 0),
                new Vector3(100, 100, 0)
            };

            Mesh go = GameObject.Instantiate(testMesh, new Vector3(0f, 0f, 0f), new Quaternion(45f, 0f, 0f, 1f));

            Enumerable.Range(1, 500).ToList().ForEach(index =>
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3((float)Random.NextDouble() * 10f, 1f, (float)Random.NextDouble() * 100f);
                Objects.Add(cube);
            });

            ExecutionStrategy = InternalTick;
        }
    }
}

using System.Collections.Generic;
using System;                          
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace ClickBytez.Proto.Unity
{
    class Game : IGame
    {
        public float CameraMoveUpSpeed = 1f;
        private static GameObject _sun;
        private static GameObject _camera;        
        private static System.Random Random = new System.Random();
        private static List<GameObject> Objects = new List<GameObject>();
        private static GameObject Sun
        {
            get
            {
                if (_sun is null)
                {
                    _sun = GameObject.Find("Sun");
                }
                return _sun;
            }
            set => _sun = value;
        }
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
            set => _camera = value;
        }

        public Game()
        {
            var task = new ValueTask();
        }

        private void InitializeWorld()
        {
            Enumerable.Range(1, 500).ToList().ForEach(index =>
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3((float)Random.NextDouble() * 10f, 1f, (float)Random.NextDouble() * 100f);
                Objects.Add(cube);
            });
        }
        private bool worldInitialized = false;
        public void Tick()
        {
            if (worldInitialized is false)
            {
                InitializeWorld();
                worldInitialized = true;
            }

            Objects.ForEach
            (
                gameObject =>
                {
                    float heightChange = Random.Next(1, 1000) / 1000f;
                    gameObject.transform.localScale += new Vector3(0f, 0f, heightChange);
                }
            );

            Debug.Log(Objects.Count);
            Sun.transform.Rotate(0.01f, 0.01f, 0.01f);
        }
    }
}

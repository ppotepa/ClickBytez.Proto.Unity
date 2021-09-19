using Autofac;
using ClickBytez.Proto.Unity.Core;
using ClickBytez.Proto.Unity.Core.Configuration;
using ClickBytez.Proto.Unity.Modules.Environment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClickBytez.Proto.Unity
{
    public class Manager : MonoBehaviour
    {
        private ContainerBuilder _builder = default;
        private IContainer _container = default;
        private IGame _game = default;

        private ContainerBuilder Builder
        {
            get
            {
                if (_builder is null)
                {
                    _builder = new ContainerBuilder();
                    _builder.RegisterType<EnvironmentModule>().AsImplementedInterfaces().SingleInstance();
                    _builder.RegisterType<Game>().As<IGame>().SingleInstance().OnActivated(args => args.Instance.SetInstance(args.Instance));
                }

                return _builder;
            }
            set => _builder = value;
        }

        private IContainer Container
        {
            get
            {
                if (_container is null)
                {
                    _container = Builder.Build();
                }
                return _container;
            }
            set => _container = value;
        }

        private IGame Game
        {
            get
            {
                if (_game is null)
                {
                    _game = Container.Resolve<IGame>();
                }
                return _game;
            }
        }

        public GameConfiguration GameConfiguration { get => gameConfiguration; set => gameConfiguration = value; }

        private void Awake()
        {
            // Method intentionally left empty.
        }

        IEnumerator Start()
        {
            yield return new WaitForSeconds(2.5f);
        }

        void Update()
        {
            Game.Tick();
        }


        #region UNITY_PROPERTIES  
        [SerializeField]
        [SerializeReference]
        private GameConfiguration gameConfiguration = new GameConfiguration();
        #endregion

    }
}

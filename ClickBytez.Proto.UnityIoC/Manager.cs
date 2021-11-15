using Autofac;
using ClickBytez.Proto.Unity.Core;
using ClickBytez.Proto.Unity.Core.Configuration;
using ClickBytez.Proto.Unity.Modules.Environment;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                    _builder.RegisterInstance(GameConfiguration).AsImplementedInterfaces().SingleInstance();

                    _builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                         .Where(type => type.IsSubclassOf(typeof(GameModule)))
                         .As<GameModule>()
                         .SingleInstance();

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

        public IGameConfiguration GameConfiguration { get => gameConfiguration; set => gameConfiguration = value; }

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
        private IGameConfiguration gameConfiguration = new GameConfiguration();
        #endregion

    }
}

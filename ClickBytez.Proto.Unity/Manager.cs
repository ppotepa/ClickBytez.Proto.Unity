using Autofac;
using System.Collections;
using UnityEngine;

namespace ClickBytez.Proto.Unity
{
    class Manager : MonoBehaviour
    {
        ContainerBuilder _builder = default;
        IContainer _container = default;
        IGame _game = default;
        ContainerBuilder Builder
        {
            get
            {
                if (_builder is null)
                {
                    _builder = new ContainerBuilder();
                    _builder.RegisterType<Game>().As<IGame>();
                }
                return _builder;
            }
            set => _builder = value;
        }
        IContainer Container
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
        IGame Game
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
        static void Main()
        {
            
        }

        void Awake()
        {
            
        }

        IEnumerator Start()
        {
            yield return new WaitForSeconds(2.5f);
        }

        void Update()
        {
            //Game.Tick();
        }
    }                                        
}

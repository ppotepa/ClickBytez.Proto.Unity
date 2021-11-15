using ClickBytez.Proto.Unity.Core.Configuration;

namespace ClickBytez.Proto.Unity.Core
{
    public interface IGameModule
    {
        void DoWork();
        void Initialize();
    }

    public abstract class GameModule : IGameModule
    {
        private readonly IGameConfiguration Configuration;
        protected GameModule(IGameConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected GameModule()
        {

        }

        public abstract void DoWork();
        public abstract void Initialize();
    }
}
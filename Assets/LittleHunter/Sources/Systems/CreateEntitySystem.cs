using Entitas;

namespace LittleHunter
{
    public class CreateEntitySystem : IInitializeSystem
    {
        private readonly Contexts _contexts;

        public CreateEntitySystem(Contexts contexts)
        {
            this._contexts = contexts;
        }

        public void Initialize()
        {
            _contexts.game.CreateEntity();
        }
    }
}

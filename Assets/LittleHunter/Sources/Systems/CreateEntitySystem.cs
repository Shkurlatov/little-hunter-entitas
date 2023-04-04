using Entitas;

namespace LittleHunter
{
    public class CreateEntitySystem : IInitializeSystem
    {
        private readonly Contexts contexts;

        public CreateEntitySystem(Contexts contexts)
        {
            this.contexts = contexts;
        }

        public void Initialize()
        {
            contexts.game.CreateEntity();
        }
    }
}

using LittleHunter;

public sealed class GameSystems : Feature
{
    public GameSystems(Contexts contexts)
    {
        Add(new EmitInputSystem(contexts, new UnityInputServiceImplementation()));
    }
}

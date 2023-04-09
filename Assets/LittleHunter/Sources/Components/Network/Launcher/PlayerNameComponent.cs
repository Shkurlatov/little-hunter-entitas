using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public sealed class PlayerNameComponent : IComponent
{
    public string value;
}

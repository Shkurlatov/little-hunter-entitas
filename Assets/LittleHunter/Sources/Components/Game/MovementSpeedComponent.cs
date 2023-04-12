using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public sealed class MovementSpeedComponent : IComponent
{
    public float value;
}

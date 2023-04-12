using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public sealed class RotationSpeedComponent : IComponent
{
    public float value;
}

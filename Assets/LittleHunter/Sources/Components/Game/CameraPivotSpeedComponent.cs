using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public sealed class CameraPivotSpeedComponent : IComponent
{
    public float value;
}

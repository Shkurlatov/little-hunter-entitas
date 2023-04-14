using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public sealed class CameraLookSpeedComponent : IComponent
{
    public float value;
}

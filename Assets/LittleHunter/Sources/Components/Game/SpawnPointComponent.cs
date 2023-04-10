using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique]
public sealed class SpawnPointComponent : IComponent
{
    public Vector3 position;
    public Quaternion rotation;
}

using Entitas;
using UnityEngine;

[Game]
public sealed class GameViewComponent : IComponent
{
    public GameObject gameObject;
    public Transform transform;
}

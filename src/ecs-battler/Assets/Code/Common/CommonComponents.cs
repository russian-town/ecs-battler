using Entitas;
using UnityEngine;

namespace Code.Common
{
    [Game] public class Id : IComponent { public int Value; }
    [Game] public class WorldPosition : IComponent { public Vector3 Value; }
    [Game] public class CurrentAnimationTime : IComponent { public float Value; }
}

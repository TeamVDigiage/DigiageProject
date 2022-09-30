using UnityEngine;

public abstract class BiomeBaseState
{
    public abstract void EnterState(BiomeStateManager biome);

    public abstract void UpdateState(BiomeStateManager biome);

    public abstract void OnTriggerEnter(BiomeStateManager biome, Collider other);
}

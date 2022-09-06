using UnityEngine;

public class NightState : BiomeBaseState
{
    private GameObject sun;
    private float skyboxTransition;

    public override void EnterState(BiomeStateManager biome)
    {
        sun = GameObject.Find("Directional Light");

        skyboxTransition = RenderSettings.skybox.GetFloat("_CubemapTransition");

        Debug.Log("Enter State: NightState");
    }

    public override void UpdateState(BiomeStateManager biome)
    {
        if (skyboxTransition < 0.9f )
        {
            skyboxTransition = Mathf.Lerp(skyboxTransition, 1, Time.deltaTime / 2);
            RenderSettings.skybox.SetFloat("_CubemapTransition", skyboxTransition);
        }

        sun.transform.rotation = Quaternion.RotateTowards(sun.transform.rotation, Quaternion.Euler(-90, -70, 0), 20 * Time.deltaTime);

        Debug.Log("Update State: NightState");
    }

    public override void OnTriggerEnter(BiomeStateManager biome, Collider other)
    {
        Debug.Log("Ontrigger Calisti");

        if (other.CompareTag("Day"))
        {
            biome.SwitchState(biome.DayState);
        }

        if (other.CompareTag("Twilight"))
        {
            biome.SwitchState(biome.TwilightState);
        }
        
    }


}

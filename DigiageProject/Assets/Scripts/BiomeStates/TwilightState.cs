using UnityEngine;

public class TwilightState : BiomeBaseState
{
    private GameObject sun;
    private float skyboxTransition;
    private float sunIntensityTransition;

    public override void EnterState(BiomeStateManager biome)
    {
        sun = GameObject.Find("Directional Light");

        skyboxTransition = RenderSettings.skybox.GetFloat("_CubemapTransition");
        sunIntensityTransition = sun.GetComponent<Light>().intensity;

        Debug.Log("Enter State: TwilightState");
    }

    public override void UpdateState(BiomeStateManager biome)
    {
        if (skyboxTransition < 6.9f || skyboxTransition > 7.1f)
        {
            skyboxTransition = Mathf.Lerp(skyboxTransition, 0.7f, Time.deltaTime / 2);
            RenderSettings.skybox.SetFloat("_CubemapTransition", skyboxTransition);
            
            sunIntensityTransition = Mathf.Lerp(sunIntensityTransition, 0.3f, Time.deltaTime / 2);
            sun.GetComponent<Light>().intensity = sunIntensityTransition;
        }

        sun.transform.rotation = Quaternion.RotateTowards(sun.transform.rotation, Quaternion.Euler(-30, -70, 0), 20 * Time.deltaTime);

        Debug.Log("Update State: TwilightState");
    }

    public override void OnTriggerEnter(BiomeStateManager biome, Collider other)
    {
        Debug.Log("Ontrigger Calisti");

        if (other.CompareTag("Day"))
        {
            biome.SwitchState(biome.DayState);
        }

        if (other.CompareTag("Night"))
        {
            biome.SwitchState(biome.NightState);
        }
    }
}

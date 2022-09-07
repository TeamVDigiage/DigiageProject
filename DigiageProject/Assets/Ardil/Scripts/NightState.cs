using UnityEngine;

public class NightState : BiomeBaseState
{
    private GameObject sun;
    private float skyboxTransition;
    private float sunIntensityTransition;

    public override void EnterState(BiomeStateManager biome)
    {
        sun = GameObject.Find("Directional Light");

        skyboxTransition = RenderSettings.skybox.GetFloat("_CubemapTransition");
        sunIntensityTransition = sun.GetComponent<Light>().intensity;

        Debug.Log("Enter State: NightState");
    }

    public override void UpdateState(BiomeStateManager biome)
    {
        if (skyboxTransition < 0.9f )
        {
            skyboxTransition = Mathf.Lerp(skyboxTransition, 1, Time.deltaTime / 2);
            RenderSettings.skybox.SetFloat("_CubemapTransition", skyboxTransition);

            sunIntensityTransition = Mathf.Lerp(sunIntensityTransition, 0.1f, Time.deltaTime / 2);
            sun.GetComponent<Light>().intensity = sunIntensityTransition;
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

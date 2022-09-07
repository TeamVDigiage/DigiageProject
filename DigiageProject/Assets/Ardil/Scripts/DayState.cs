using UnityEngine;
using UnityEngine.Rendering;

public class DayState : BiomeBaseState
{
    private GameObject sun;
    //private Volume globalVolume;
    private float skyboxTransition;
    private float sunIntensityTransition;

    public override void EnterState(BiomeStateManager biome)
    {
        sun = GameObject.Find("Directional Light");
        //globalVolume = GameObject.Find("Global Volume").GetComponent<Volume>();

        skyboxTransition = RenderSettings.skybox.GetFloat("_CubemapTransition");
        sunIntensityTransition = sun.GetComponent<Light>().intensity;

        Debug.Log("Enter State: DayState");
    }

    public override void UpdateState(BiomeStateManager biome)
    {
        if (skyboxTransition > 0.1f)
        {
            skyboxTransition = Mathf.Lerp(skyboxTransition, 0, Time.deltaTime / 2);
            RenderSettings.skybox.SetFloat("_CubemapTransition", skyboxTransition);

            //globalVolume.profile.
            //sunIntensityTransition = Mathf.Lerp(sunIntensityTransition, 1.7f, Time.deltaTime / 2);
            sun.GetComponent<Light>().intensity = sunIntensityTransition;
        }

        sun.transform.rotation = Quaternion.RotateTowards(sun.transform.rotation, Quaternion.Euler(60, -70, 0), 20 * Time.deltaTime);

        Debug.Log("Update State: DayState");
    }

    public override void OnTriggerEnter(BiomeStateManager biome, Collider other)
    {
        Debug.Log("Ontrigger Calisti");
        
        if (other.CompareTag("Twilight"))
        {
            biome.SwitchState(biome.TwilightState);
        }

        if (other.CompareTag("Night"))
        {
            biome.SwitchState(biome.NightState);
        }
    }
    


}

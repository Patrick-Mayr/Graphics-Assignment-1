using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleIllumination : MonoBehaviour
{
    public Material toonRamp;
    public Material diffuseAmbientSpecular;
    public Material diffuseAmbient;
    public Material defaultShader;
    public Light directionalLight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GetComponent<Renderer>().material = toonRamp;
            Debug.Log("toonramp");
            directionalLight.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GetComponent<Renderer>().material = diffuseAmbientSpecular;
            Debug.Log("diffuse ambient specular");
            directionalLight.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GetComponent<MeshRenderer>().material = diffuseAmbient;
            Debug.Log("diffuse ambient");
            directionalLight.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GetComponent<MeshRenderer>().material = defaultShader;
            directionalLight.gameObject.SetActive(true);
            
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            directionalLight.gameObject.SetActive(false);

        }


    }
}

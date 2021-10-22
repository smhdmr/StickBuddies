using UnityEngine;

[System.Serializable]
public class Sound 
{

    //AUDIO NAME 
    public string name;

    //AUDIO CLIP
    public AudioClip clip;

    //AUDIO SOURCE 
    [HideInInspector]
    public AudioSource source;

    //SOUND ATTRIBUTES
    [Range(0f, 1f)]
    public float volume = 1f;

    [HideInInspector]
    public float pitch = 1f;

    [HideInInspector]
    public float spatialBlend = 0f;

    [HideInInspector]
    public bool playOnAwake = false;

    public bool loop = false;    

}

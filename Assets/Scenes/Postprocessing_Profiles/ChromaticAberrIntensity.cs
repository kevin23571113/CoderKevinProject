using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChromaticAberrIntensity : MonoBehaviour
{
    public PostProcessVolume globalPost;
    private Bloom blomy;

    void Start()
    {
        globalPost.profile.TryGetSettings(out blomy);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            blomy.intensity.value = 8;
        }
    }
}

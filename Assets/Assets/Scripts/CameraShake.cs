using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;

    [SerializeField] Animator screenShake;

    

    void Awake()
    {
        if (Instance == null)
        {
        Instance = this;
        }

    }
    public void Shake()
    {
        int rand = Random.Range(0, 3);


        if (rand == 0)
        {
            screenShake.SetTrigger("Shake");
        }

        if (rand == 1)
        {
            screenShake.SetTrigger("Shake01");
        }
        
        if(rand == 2)
        {
            screenShake.SetTrigger("Shake02");
        }   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManagerInstance;

    [SerializeField] AudioSource backgroundMusic;

    [SerializeField] AudioSource holeRightSFX;

    [SerializeField] AudioSource holeWrongSFX;

    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic.Play();
        if (audioManagerInstance == null)
        {
            audioManagerInstance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void RightCubeEffect()
    {
        holeRightSFX.Play();
    }

    public void WrongCubeEffect()
    {
        holeWrongSFX.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

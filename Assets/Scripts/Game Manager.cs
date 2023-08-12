using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private AudioSource auidoSource;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        auidoSource = GetComponent<AudioSource>();
    }

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene); //you can add a loading screen and load new level async but I dont think it is necessary for small game it is instant anyway
    }

    public void ToggleAudio()
    {
        auidoSource.mute = !auidoSource.mute; // I could make a seperate audio manager but I dont have many functionality about it so I added it to game manager
    }
}
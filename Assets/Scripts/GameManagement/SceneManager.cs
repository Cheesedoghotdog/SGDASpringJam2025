using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
    public NextScene instance;
    public static bool LevelComplete = false;
    public static bool Died = false;
    [SerializeField] private Animator transitionAnim;
    public static int time;
    private bool TimeFixed = false;
    [SerializeField] private AudioSource Audio;
    private float AudioChange;
    [SerializeField] private AudioClip Music;


    private void Awake() {
        if(SceneManager.GetActiveScene().buildIndex == 0) {
        Audio.volume = 0.3f; } else {
            Audio.volume = 0.0f;
        }
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    



    public void Next() {
        if (time == 0) {
        transitionAnim.SetTrigger("LevelOver");
        }
        if (time == 120) {
        LevelComplete = false; 
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("LevelStart");
        PlayerMovement.Temperature = 0;
        TimeFixed = false;
        if(SceneManager.GetActiveScene().buildIndex == 0) {
        AudioChange = 0.003f;
        Audio.clip = Music;
        Audio.Play();}}
    }

    public void Death() {
        if (time == 0) {
        Debug.Log(Audio.clip);
        Debug.Log(Audio.volume);
        transitionAnim.SetTrigger("LevelOver");
        }
        if (time == 120) {
        Died = false;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        transitionAnim.SetTrigger("LevelStart");
        PlayerMovement.Temperature = 0;
        TimeFixed = false;}
    }
    
    private void FixTime() {
        time = 0;
        TimeFixed = true;
        if (SceneManager.GetActiveScene().buildIndex == 0) {
        AudioChange = -0.003f;}
    }


    public void Quit() {
        Application.Quit();
    }
    public void Complete() {
        LevelComplete = true;
    }



    public void MainMenu() {
        StartCoroutine(LoadMenu());
    }
    IEnumerator LoadMenu() {
        transitionAnim.SetTrigger("LevelOver");
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(0);
        transitionAnim.SetTrigger("LevelStart");
    }
    private void FixedUpdate() {
        time++;
        if(LevelComplete) {
            if (!TimeFixed) {
                FixTime();
            }
            Next();
        }
        if(Died) {
            if (!TimeFixed) {
                FixTime();
            }
            Death();
        }
        gameObject.SetActive(true);
        if (Audio.volume < 0.31f) {
        Audio.volume = Audio.volume += AudioChange;
        }
    }

}
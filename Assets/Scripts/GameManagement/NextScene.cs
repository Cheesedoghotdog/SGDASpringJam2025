using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
    public NextScene instance;
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
        if (time == 120) {
        Debug.Log("AAAA");
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("LevelStart");
        TimeFixed = false;
        if(SceneManager.GetActiveScene().buildIndex == 0) {
        AudioChange = 0.003f;
        Audio.clip = Music;
        Audio.Play();
        }
        } else {
        FixTime();
        transitionAnim.SetTrigger("LevelOver");
        Debug.Log("BBBBB");
        }
    }
    
    private void FixTime() {
        time = 0;
        TimeFixed = true;
        if (SceneManager.GetActiveScene().buildIndex == 0) {
        AudioChange = -0.003f;}
    } //This sets time back to 0 so it can start counting again.


    public void Quit() {
        Application.Quit();
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
        gameObject.SetActive(true);
        if (Audio.volume < 0.31f) {
        Audio.volume = Audio.volume += AudioChange;
        if (time == 120) {
            Next();
        }
        }
    }

}
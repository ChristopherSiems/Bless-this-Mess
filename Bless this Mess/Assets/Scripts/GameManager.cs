using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    public TMP_Text clock;
    public float timer = 0;
    public float limit;
    private int min;
    private int sec;
    private float diff;
    public int scene;
    public int scene2;
    public int trash = 0;
    public bool chicken = false;

    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        timer += Time.deltaTime;
        diff = limit - timer;
        min = (int)diff / 60;
        sec = (int)diff - (min * 60);
        if (sec >= 10){
            clock.text = $"{min}:{sec}";
        }
        else{
            clock.text = $"{min}:0{sec}";
        }
        if (diff <= 0){
            SceneManager.LoadScene(scene);
        }
        if (trash == 3 && chicken){
            SceneManager.LoadScene(scene2);
        }
    }
}
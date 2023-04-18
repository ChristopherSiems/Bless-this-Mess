using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour{
    public TMP_Text clock;
    public float timer = 0;
    public float limit;
    private int min;
    private int sec;
    private float diff;

    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        timer += Time.deltaTime;
        diff = limit - timer;
        min = (int)diff / 60;
        sec = (int)diff - (min * 60);
        if (sec > 10){
            clock.text = $"{min}:{sec}";
        }
        else{
            clock.text = $"{min}:0{sec}";
        }
        /*if (timer >= limit){

        }*/
    }
}
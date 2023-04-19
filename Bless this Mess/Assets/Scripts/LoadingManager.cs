using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour{
    public float limit;
    public int scene;
    private float timer;

    // Update is called once per frame
    void Update(){
        timer += Time.deltaTime;
        if (timer >= limit){
            SceneManager.LoadScene(scene);
        }
    }
}
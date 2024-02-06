using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreKeeper : MonoBehaviour
{
    
    public static scoreKeeper instance;
    public static float clouds_popped;
    public static float cloud_high_score;
    public static float current_timer;

    public static float timed_high_score;

  

    public static void update_clouds_popped(){
        clouds_popped = clouds_popped + 1;
    }

    public static void reset_clouds_popped(){
        clouds_popped = 0;
    }

    public static void update_cloud_high_score(float value){
    
        PlayerPrefs.SetFloat("CloudHighScore", value);
        PlayerPrefs.Save();

        cloud_high_score = value;
        //Debug.Log(cloud_high_score);

    }

    public static void update_timed_high_score(float value){
        PlayerPrefs.SetFloat("TimedHighScore", value);
        PlayerPrefs.Save();

        timed_high_score = value;
        //Debug.Log(timed_high_score);

    }

    public static float get_timed_high_score(){
        timed_high_score = PlayerPrefs.GetFloat("TimedHighScore"); 
        //Debug.Log(timed_high_score);

        return timed_high_score;
    }

    public static float get_cloud_high_score(){
        cloud_high_score = PlayerPrefs.GetFloat("CloudHighScore"); 
        //Debug.Log(cloud_high_score);
        return cloud_high_score;
    }

    public static float get_clouds_popped(){
        return clouds_popped;
    }

    public static float get_current_timer(){
        return current_timer;
    }
    public static void update_current_timer(float value){
         current_timer = value;
    }

    void Start(){

        if(instance != null && instance != this){
            Destroy(this);
        }
        else{
            instance = this;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using Random=UnityEngine.Random;
public class bump_cloud : MonoBehaviour
{
    public Animator anim;
    private GameObject old_cloud; 

public Vector3 position = new Vector3(0.0f,0f,0f);    
public Vector3 upperRight = new Vector3(0.0f,0f,0f);
public Vector3 bottomLeft = new Vector3(0.0f,0f,0f);    
public GameObject dragon;
public GameObject cloud;

private int bumped;
public RectTransform panel;
    // Start is called before the first frame update
    void Start()
    {
            anim.Play("cloud_dance");
            bumped = 0;
            upperRight = GetTopRightCorner(panel);
            bottomLeft = GetBottomLeftCorner(panel);


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)   
    {

           if(bumped == 0){

            bumped = 1;
            anim.Play("cloud_remove");
            //Debug.Log(scoreKeeper.clouds_popped.ToString());
            old_cloud = GameObject.Find(scoreKeeper.get_clouds_popped().ToString());

            //Debug.Log(scoreKeeper.get_clouds_popped());
  
            Vector3 spawnPosition = new Vector3(Random.Range(bottomLeft.x, upperRight.x), Random.Range(bottomLeft.y, upperRight.y), cloud.transform.position.z);


            var old_position = position;
            //Debug.Log(panel.rect.x);
            //Debug.Log(panel.rect.y);
            while((Math.Abs(old_position.x - spawnPosition.x) < 500) || (Math.Abs(old_position.y - spawnPosition.y) < 500)){
                spawnPosition = new Vector3(Random.Range(bottomLeft.x, upperRight.x), Random.Range(bottomLeft.y, upperRight.y), cloud.transform.position.z);          
                }
            //Debug.Log(spawnPosition);

            GameObject newObject = Instantiate(old_cloud, spawnPosition , old_cloud.transform.rotation); 
            Destroy(old_cloud, 0.15f);     
            scoreKeeper.update_clouds_popped();
            //Debug.Log(scoreKeeper.clouds_popped.ToString());


            newObject.name = scoreKeeper.get_clouds_popped().ToString();
            EventManager.OnScoreUpdate();

          }
    }

    Vector3 GetBottomLeftCorner(RectTransform rt)
    {
        Vector3[] v = new Vector3[4];
        rt.GetWorldCorners(v);
        //Debug.Log(v[0]);
        return v[0];

    }
      Vector3 GetTopRightCorner(RectTransform rt)
    {
        Vector3[] v = new Vector3[4];
        rt.GetWorldCorners(v);
        //Debug.Log(v[2]);
        return v[2];

    }


    void OnCollisionExit2D(Collision2D col)
        {
          
            
            //anim.Play("color_dance");

         
        }


        

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;
public class wake_up_cloud : MonoBehaviour
{
    public Animator anim;
    static public bool done = false;
    //private GameObject old_cloud; 

    // Start is called before the first frame update
    void Start()
    {

      // _scoreTimeText = GetComponent<time_score>();
    }

    // Update is called once per frame
    void Update()
    {   
   
        
                  
        
    }
     IEnumerator wait_seconds(){
        yield return new WaitForSeconds(10);

    }
    void OnCollisionEnter2D(Collision2D other)   
    {
    

            anim.Play("wake_up");
            //yourText.enabled = true;
            Debug.Log(scoreKeeper.get_clouds_popped());
            Debug.Log( scoreKeeper.get_cloud_high_score());

            if(scoreKeeper.get_clouds_popped() > scoreKeeper.get_cloud_high_score()){
                scoreKeeper.update_cloud_high_score(scoreKeeper.get_clouds_popped());
            }
            scoreKeeper.reset_clouds_popped();
            SceneManager.LoadScene("play_again_cloud");

    }
            
    void OnCollisionExit2D(Collision2D col)
        {
            

        }
    public void Menu ()
   {
      if(scoreKeeper.get_clouds_popped() > scoreKeeper.get_cloud_high_score()){
                scoreKeeper.update_cloud_high_score(scoreKeeper.get_clouds_popped());
            }
      scoreKeeper.reset_clouds_popped();
      SceneManager.LoadScene("menu");
   }

}

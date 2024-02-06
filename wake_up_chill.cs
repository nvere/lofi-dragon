using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;
public class wake_up_chill : MonoBehaviour
{
    public Animator anim;
    static public bool done = false;

    // Start is called before the first frame update
    void Start()
    {
      // _scoreTimeText = GetComponent<time_score>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
  
    void OnCollisionEnter2D(Collision2D other)   
    {
    

                anim.Play("wake_up");


            
    
        }
    void OnCollisionExit2D(Collision2D col)
        {
                anim.Play("snore");
                //EventManager.OnTimerUpdate(0);
            //EventManager.OnTimerStart();
            //yourText.enabled = false;

        }
    public void Menu ()
   {
      SceneManager.LoadScene("menu");
   }
}

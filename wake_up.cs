using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;
public class wake_up : MonoBehaviour
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
        EventManager.OnTimerStop();
       // yourText.enabled = true;
        if(scoreKeeper.get_current_timer() > scoreKeeper.get_timed_high_score()){
                scoreKeeper.update_timed_high_score(scoreKeeper.get_current_timer());
            }

        SceneManager.LoadScene("play_again_timed");
        }
    void OnCollisionExit2D(Collision2D col)
        {
                //anim.Play("snore");
                //EventManager.OnTimerUpdate(0);
            //EventManager.OnTimerStart();
            //yourText.enabled = false;

        }
    public void Menu ()
   {
    if(scoreKeeper.get_current_timer() > scoreKeeper.get_timed_high_score()){
          scoreKeeper.update_timed_high_score(scoreKeeper.get_current_timer());
            }
      SceneManager.LoadScene("menu");
   }

}

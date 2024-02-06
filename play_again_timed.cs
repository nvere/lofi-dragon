using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class play_again_timed : MonoBehaviour
{
    public Animator anim;

    public void Yes ()
    {

        SceneManager.LoadScene("game_timed_mode");
    }
    public void No ()
    {

        SceneManager.LoadScene("menu");
    }
    void Start(){
        anim.Play("wake_up");

    }

}

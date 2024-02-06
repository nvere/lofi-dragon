using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class play_again_cloud : MonoBehaviour
{
    public Animator anim;

    public void Yes ()
    {
        scoreKeeper.reset_clouds_popped();

        SceneManager.LoadScene("game_cloud_mode");
    }
    public void No ()
    {

        SceneManager.LoadScene("menu");
    }
    void Start(){
        anim.Play("wake_up");

    }

}

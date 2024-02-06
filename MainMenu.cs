using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine.Advertisements;
public class MainMenu : MonoBehaviour
{

   public TMP_Text _timerText;
   public TMP_Text _cloudText;

   public void ChillGame ()
   {
      SceneManager.LoadScene("game_chill_mode");
   }
   public void TimedGame ()
   {
      SceneManager.LoadScene("game_timed_mode");
   }

   public void CloudGame ()
   {
      scoreKeeper.reset_clouds_popped();

      SceneManager.LoadScene("game_cloud_mode");
   }
   public void MusicCredits ()
   {

      SceneManager.LoadScene("music_credits");
   }
   public void displayTimedScore()
   {
      TimeSpan timeSpan = TimeSpan.FromSeconds(scoreKeeper.get_timed_high_score());
      _timerText.text = timeSpan.ToString(@"mm\:ss\:ff");

   }
   public void displayCloudScore()
   {
        _cloudText.text = scoreKeeper.get_cloud_high_score().ToString();

   }
   void Start()
   {

         
         displayCloudScore();
         displayTimedScore();

   }
}

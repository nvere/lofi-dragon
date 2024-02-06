using System;
using UnityEngine;
using TMPro;

public class scoreCounter : MonoBehaviour
{
    #region Variables

    private TMP_Text _scoreText;


    [SerializeField] public float scoreToDisplay = 0;


    #endregion
    
    private void Awake() {
        _scoreText = GetComponent<TMP_Text>();
  
    }

    private void OnEnable()
    {

        EventManager.ScoreUpdate += EventManagerOnScoreUpdate;
    }

    private void OnDisable()
    {

        EventManager.ScoreUpdate -= EventManagerOnScoreUpdate;
    }

 

    private void EventManagerOnScoreUpdate(){
        scoreToDisplay = scoreToDisplay + 1;
    
    } 



    private void Update()
    {
        _scoreText.text = scoreToDisplay.ToString();
    }
}
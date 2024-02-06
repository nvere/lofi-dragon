using System;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    #region Variables
    public Animator anim;

    private TMP_Text _timerText;

    public GameObject objectToSpawn;
    enum TimerType { Stopwatch, Countdown}
    [SerializeField] private TimerType timerType;

    [SerializeField] public float timeToDisplay = 0;

    private bool _isRunning;
    private int spawned = 0;
    int stars_spawned = 1;
    
    Vector3 starting_position = new Vector3 (0,0,90);
    #endregion
 
    private void Awake() {
        //objectToSpawn.SetActive(false);
        _timerText = GetComponent<TMP_Text>();
        //anim.Play("star_stay");
        starting_position.x = objectToSpawn.transform.position.x;
        starting_position.y = objectToSpawn.transform.position.y;
        starting_position.z = objectToSpawn.transform.position.z;
        spawned = 0;
        GameObject.Find("1").GetComponent<Animator>().Play("default");

    }

    private void OnEnable()
    {
        EventManager.TimerStart += EventManagerOnTimerStart;
        EventManager.TimerStop += EventManagerOnTimerStop;
        EventManager.TimerUpdate += EventManagerOnTimerUpdate;
    }

    private void OnDisable()
    {
        EventManager.TimerStart -= EventManagerOnTimerStart;
        EventManager.TimerStop -= EventManagerOnTimerStop;
        EventManager.TimerUpdate -= EventManagerOnTimerUpdate;
    }

    private void Spawn(){

        //Vector2 pos = new Vector2(370,1605);
        GameObject newObject = Instantiate(GameObject.Find("1"), starting_position, GameObject.Find("1").transform.rotation);
       // newObject.layer = 5;

        stars_spawned = stars_spawned + 1;
        Debug.Log(newObject.name);
        newObject.name = stars_spawned.ToString();
        Debug.Log(newObject.name);
        GameObject.Find( newObject.name).GetComponent<Animator>().Play("default");


        spawned = 1;

    }
    private void EventManagerOnTimerStart() => _isRunning = true;
    private void EventManagerOnTimerStop() => _isRunning = false;
    private void EventManagerOnTimerUpdate(float value){
        timeToDisplay = value;
    
    } 
    private void Start(){
           EventManager.OnTimerUpdate(0);
           EventManager.OnTimerStart();
           //_scoreTimeText.text = "";
    }
    private void Update()
    {
        if (!_isRunning) return;
        if (timerType == TimerType.Countdown && timeToDisplay < 0.0f)
        {
            EventManager.OnTimerStop();
            return;
        }
        timeToDisplay += timerType == TimerType.Countdown ? -Time.deltaTime : Time.deltaTime;
        //Debug.Log(timeToDisplay);
        //Debug.Log(timeToDisplay % 10 == 0);
        //Debug.Log(timeToDisplay);
       // Debug.Log(stars_spawned);
        if ((timerType == TimerType.Stopwatch) && (timeToDisplay % 10 < 0.1) && (timeToDisplay > 0.1))
        {
       
            if(spawned == 0 && stars_spawned < 3){
                Spawn();
                Debug.Log("spawning");

            }
            else if(spawned == 0 && stars_spawned == 3){
                GameObject.Find("1").GetComponent<Animator>().Play("explode");
                Destroy(GameObject.Find("1"), 0.15f);
                //Debug.Log("destroying");

                //Debug.Log(GameObject.Find("2").name);
                 GameObject.Find("2").name = "1";

                GameObject.Find("3").name = "2";
                //Debug.Log(GameObject.Find("1").name);

                //GameObject.Find("2").name = "1";
                stars_spawned = 2;


            } 

        }
        else if ((spawned == 1) && (timeToDisplay % 12 < 0.1) && (timeToDisplay > 0.1)){
            spawned = 0;
            Debug.Log("Not spawning");

        }

        scoreKeeper.update_current_timer(timeToDisplay);
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeToDisplay);
        _timerText.text = timeSpan.ToString(@"mm\:ss\:ff");
    }
}
using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;
public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] bool _testMode = false;
    private string _gameId;
 
    void Awake()
    {
        _gameId = "5522973";

        InitializeAds();
    }
 
    public void InitializeAds()
    {
            Advertisement.Initialize(_gameId,_testMode,this);
            ShowBanner();
    }

    public void ShowBanner(){
   
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show("Menu_Banner");
            Debug.Log("Showing ad");

       
    }
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");

    }
 
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }


}
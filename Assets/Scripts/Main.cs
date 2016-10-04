using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Main : MonoBehaviour
{
    private const string ACTIVE_BUTTON_TEXT = "Play Video";
    private const string INACTIVE_BUTTON_TEXT = "In Progress...";
    public AppodealController appodealController;
    public Button playButton;
    public Text buttonText;
    public Button restartButton;

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        appodealController.Init();
        appodealController.OnAdShownEventReceived += AdsAnyEvent;
        SetupButtons();
    }

    private void SetupButtons()
    {
        playButton.onClick.AddListener(ShowVideo);
        restartButton.onClick.AddListener(Restart);
        
        if (buttonText != null)
            buttonText.text = ACTIVE_BUTTON_TEXT;
    }
    
    private void AdsAnyEvent(AdResult result)
    {
        switch (result)
        {
            case AdResult.Failed:
                {
                    Debug.Log("appodeal: Ad failed");
                    break;
                }
            case AdResult.Skipped:
                {
                    Debug.Log("appodeal: Ad skipped");
                    break;
                }
            case AdResult.Finished:
                {
                    Debug.Log("appodeal: Ad shown");
                    break;
                }
        }

        ActivateButton();
    }

    public void ShowVideo()
    {
        if (!appodealController.IsReady())
        {
            Debug.Log("appodeal: Ad is not ready!");
            //return;
        }

        Debug.Log("appodeal: Start ad showing");
        DeactivateButton();
        appodealController.ShowAd();
    }

    private void ActivateButton()
    {
        playButton.interactable = true;

        if (buttonText != null)
            buttonText.text = ACTIVE_BUTTON_TEXT;
    }

    private void DeactivateButton()
    {
        playButton.interactable = false;
        
        if (buttonText != null)
            buttonText.text = INACTIVE_BUTTON_TEXT;
    }

    private void Restart()
    {
        Application.LoadLevel(0);
    }
}

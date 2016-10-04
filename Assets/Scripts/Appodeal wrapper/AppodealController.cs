using System;
using System.Collections.Generic;
using AppodealAds.Unity.Api;
using UnityEngine;

public partial class AppodealController : MonoBehaviour
{
    public event Action<AdResult> OnAdShownEventReceived;

    public readonly static Queue<Action> ExecuteOnMainThread = new Queue<Action>();
    private SkippableVideoAdListener _skippableVideoAdListener;
    private int _ads;

    public void Init()
    {
        Appodeal.setLogging(true);
        _ads += Appodeal.SKIPPABLE_VIDEO;
        _skippableVideoAdListener = new SkippableVideoAdListener(AdListner);
        Appodeal.setSkippableVideoCallbacks(_skippableVideoAdListener);
        Appodeal.confirm(_ads);
        Appodeal.initialize(APP_KEY, _ads);
    }

    private void Update()
    {
        while (ExecuteOnMainThread.Count > 0)
        {
            ExecuteOnMainThread.Dequeue().Invoke();
        }
    }

    private void AdListner(AdResult result)
    {
        Debug.Log("appodeal: AdListener invoked");
        ExecuteOnMainThread.Enqueue(() => { 
            if (OnAdShownEventReceived != null)
                OnAdShownEventReceived(result);
        });
    }

    public void ShowAd()
    {
        Appodeal.show(_ads);
        Debug.Log("appodeal: show, adTypes = " + _ads);
    }

    public bool IsReady()
    {
        return Appodeal.isLoaded(_ads);
    }
}
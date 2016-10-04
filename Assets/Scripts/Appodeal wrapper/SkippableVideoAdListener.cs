using System;
using AppodealAds.Unity.Common;
using UnityEngine;

public class SkippableVideoAdListener : ISkippableVideoAdListener
{
    private readonly Action<AdResult> _callBackAction;

    public SkippableVideoAdListener(Action<AdResult> callBack)
    {
        _callBackAction = callBack;
    }

    public void onSkippableVideoLoaded()
    {
        Debug.Log("appodeal: onSkippableVideoLoaded");
    }

    public void onSkippableVideoFailedToLoad()
    {
        Debug.Log("appodeal: onSkippableVideoFailedToLoad");
        _callBackAction(AdResult.Failed);
    }

    public void onSkippableVideoShown()
    {
        Debug.Log("appodeal: onSkippableVideoShown");
    }

    public void onSkippableVideoFinished()
    {
        Debug.Log("appodeal: onSkippableVideoFinished");
        _callBackAction(AdResult.Finished);
    }

    public void onSkippableVideoClosed()
    {
        Debug.Log("appodeal: onSkippableVideoClosed");
        _callBackAction(AdResult.Skipped);
    }
}
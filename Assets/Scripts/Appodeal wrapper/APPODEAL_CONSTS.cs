public enum AdResult
{
    Failed,
    Skipped,
    Finished
}

public partial class AppodealController
{
#if UNITY_ANDROID
    private const string APP_KEY = "94f56a023a4bb497efda58bea08dce85a018c38bed4273bf";
#elif UNITY_IOS
    private const string APP_KEY = "10641ca32e523211ff58bc897ad4dfeda1d507249213223f";
#endif
}

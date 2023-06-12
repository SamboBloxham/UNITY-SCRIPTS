using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SystemSettingsUtility
{
    public static void OpenNotificationSettings()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent");
            intent.Call<AndroidJavaObject>("setAction", "android.settings.APP_NOTIFICATION_SETTINGS");
            intent.Call<AndroidJavaObject>("putExtra", "android.provider.extra.APP_PACKAGE", currentActivity.Call<string>("getPackageName"));
            currentActivity.Call("startActivity", intent);
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            string url = "app-settings:";
            Application.OpenURL(url);
        }

    }

}

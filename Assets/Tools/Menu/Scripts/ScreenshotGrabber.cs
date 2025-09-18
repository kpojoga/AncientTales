#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class ScreenshotGrabber
{
    [MenuItem("Screenshot/X_1242x2688/1")]
    public static void Grab1()
    {
        ScreenCapture.CaptureScreenshot("D:/screenshots/X/1.png", 1);
    }
    [MenuItem("Screenshot/X_1242x2688/2")]
    public static void Grab2()
    {
        ScreenCapture.CaptureScreenshot("D:/screenshots/X/2.png", 1);
    }
    [MenuItem("Screenshot/X_1242x2688/3")]
    public static void Grab3()
    {
        ScreenCapture.CaptureScreenshot("D:/screenshots/X/3.png", 1);
    }
    [MenuItem("Screenshot/X_1242x2688/4")]
    public static void Grab4()
    {
        ScreenCapture.CaptureScreenshot("D:/screenshots/X/4.png", 1);
    }

    [MenuItem("Screenshot/8_1242x2208/1")]
    public static void Grab5()
    {
        ScreenCapture.CaptureScreenshot("D:/screenshots/8/1.png", 1);
    }
    [MenuItem("Screenshot/8_1242x2208/2")]
    public static void Grab6()
    {
        ScreenCapture.CaptureScreenshot("D:/screenshots/8/2.png", 1);
    }
    [MenuItem("Screenshot/8_1242x2208/3")]
    public static void Grab7()
    {
        ScreenCapture.CaptureScreenshot("D:/screenshots/8/3.png", 1);
    }
    [MenuItem("Screenshot/8_1242x2208/4")]
    public static void Grab8()
    {
        ScreenCapture.CaptureScreenshot("D:/screenshots/8/4.png", 1);
    }
}
#endif

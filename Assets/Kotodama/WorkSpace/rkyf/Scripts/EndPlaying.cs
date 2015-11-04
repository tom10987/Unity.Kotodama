using UnityEngine;
using System.Collections;

public class EndPlaying : CallGameOver
{

    // Use this for initialization
    void Start()
    {
        
    }

    // アプリケーション終了イベントの取得
    void OnApplicationQuit()
    {

    }

    void Quit()
    {
        Application.Quit();
    }
}

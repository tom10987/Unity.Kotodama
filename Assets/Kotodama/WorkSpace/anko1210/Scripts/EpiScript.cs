using UnityEngine;
using System.Collections;

public class EpiScript : MonoBehaviour {

    SceneSequencer _sequencer = null;

    void Start()
    {
        _sequencer = FindObjectOfType<SceneSequencer>();
        //_sequencer = GetComponent<SceneSequencer>();
        Debug.Log(_sequencer);
    }

    // アプリケーション終了イベントの取得
    public void GameQuit()
    {
        Debug.Log("イベント終了ボタンが反応しました。");
        Application.Quit();
    }

    public void GoTitle()
    {
        Debug.Log("タイトル画面へ戻るボタンが押されました。");
        _sequencer.SceneFinish("Title");
    }
}

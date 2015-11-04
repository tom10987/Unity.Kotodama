using UnityEngine;

public class EndPlaying : CallGameOver
{
    SceneSequencer _sequencer = null;

    void Start()
    {
        _sequencer = FindObjectOfType<SceneSequencer>();
    }

    // アプリケーション終了イベントの取得
    public void GameQuit()
    {
        Debug.Log("イベント終了ボタンが反応しました。");
        Application.Quit();
    }

    public new void GoTitle()
    {
        Debug.Log("タイトル画面へ戻るボタンが押されました。");
        _sequencer.SceneFinish("Title");
    }
}



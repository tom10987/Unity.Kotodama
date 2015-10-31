using UnityEngine;

public class MenuButton : MonoBehaviour {

    SceneSequencer _sequencer;

    public GameObject _menuCanvas;

    void Start()
    {
        _sequencer = FindObjectOfType<SceneSequencer>();

        // デバッグ時はテスト用に最初からtrue
        // 実装時は初期falseでメニュー画面に入ったときにtrueに変える
        _menuCanvas.GetComponent<Canvas>().enabled = true;

        // 本来のコード
        //_menuCanvas.GetComponent<Canvas>().enabled = false;
    }

    //public void IntoMenu()
    //{
    //    if (メニューボタンが押されたら)
    //    {
    //        _menuCanvas.GetComponent<Canvas>().enabled = true;
    //    }
    //}

    public void BackToTitle()
    {
        _sequencer.SceneFinish("Title");
    }

    public void BackToGame()
    {
        _menuCanvas.GetComponent<Canvas>().enabled = false;
    }

}

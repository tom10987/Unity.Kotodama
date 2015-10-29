using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChapterSelectButton : MonoBehaviour {

    public Text ChapMsg;
    [SerializeField]
    private string _chapter01Name = "";

    SceneSequencer _sequencer = null;

    void Start() {
        _sequencer = FindObjectOfType<SceneSequencer>();
    }

    public void ChangeChapter1() {
        //Application.LoadLevel(_chapter01Name);
        _sequencer.SceneFinish("Chapter1");
    }

    public void ChangeChapter2()
    {
        ChapMsg.text = "チャプター２は解放されていません。";
//        Application.LoadLevel("Chapter2");
    }

    public void ChangeChapter3()
    {
        ChapMsg.text = "チャプター３は解放されていません。";
        //       Application.LoadLevel("Chapter3");
    }

}

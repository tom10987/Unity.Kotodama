using UnityEngine;
using UnityEngine.UI;


public class ChapterSelectButton : MonoBehaviour {

  Text _chapMsg;

  [SerializeField]
  string[] _chapterName = null;

  SceneSequencer _sequencer = null;

  void Start() {
    _chapMsg = GameObject.Find("ChapMsg").GetComponent<Text>();
    _sequencer = FindObjectOfType<SceneSequencer>();
  }

  public void ChangeChapter1() {
    //Application.LoadLevel(_chapter01Name);
    _sequencer.SceneFinish(_chapterName[0]);
  }

  public void ChangeChapter2() {
    _chapMsg.text = "チャプター２は解放されていません。";
    //        Application.LoadLevel("Chapter2");
  }

  public void ChangeChapter3() {
    _chapMsg.text = "チャプター３は解放されていません。";
    //       Application.LoadLevel("Chapter3");
  }
}

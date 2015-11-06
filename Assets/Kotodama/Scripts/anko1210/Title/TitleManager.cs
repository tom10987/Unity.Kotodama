
using UnityEngine;
using UnityEngine.UI;


public class TitleManager : MonoBehaviour {

  static public bool isSelect { get; private set; }
  static public float buttonAlpha { get; private set; }
  public bool effectPlaying { get { return buttonAlpha > 0f; } }

  SceneSequencer _sequencer = null;
  Text _telop = null;


  void Awake() {
    isSelect = false;
    buttonAlpha = 1f;
  }

  void Update() {
    if (!isSelect) { return; }
    if (buttonAlpha > 0f) { buttonAlpha -= Time.deltaTime; }
  }


  public void TouchStart() {
    isSelect = true;
    _sequencer = FindObjectOfType<SceneSequencer>();
    _telop = FindObjectOfType<Text>();
  }

  public void TouchChapter1() {
    if (effectPlaying) { return; }
    _sequencer.SceneFinish("Chapter1");
  }

  public void TouchChapter2() {
    if (effectPlaying) { return; }
    _telop.text = "Chapter 2 は選択できません";
    //_sequencer.SceneFinish("Chapter2");
  }

  public void TouchChapter3() {
    if (effectPlaying) { return; }
    _telop.text = "Chapter 3 は選択できません";
    //_sequencer.SceneFinish("Chapter3");
  }
}

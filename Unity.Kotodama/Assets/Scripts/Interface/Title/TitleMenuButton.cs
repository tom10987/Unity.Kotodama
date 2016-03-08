
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenuButton : MonoBehaviour {

  static ScreenSequencer sequencer { get { return ScreenSequencer.instance; } }

  [SerializeField]
  [Range(0.1f, 10f)]
  float _speed = 1f;

  [SerializeField]
  SceneTag _tag = SceneTag.None;

  public void OnChangeScene() { sequencer.SequenceStart(ChangeScene, new Fade(_speed)); }

  void ChangeScene() { SceneManager.LoadScene(_tag.ToString()); }
}

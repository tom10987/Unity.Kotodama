
using UnityEngine;

public class GameStart : MonoBehaviour {

  [SerializeField]
  SceneTag _startScene = SceneTag.Title;

  void Start() {
    DontDestroyOnLoad(transform.root.gameObject);
    ScreenSequencer.instance.SequenceStart(GoTitle, new Fade(2f));
    Destroy(gameObject);
  }

  void GoTitle() { _startScene.ChangeScene(); }
}

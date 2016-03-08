
using UnityEngine;


public class EventState : MonoBehaviour {

  PlayerState state { get { return PlayerState.instance; } }

  private GameObject _canvasPrefab;
  private GameObject _obj;
  public GameObject _canvas = null;
  public string[,] _entry;
  public GameObject _this;

  public bool _isAlreadyNovel = false;

  void Start() {
    _canvasPrefab = Resources.Load<GameObject>("Adventure/AdventureCanvas");
    _this = gameObject;
  }

  void OnTriggerEnter() {
    state.Stop();
    if (_canvas == null && !_isAlreadyNovel) {
      /// アドベンチャーキャンバスの出現と初期化
      _canvas = Instantiate(_canvasPrefab);
      _canvas.name = "Adventure";
      var _novel = _canvas.GetComponentInChildren<NovelSystem>();
      _novel._reading = _entry;
    }
  }

  void OnTriggerExit() {
    _isAlreadyNovel = true;
  }
}

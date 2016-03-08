
using UnityEngine;
using UnityEngine.Events;
using System.Collections;


public class WindowManager : SingletonBehaviour<WindowManager> {

  GameManager game { get { return GameManager.instance; } }
  EnemyManager enemy { get { return EnemyManager.instance; } }

  [SerializeField]
  GameObject _commandWindow = null;

  [SerializeField]
  GameObject _messageWindow = null;

  /// <summary> 現在有効になっているキャンバスのプレハブ </summary>
  GameObject _currentWindow = null;
  CanvasGroup _currentGroup = null;
  bool IsActiveWindow { get { return _currentWindow != null; } }

  [SerializeField]
  [Tooltip("ウィンドウ消滅までの待機時間（単位：秒）")]
  float _defaultTime = 0.5f;
  public float waitTime { get; set; }


  /// <summary> 選択肢を表示する </summary>
  /// <param name="yes"> 「はい」ボタンを押した時の動作 </param>
  public void CreateCommandWindow(string message, UnityAction yes) {
    // TIPS: すでに有効になっているウィンドウがあれば何もしない
    if (IsActiveWindow) { return; }

    _currentWindow = Instantiate(_commandWindow);
    var window = _currentWindow.GetComponent<CommandWindow>();
    window.message.text = message;
    window.yes.onClick.AddListener(yes);
    window.no.onClick.AddListener(DestroyWindow);
    _currentGroup = window.group;

    GameManager.instance.Pause();
  }

  /// <summary> メッセージを表示する </summary>
  /// <param name="isGetItem"> true = " を手に入れました" を連結して出力 </param>
  public void CreateMessageWindow(string message, bool isGetItem = false) {
    // TIPS: すでに有効になっているウィンドウがあれば何もしない
    if (IsActiveWindow) { return; }

    _currentWindow = Instantiate(_messageWindow);
    var window = _currentWindow.GetComponent<MessageWindow>();

    var newText = isGetItem ? window.ItemMessage(message) : message;
    window.message.text = newText;
    _currentGroup = window.group;

    DestroyWindow();
  }

  /// <summary> destroyTime で指定した時間をかけてウィンドウを消去する </summary>
  public void DestroyWindow() {
    StartCoroutine(DestroyRoutine());
  }

  /// <summary> 即座にウィンドウを消去する </summary>
  public void QuickDestroyWindow() {
    Destroy(_currentWindow);
    _currentWindow = null;
    _currentGroup = null;
    waitTime = _defaultTime;
    GameManager.instance.ReStart();
  }

  IEnumerator DestroyRoutine() {
    _currentGroup.interactable = false;

    yield return new WaitForSeconds(waitTime);
    while (true) {
      _currentGroup.alpha -= Time.deltaTime * 2f;
      if (_currentGroup.alpha <= 0f) { break; }
      yield return null;
    }

    QuickDestroyWindow();
  }

  void Start() { waitTime = _defaultTime; }
}

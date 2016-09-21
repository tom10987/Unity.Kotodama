
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class WindowManager : MonoBehaviour {

  [SerializeField]
  MessageWindow _messageWindow = null;

  [SerializeField]
  CommandWindow _commandWindow = null;

  // TIPS: 有効になっているウィンドウのインスタンス
  IWindow _currentWindow = null;
  bool IsActiveWindow { get { return _currentWindow != null; } }

  /// <summary> 選択肢を表示する </summary>
  /// <param name="velocity"> ウィンドウ消滅までの遷移時間（秒） </param>
  public void CreateCommandWindow(string message,
                                  float velocity,
                                  UnityAction yes) {
    if (IsActiveWindow) { return; }

    // TIPS: 引数付きのメソッドを受け付けないので、ラムダ式でラップする
    UnityAction DestroyAction = () => { DestroyWindow(velocity); };

    var window = Instantiate(_commandWindow);
    window.message.text = message;
    window.yes.onClick.AddListener(yes + DestroyAction);
    window.no.onClick.AddListener(DestroyAction);
    _currentWindow = window;
  }

  /// <summary> メッセージを表示する </summary>
  public void CreateMessageWindow(string message,
                                  float velocity) {
    if (IsActiveWindow) { return; }

    _currentWindow = Instantiate(_messageWindow);
    _currentWindow.message.text = message;
    DestroyWindow(velocity);
  }

  /// <summary> 指定した時間（秒）をかけてウィンドウを消去する </summary>
  public void DestroyWindow(float velocity) {
    StartCoroutine(DestroyRoutine(velocity));
  }

  /// <summary> ウィンドウの状態を解放する </summary>
  public void Clear() {
    Destroy(_currentWindow.instance);
    _currentWindow = null;
    GameManager.instance.ReStart();
  }

  IEnumerator DestroyRoutine(float velocity) {
    _currentWindow.group.interactable = false;

    yield return new WaitForSeconds(velocity);
    while (_currentWindow.group.alpha > 0f) {
      _currentWindow.group.alpha -= Time.deltaTime * 2f;
      yield return null;
    }

    Clear();
  }
}

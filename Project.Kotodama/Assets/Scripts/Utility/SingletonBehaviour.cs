
using UnityEngine;


//------------------------------------------------------------
// TIPS:
// 継承させたクラスは、あらかじめシーンに登録したうえで
// base.Awake() を呼び出すか、派生クラスの内部で
// 自身の static インスタンスを初期化するようにすること

public abstract class SingletonBehaviour<T> :
  MonoBehaviour where T : SingletonBehaviour<T> {

  static T _instance = null;
  static public T instance { get { return _instance; } }

  virtual protected void Awake() {
    if (ExistsInstance()) { return; }
    Debug.LogWarning("Exists other " + typeof(T));
    Debug.Log("removed " + gameObject.name);
  }

  protected bool ExistsInstance() {
    if (_instance == null) { _instance = this as T; }
    if (_instance == this) { return true; }
    Destroy(gameObject);
    return false;
  }
}

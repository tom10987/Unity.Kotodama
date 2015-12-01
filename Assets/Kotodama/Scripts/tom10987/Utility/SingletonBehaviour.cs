
using UnityEngine;


public abstract class SingletonBehaviour<T> :
  MonoBehaviour where T : SingletonBehaviour<T> {

  static T _instance = null;
  static public T instance {
    get {
      if (_instance == null) { _instance = FindObjectOfType(typeof(T)) as T; }
      return _instance;
    }
  }

  virtual protected void Awake() {
    if (!ExistsInstance()) { Debug.LogWarning(typeof(T) + " is nothing."); }
  }

  protected bool ExistsInstance() {
    if (_instance == null) { _instance = this as T; }
    if (_instance == this) { return true; }

    Destroy(gameObject);
    return false;
  }
}

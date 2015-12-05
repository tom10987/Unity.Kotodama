
using UnityEngine;


public abstract class SingletonBehaviour<T> :
  MonoBehaviour where T : SingletonBehaviour<T> {

  static T _instance = null;
  static public T instance {
    get {
      if (_instance == null) {
        var find = FindObjectOfType(typeof(T));
        if (find != null) {
          _instance = find as T;
        }
        else {
          var newObject = new GameObject().AddComponent<T>();
          _instance = newObject;
        }
      }
      return _instance;
    }
  }


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

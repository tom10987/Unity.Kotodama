
using UnityEngine;
using UnityEngine.UI;

public interface IWindow {
  Text message { get; }
  CanvasGroup group { get; }

  T GetComponent<T>();
  GameObject instance { get; }
}


using UnityEngine;
using System.Collections;

public abstract class PlayerComponent : MonoBehaviour {
  public void Activate() { StartCoroutine(UpdateComponent()); }
  protected abstract IEnumerator UpdateComponent();
}

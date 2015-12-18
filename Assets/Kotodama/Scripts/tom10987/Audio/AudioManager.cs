
using UnityEngine;


public class AudioManager : SingletonBehaviour<AudioManager> {

  [SerializeField]
  AudioPlayer _bgm = null;
  public AudioPlayer bgm { get { return _bgm; } }

  [SerializeField]
  AudioPlayer _field = null;
  public AudioPlayer field { get { return _field; } }

  [SerializeField]
  AudioPlayer _effect = null;
  public AudioPlayer effect { get { return _effect; } }


  protected override void Awake() {
    base.Awake();
    DontDestroyOnLoad(gameObject);
  }
}

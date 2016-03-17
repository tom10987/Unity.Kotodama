
using UnityEngine;

public class AudioManager : SingletonBehaviour<AudioManager> {

  [SerializeField]
  AudioPlayer _bgm = null;
  public AudioPlayer bgm { get { return _bgm; } }

  [SerializeField]
  AudioPlayer _effect = null;
  public AudioPlayer effect { get { return _effect; } }
}

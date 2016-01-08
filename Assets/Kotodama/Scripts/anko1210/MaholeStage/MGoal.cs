using UnityEngine;

public class MGoal : MonoBehaviour {

    SceneSequencer sequencer { get { return SceneSequencer.instance; } }
    PlayerStatus state { get { return PlayerStatus.instance; } }
    PopUpCanvas pop { get { return PopUpCanvas.instance; } }

    void OnCollisionEnter()
    {
        state.MoveStop();
        pop.CreatePopUpWindowVerGimmick("神社へ戻りますか？", IsEnd);
    }

    public void IsEnd()
    {
        pop._isChoice = true;
        sequencer.SceneFinish(SceneTag.shrine);
    }


}

using UnityEngine;
using System.Collections;

public class EventChecker : MonoBehaviour
{
    [SerializeField]
    bool Alive = false;

    void LateUpdate ()
    {
        EventContinue();
	}

    public void EventContinue()
    {
        if(!DialButton_Ver2.ClearFlug_PublicPhone) return;
        Stop();
    }

    public bool SetAlive()
    {
        return Alive;
        
    }

    public void Stop()
    {
        this.gameObject.SetActive(SetAlive());
    }

}

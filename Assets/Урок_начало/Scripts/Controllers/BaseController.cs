using UnityEngine;

public class BaseController : MonoBehaviour
{
    public bool IsEnabled { get; private set; }

    public virtual void On() { IsEnabled = true; }
    public virtual void Off() { IsEnabled = false; }
}
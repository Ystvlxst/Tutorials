using UnityEngine;

public abstract class Rewindable : MonoBehaviour
{
    public abstract void Record();

    public abstract void Rewind();
}

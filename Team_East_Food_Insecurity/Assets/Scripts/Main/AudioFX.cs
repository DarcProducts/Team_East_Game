using UnityEngine;
public class AudioFX : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;
    [SerializeField] Vector2 minMaxVolume;
    [SerializeField] Vector2 minMaxPitch;

    [ContextMenu("Play Audio FX")]
    public void PlayFX() => Utils.PlayAtSourceVolumePitchRange(source, clip, minMaxVolume.x, minMaxVolume.y, minMaxPitch.x, minMaxPitch.y);
}

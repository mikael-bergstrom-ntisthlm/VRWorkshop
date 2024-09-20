using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunController : MonoBehaviour
{
  [SerializeField]
  Transform bulletSpawnPoint;

  [SerializeField]
  GameObject bulletPrefab;

  XRGrabInteractable interactable;

  void Start()
  {
    interactable = GetComponent<XRGrabInteractable>();
    interactable.activated.AddListener(TriggerPress);
    interactable.deactivated.AddListener(TriggerRelease);
  }

  void TriggerPress(ActivateEventArgs args)
  {
    Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    SendMessage("OnTriggerPress", null, SendMessageOptions.DontRequireReceiver);
  }

  void TriggerRelease(DeactivateEventArgs args)
  {
    SendMessage("OnTriggerRelease", null, SendMessageOptions.DontRequireReceiver);
  }
}

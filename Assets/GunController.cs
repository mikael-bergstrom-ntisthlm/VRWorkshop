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
    interactable.activated.AddListener(OnTriggerPress);
    interactable.deactivated.AddListener(OnTriggerRelease);
  }

  void OnTriggerPress(ActivateEventArgs args)
  {
    Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
  }

  void OnTriggerRelease(DeactivateEventArgs args)
  {
    
  }
}

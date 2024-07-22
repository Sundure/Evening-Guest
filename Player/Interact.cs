using System;
using UnityEngine;
public class Interact : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    public static event Action ExcludeInteract;
    public static event Action IncludeInteract;

    private void Update()
    {
        Ray ray = _camera.ViewportPointToRay(new Vector2(0.5f, 0.5f));
        if (Physics.Raycast(ray, out RaycastHit rayHit, 1.5f))
        {
            if (rayHit.collider.gameObject.layer == LayerMask.NameToLayer("Interacted"))
            {
                IncludeInteract?.Invoke();
                if (Input.GetKeyDown(KeyCode.E) && Pause.IsPause == false)
                {
                    switch (rayHit.collider.gameObject.tag)
                    {
                        case "Door":
                            rayHit.collider.gameObject.GetComponent<Door>().OnDoorOpen();
                            break;
                        case "Light Switch":
                            rayHit.collider.gameObject.GetComponent<LightSwitch>().Switch();
                            break;
                        case "House Door":
                            rayHit.collider.gameObject.GetComponent<HouseDoor>().Door();
                            break;
                        case "Fridge":
                            rayHit.collider.gameObject.GetComponent<Fridge>().OnFridgeUse();
                            return;
                        case "Chair":
                            rayHit.collider.gameObject.GetComponent<Chair>().OnChairUse();
                            break;
                        case "Cake":
                            rayHit.collider.gameObject.GetComponent<EatingCake>().Eating();
                            break;
                        case "Washing Machine":
                            rayHit.collider.gameObject.GetComponent<WashingMachine>().Wash();
                            break;
                        case "Sofa":
                            rayHit.collider.gameObject.GetComponent<Sofa>().OnSofaUse();
                            break;
                        case "Radio":
                            rayHit.collider.gameObject.GetComponent<Radio>().RadioSwitch();
                            break;
                        case "Bed":
                            rayHit.collider.gameObject.GetComponent<Bed>().BedUse();
                            break;
                        case "Final Radio":
                            rayHit.collider.gameObject.GetComponent<DisableFinalRadio>().RadioOff();
                            break;

                    }
                }
            }
            else
            {
                ExcludeInteract?.Invoke();
            }
        }
        else
        {
            ExcludeInteract?.Invoke();
        }
    }
}

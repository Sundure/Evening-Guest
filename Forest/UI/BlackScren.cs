using UnityEngine;

public class BlackScreen : MonoBehaviour
{
    [SerializeField] private Animator _blackScreenAnim;
    private void Start()
    {
        BlackScreenDeactivate();

        Door.BlackScreenActivate += BlackScreenActivate;

        Bed.OnBedUse += ChoseEffect;

        TaskManager.BlackScreen += BlackScreenActivate;

        FinalQuest.BlackScreen += BlackScreenActivate;
    }
    private void ChoseEffect(bool effect)
    {
        if (effect == true)
        {
            BlackScreenActivate();
        }
        else
        {
            BlackScreenDeactivate();
        }
    }

    private void BlackScreenActivate()
    {
        _blackScreenAnim.SetBool("Black Screen Activate", true);

        _blackScreenAnim.SetBool("Black Screen Deactivate", false);
    }

    private void BlackScreenDeactivate()
    {
        _blackScreenAnim.SetBool("Black Screen Deactivate", true);

        _blackScreenAnim.SetBool("Black Screen Activate", false);
    }   
    private void OnDestroy()
    {
        Door.BlackScreenActivate -= BlackScreenActivate;
        TaskManager.BlackScreen -= BlackScreenActivate;
        Bed.OnBedUse -= ChoseEffect;
        FinalQuest.BlackScreen -= BlackScreenActivate;
    }
}

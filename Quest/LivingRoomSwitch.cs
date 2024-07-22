using UnityEngine;

public class LivingRoomSwitch : MonoBehaviour
{
    private float _time;
    private float _psychoTime;

    private bool _canAddTime;

    [SerializeField] private Psycho _psycho;

    [SerializeField] private GameObject _room;
    [SerializeField] private GameObject _ruinedRoom;
    private void Start()
    {
        TurnOffWashingMachineTrigger.PsychoTrigger += Enabled;
        Psycho.PsychoDestroy += Destroy;

        enabled = false;
    }

    private void Enabled()
    {
        TurnOffWashingMachineTrigger.PsychoTrigger -= Enabled;

        enabled = true;
    }

    private void Update()
    {
        _time -= Time.deltaTime;

        if (_time <= 0)
        {
            if (_canAddTime == true)
            {
                _psychoTime = _psycho.Scale * 3;

                _canAddTime = false;

                _room.SetActive(false);
                _ruinedRoom.SetActive(true);
            }

            _psychoTime -= Time.deltaTime;

            if (_psychoTime <= 0)
            {
                _ruinedRoom.SetActive(false);
                _room.SetActive(true);

                _canAddTime = true;

                _time = Random.Range(1, 3);
            }
        }
    }

    private void Destroy()
    {
        _ruinedRoom.SetActive(false);
        _room.SetActive(true);

        Destroy(this);
    }

    private void OnDestroy()
    {
        TurnOffWashingMachineTrigger.PsychoTrigger -= Enabled;
        Psycho.PsychoDestroy -= Destroy;
    }
}

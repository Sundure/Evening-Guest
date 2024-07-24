using System;
using UnityEngine;

public class CompletedTasksList : MonoBehaviour
{
    [SerializeField] private TaskList _taskList;

    public static event Action ActivateFridge;
    public static event Action ActivateChair;
    public static event Action ActivateWashMashine;
    public static event Action ActivateSofa;
    public static event Action ActivateForestTriger;
    public static event Action ActivateBed;
    public static event Action ChangeScene;

    private void Start()
    {
        Flashlight.OnEnable += FlashlightTask;
    }
    private void FlashlightTask()
    {
        _taskList.ChangeTask();

        Flashlight.OnEnable -= FlashlightTask;

        ActivateFridge?.Invoke();

        Fridge.FridgeQuest += FoodTask;
    }

    private void FoodTask()
    {
        _taskList.ChangeTask();

        Fridge.FridgeQuest -= FoodTask;

        ActivateChair?.Invoke();

        Chair.OnChairSeat += SeatTask;
    }

    private void SeatTask()
    {
        _taskList.ChangeTask();

        Chair.OnChairSeat -= SeatTask;

        EatingCake.OnCakeDestroy += EatTask;
    }

    private void EatTask()
    {
        _taskList.ChangeTask();

        EatingCake.OnCakeDestroy -= EatTask;

        WashingMachine.OnWash += WashTask;

        ActivateWashMashine?.Invoke();
    }

    private void WashTask()
    {
        _taskList.ChangeTask();

        WashingMachine.OnWash -= WashTask;

        Sofa.DoorQuestActivate += TVTask;

        ActivateSofa?.Invoke();
    }

    private void TVTask()
    {
        _taskList.ChangeTask();

        Sofa.DoorQuestActivate -= TVTask;

        DoorQuest.OnForestEnter += TurnOffRadioQuest;

        ActivateForestTriger?.Invoke();
    }

    private void TurnOffRadioQuest()
    {
        _taskList.CroroutineChangeTask(2f);

        DoorQuest.OnForestEnter -= TurnOffRadioQuest;

        Radio.OnRadioSwitchOff += SleepTask;
    }

    private void SleepTask()
    {
        _taskList.ChangeTask();

        Radio.OnRadioSwitchOff -= SleepTask;

        Bed.OnSleep += TurnOffWashingMachine;

        ActivateBed?.Invoke();
    }

    private void TurnOffWashingMachine()
    {
        _taskList.CroroutineChangeTask(1f);

        Bed.OnSleep -= TurnOffWashingMachine;

        BathroomSwitch.OnBathroomChange += TurnOffRadioHorror;
    }

    private void TurnOffRadioHorror()
    {
        _taskList.ChangeTask();

        BathroomSwitch.OnBathroomChange -= TurnOffRadioHorror;

        DisableFinalRadio.OnFinalRadioUse += FinalQuest;
    }

    private void FinalQuest()
    {
        _taskList.ChangeTask();

        DisableFinalRadio.OnFinalRadioUse -= FinalQuest;

        ChangeScene?.Invoke();
    }


    private void OnDestroy()
    {
        Flashlight.OnEnable -= FlashlightTask;
        Fridge.FridgeQuest -= FoodTask;
        Chair.OnChairSeat -= SeatTask;
        EatingCake.OnCakeDestroy -= EatTask;
        WashingMachine.OnWash -= WashTask;
        Sofa.DoorQuestActivate -= TVTask;
        DoorQuest.OnForestEnter -= TurnOffRadioQuest;
        Radio.OnRadioSwitchOff -= SleepTask;
        Bed.OnSleep -= TurnOffWashingMachine;
        BathroomSwitch.OnBathroomChange -= TurnOffRadioHorror;
        DisableFinalRadio.OnFinalRadioUse -= FinalQuest;
    }
}

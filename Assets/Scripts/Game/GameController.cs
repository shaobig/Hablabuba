using UnityEngine;

public class GameController : MonoBehaviour, ListenerSubscriber, ListenerUnsubscriber, OnGameFinishedListener
{
    private const float TIMESCALE_FINISH_GAME = 0;

    [SerializeField]
    private PlayerGameController playerGameController;
    [SerializeField]
    private float timeScale = 1;

    void Awake()
    {
        SubscribeListener();
    }

    void Start()
    {
        GoToNextStep();
    }

    void Update()
    {
        Time.timeScale = timeScale;
    }

    void OnDestroy()
    {
        UnsubscribeListener();
    }

    public void OnGameFinished()
    {
        Debug.Log("Game over");
        Time.timeScale = TIMESCALE_FINISH_GAME;
    }

    public void SubscribeListener()
    {
        playerGameController.OnGameFinishedListener = this;
    }

    public void UnsubscribeListener()
    {
        playerGameController.OnGameFinishedListener = null;
    }

    void GoToNextStep()
    {
        playerGameController.GoToNextStep();
    }

}

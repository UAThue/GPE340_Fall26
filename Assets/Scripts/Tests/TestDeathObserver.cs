using UnityEngine;
using UnityEngine.InputSystem;

public class TestDeathObserver : MonoBehaviour
{
    public Pawn playerPawnToTest;
    public Controller playerControllerToTest;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerToTest.Possess(playerPawnToTest);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current[Key.P].wasPressedThisFrame)
        {
            playerPawnToTest.GetComponent<Health>().TakeDamage(10);
        }
    }
}

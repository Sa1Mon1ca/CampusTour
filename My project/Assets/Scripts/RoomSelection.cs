using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class RoomSelection : MonoBehaviour
{
    public Dropdown dropdown;
    public Transform[] roomTargets;
    public PathFinder AIPathFinder;
    public CameraController cameraController;

    private List<string> roomCodes = new List<string>
    {
        "2Q048", "2Q049", "2Q050", "2Q047", "2Q052"
    };
    // Start is called before the first frame update
    void Start()
    {
        OpenDropdown();
    }

    void OpenDropdown()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(roomCodes);
    }
    public void SetDestination()
    {
        if (AIPathFinder != null && roomTargets.Length > 0)
        {
            int selectedRoom = dropdown.value;
            string selectedRoomCode = roomCodes[selectedRoom];

            Debug.Log($"Setting destination for room: {selectedRoomCode}");

            AIPathFinder.SetNewDestination(roomTargets[selectedRoom].position, selectedRoomCode);

            cameraController.LockCursor();
        }
        else
        {
            Debug.LogError("SetDestination: AIPathFinder or roomTargets is null/empty!");
        }
    }
}

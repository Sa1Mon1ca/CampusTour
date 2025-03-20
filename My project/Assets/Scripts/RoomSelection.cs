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
        "2Q048", "2Q049", "2Q050", "2Q047", "2Q052", "2Q046", "2Q043", "2Q042", "2Q041","2Q044A","2Q044B","2Q054","2Q053","2Q012","2Q028","2Q045","2Q035","2Q034","2Q033","2Q056","2Q056A","2Q056B","2Q056C","2Q032","2Q055", "2Q002","2Q001A","2Q008","2Q030","2Q006A","2Q029",
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

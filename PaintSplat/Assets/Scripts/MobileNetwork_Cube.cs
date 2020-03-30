using UnityEngine;

public class MobileNetwork_Cube : Photon.PunBehaviour
{
    // TODO-1.b: write any functions needed to establish connection
    //   and join a room. Joining a random room will do for now if you are testing
    //   it yourself. But you can also list the rooms or require player to enter
    //   the room name in case there are more people playing
    //   your game - though it is not required for the assignment.
    private string roomName;
    private GyroController gyroController;

    private void Start()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");
		roomName = "testing";
        Screen.orientation = ScreenOrientation.Portrait;
        gyroController = GetComponent<GyroController>();
    }

    private void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

	public override void OnJoinedLobby()
	{
		 //PhotonNetwork.JoinRoom(roomName);
        PhotonNetwork.JoinRandomRoom();
        base.OnJoinedLobby ();
	}

    public override void OnJoinedRoom()
    {
        GameObject phoneCube = PhotonNetwork.Instantiate("PhoneCube", new Vector3(0, 0, 0), Quaternion.identity, 0);
        gyroController.ControlledObject = phoneCube;
        base.OnJoinedRoom ();
	}
}
using UnityEngine;

public class MobileNetwork : Photon.PunBehaviour
{
    private string roomName;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings("0.1");
        roomName = "testing";
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    public override void OnJoinedLobby()
    {
        //PhotonNetwork.JoinRoom(roomName);
        PhotonNetwork.JoinRandomRoom();
        base.OnJoinedLobby();
    }

    // TODO-2.a: 
    // Copy and paste the Start() and OnJoinedLobby() methods from MobileNetwork_Cube.cs

    public override void OnJoinedRoom()
	{
		GetComponent<MobileShooter>().Activate();
		base.OnJoinedRoom ();
    }


}

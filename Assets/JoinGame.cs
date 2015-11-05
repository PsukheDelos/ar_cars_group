using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace UnityStandardAssets.CrossPlatformInput{

	public class JoinGame : Photon.MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

//		int roomNo = 0;
		private bool join = true;
		private float timer = 0.0f;
		public GUISkin Skin;


		/// <summary>Connect automatically? If false you can set this to true later on or call ConnectUsingSettings in your own scripts.</summary>
		public bool AutoConnect = true;
		
		public byte Version = 1;
		
		/// <summary>if we don't want to connect in Start(), we have to "remember" if we called ConnectUsingSettings()</summary>
		private bool ConnectInUpdate = true;

		public Dropdown lobbies;
		public Dropdown levels;
		// Use this for initialization
		void Start () {
			PhotonNetwork.autoJoinLobby = true;
		}
		
		// Update is called once per frame
		void Update () {
			if (PhotonNetwork.connected) {
				timer += Time.deltaTime;
				if (timer >= 1.0f) {
					Dropdown.OptionData od = new Dropdown.OptionData ();
					od.text = "[NEW GAME]";
					lobbies.options.Clear ();
					lobbies.options.Add (od);
					foreach (RoomInfo i in PhotonNetwork.GetRoomList()) {
						od = new Dropdown.OptionData ();
						od.text = i.name;
						lobbies.options.Add (od);
						Debug.Log ("RoomInfo: " + i.name);
					}
					Debug.Log ("Room Count: " + PhotonNetwork.countOfRooms);
					timer = 0;
				}
			}

			if (ConnectInUpdate && AutoConnect && !PhotonNetwork.connected)
			{
				Debug.Log("Update() was called by Unity. Scene is loaded. Let's connect to the Photon Master Server. Calling: PhotonNetwork.ConnectUsingSettings();");
				Debug.Log (Version + "."+Application.loadedLevel);
				ConnectInUpdate = false;
				PhotonNetwork.ConnectUsingSettings(Version + "."+Application.loadedLevel);
			}
		}

		
		public void OnPointerDown(PointerEventData data)
		{
			if (PhotonNetwork.connected) {
				join = true;
				List<string> roomNames = new List<string> ();
				roomNames.Add ("BONE SAW");
				roomNames.Add ("PAIN TRAIN");
				roomNames.Add ("DEAD END");
				roomNames.Add ("OCCAM'S RAZOR");
	
				if (lobbies.value == 0) {
					foreach (RoomInfo i in PhotonNetwork.GetRoomList()) {
						roomNames.Remove (i.name);
					}
					String room = roomNames.ToArray ().GetValue (UnityEngine.Random.Range (0, roomNames.Count - 1)).ToString ();
					join = PhotonNetwork.CreateRoom (room, new RoomOptions () { maxPlayers = 2 }, null);
					if (levels.value == 0) {
						PhotonNetwork.player.SetTeam (PunTeams.Team.red);
					} else if (levels.value == 1) {
						PhotonNetwork.player.SetTeam (PunTeams.Team.blue);
					} else {
						PhotonNetwork.player.SetTeam (PunTeams.Team.none);
					}
//					Debug.Log ("Level: " + levels.options [levels.value].text.ToString());
					Debug.Log ("Create Room: " + room);
				} else {
					join = PhotonNetwork.JoinRoom (lobbies.options [lobbies.value].text);
//					PhotonNetwork.otherPlayers
//					PhotonNetwork.player.SetTeam(PhotonNetwork.otherPlayers[0].GetTeam());
					Debug.Log ("Join Room");
				}

				GameObject.Find ("JoinCanvas").gameObject.GetComponent<Canvas> ().enabled = false;
				GameObject.Find ("ButtonCanvas").gameObject.GetComponent<Canvas> ().enabled = true;
			}
		}
		
		
		public void OnPointerUp(PointerEventData data)
		{

		}

		// to react to events "connected" and (expected) error "failed to join random room", we implement some methods. PhotonNetworkingMessage lists all available methods!
		
		public virtual void OnConnectedToMaster()
		{
			if (PhotonNetwork.networkingPeer.AvailableRegions != null) Debug.LogWarning("List of available regions counts " + PhotonNetwork.networkingPeer.AvailableRegions.Count + ". First: " + PhotonNetwork.networkingPeer.AvailableRegions[0] + " \t Current Region: " + PhotonNetwork.networkingPeer.CloudRegion);
			Debug.Log("OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room. Calling: PhotonNetwork.JoinRandomRoom();");
//			PhotonNetwork.JoinOrCreateRoom("ar_room", new RoomOptions() { maxPlayers = 2 }, null);
			//        PhotonNetwork.JoinRandomRoom();
		}
		
		public virtual void OnPhotonRandomJoinFailed()
		{
			Debug.Log("OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one. Calling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
			//        PhotonNetwork.CreateRoom(null, new RoomOptions() { maxPlayers = 4 }, null);
//			PhotonNetwork.CreateRoom("ar_room", new RoomOptions() { maxPlayers = 2 }, null);
			
		}
		
		// the following methods are implemented to give you some context. re-implement them as needed.
		
		public virtual void OnFailedToConnectToPhoton(DisconnectCause cause)
		{
			Debug.LogError("Cause: " + cause);
		}

		public void OnJoinedRoom()
		{
//			GameObject.Find("Arena").GetComponent<Scrip
//			if (PhotonNetwork.isMasterClient) {
//			PhotonNetwork.player.

//			PhotonNetwork.player.SetTeam(PhotonNetwork.otherPlayers[0].GetTeam());

//			PhotonNetwork.set
//				ExitGames.Client.Photon.Hashtable hm = new ExitGames.Client.Photon.Hashtable ();
//				hm.Add ("level", levels.options [levels.value].text.ToString());
//				PhotonNetwork.SetPlayerCustomProperties (hm);
////				GameObject.FindGameObjectsWithTag("Arena");
//			}
			Debug.Log("OnJoinedRoom() called by PUN. Now this client is in a room. From here on, your game would be running. For reference, all callbacks are listed in enum: PhotonNetworkingMessage");
		}
		
		public void OnJoinedLobby()
		{
			Debug.Log("OnJoinedLobby(). Use a GUI to show existing rooms available in PhotonNetwork.GetRoomList().");
		}


		void OnGUI()
		{
			if( Skin != null )
			{
				GUI.skin = Skin;
			}
			
			float width = 400;
			float height = 100;
			if (join) {
//				Rect centeredRect = new Rect ((Screen.width - width) / 2, (Screen.height - height) / 2, width, height);
				Rect centeredRect = new Rect (0, 0, width, height);

				GUILayout.BeginArea (centeredRect, GUI.skin.box);
				{
					GUILayout.Label ("Connecting" + GetConnectingDots (), GUI.skin.customStyles [0]);
					GUILayout.Label ("Status: " + PhotonNetwork.connectionStateDetailed);
				}
				GUILayout.EndArea ();
			}
			if( PhotonNetwork.connectionStateDetailed == PeerState.Joined )
			{
				enabled = false;
			}
		}

		string GetConnectingDots()
		{
			string str = "";
			int numberOfDots = Mathf.FloorToInt( Time.timeSinceLevelLoad * 3f % 4 );
			
			for( int i = 0; i < numberOfDots; ++i )
			{
				str += " .";
			}
			
			return str;
		}
	}
}
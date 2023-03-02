using Newtonsoft.Json;
using SocketIOClient;
using SocketIOClient.Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SocketClient : MonoBehaviour
{
    public string URI = "http://127.0.0.1:3000";
    public SocketIOUnity socket;


    public Action<NoteObject> OnNewNoteFromMaker;

    public Action<List<float>> OnReceivedTimings;

    public Action OnPlayingRoundStart;


    // Start is called before the first frame update
    void Start()
    {
         InitializeSocket();

        
    }

    void InitializeSocket()
    {
        var uri = new Uri(URI); ;
        socket = new SocketIOUnity(uri, new SocketIOOptions
        {
            Query = new Dictionary<string, string>
                {
                    {"token", "UNITY" }
                }
            ,
            EIO = 4
            ,
            Transport = SocketIOClient.Transport.TransportProtocol.WebSocket
        });
        socket.JsonSerializer = new NewtonsoftJsonSerializer();

        ///// reserved socketio events
        socket.OnConnected += (sender, e) =>
        {
            print("socket.OnConnected");
        };

        socket.OnDisconnected += (sender, e) =>
        {
            print("disconnected");
        };
        socket.Connect();


        socket.OnUnityThread(nameof(SocketGameEvents.NewNote), (e) =>
        {

          NoteObject noteData = NoteObject.ParseFromJsonString(e.GetValue<string>());

            
            OnNewNoteFromMaker?.Invoke(noteData);
        });


        socket.OnUnityThread(nameof(SocketGameEvents.Timings), (timings) =>
        {

            //something
            List<float> times = timings.GetValue<List<float>>();
        
            OnReceivedTimings?.Invoke(times);
        });

        socket.OnUnityThread(nameof(SocketGameEvents.PlayingStart), (e) =>
        {
            print("received round start event");
            OnPlayingRoundStart?.Invoke();
        });

    }


    private void OnDisable()
    {
        socket.Disconnect();
        socket.Dispose();
    }


    public async void JoinRoomAsMaker(string room)
    {

       await socket.EmitAsync(nameof(SocketGameEvents.StartAsMaker), room);

        SceneManager.LoadScene(1);
    }

    public async void JoinRoomAsPlayer(string room)
    {
        await socket.EmitAsync(nameof(SocketGameEvents.StartAsPlayer), room);
        SceneManager.LoadScene(2);

    }



    public async void GetTimingRequest(string songName)
    {
        await socket.EmitAsync("GetTimings", songName);
        print("trying getting time");

    }


    public async void SendNoteDataToServer(float posX, float posY, int noteNumber)
    {
        print("sending new note : " + noteNumber);

        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("posX",posX.ToString());
        data.Add("posY",posY.ToString());
        data.Add("noteNumber",noteNumber.ToString());

    



       await socket.EmitStringAsJSONAsync(nameof(SocketGameEvents.NewNote),JsonConvert.SerializeObject(data));
            
    }




    enum SocketGameEvents
    {
        StartAsPlayer,
        StartAsMaker,
        NewNote,
        Timings,
        PlayingStart
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}

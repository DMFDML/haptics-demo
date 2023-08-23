using UnityEngine;
using System;
using System.Net.Sockets;
using System.Threading;

public class ReadSocket : MonoBehaviour
{
    private const string serverIP = "127.0.0.1"; // Use localhost IP
    private const int serverPort = 12345;       // Use the same port as the server

    private TcpClient client;
    private NetworkStream stream;
    private byte[] dataBuffer = new byte[1];

    private Button1Controller button1Controller; // Reference to the Button1Controller script

    private void Start()
    {
        ConnectToServer();
        button1Controller = GameObject.Find("Chuck").GetComponent<Button1Controller>();
    }

    private void ConnectToServer()
    {
        try
        {
            client = new TcpClient(serverIP, serverPort);
            stream = client.GetStream();
            Debug.Log("Connected to server");

            Thread receiveThread = new Thread(ReceiveData);
            receiveThread.Start();
        }
        catch (Exception e)
        {
            Debug.LogError($"Socket error: {e}");
        }
    }

    private void ReceiveData()
    {
        try
        {
            while (true)
            {
                int bytesRead = stream.Read(dataBuffer, 0, dataBuffer.Length);
                if (bytesRead > 0)
                {
                    int receivedValue = dataBuffer[0]; // Convert byte to int
                    button1Controller.SetButtonState(receivedValue == 1);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Receive error: {e}");
        }
    }

    private void OnDestroy()
    {
        stream?.Close();
        client?.Close();
    }
}

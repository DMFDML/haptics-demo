using UnityEngine; // Access Unity API
using System; // Fundamental .NET API
using System.Net.Sockets; // Access .NET socket API
using System.Threading; // Access .NET threading API

// This script reads data from a bluetooth TCP socket and prints it to the
// console

public class ReadSocket : MonoBehaviour // Inherit from MonoBehaviour
{
    private const string serverIP = "127.0.0.1"; // Use localhost IP
    private const int serverPort = 12345;       // Use the same port as the ...
    // server

    private TcpClient client; // TCP client object
    private NetworkStream stream; // Network stream object
    private byte[] dataBuffer = new byte[1]; // Buffer to store received data

    private Button1Controller button1Controller; // Reference to the ...
    // Button1Controller script

    // Start is called before the first frame update
    private void Start()
    {
        ConnectToServer(); // Connect to the server
        button1Controller = 
            GameObject.Find("Chuck").GetComponent<Button1Controller>();
        // Get a reference to the Button1Controller script
    }

    // Connect to the server
    private void ConnectToServer()
    {
        try // Try to connect to the server
        {
            client = new TcpClient(serverIP, serverPort); // Create a TCP ...
            // client object
            stream = client.GetStream(); // Get the network stream object
            Debug.Log("Connected to server"); // Log a message

            Thread receiveThread = new Thread(ReceiveData); // Create a ...
            // thread to receive data
            receiveThread.Start(); // Start the thread
        }
        catch (Exception e) // Catch any exceptions
        {
            Debug.LogError($"Socket error: {e}"); // Log the exception
        }
    }

    // Receive data from the server
    private void ReceiveData()
    {
        try // Try to receive data
        {
            while (true) // Loop forever
            {
                // Read data from the network stream
                int bytesRead = stream.Read(dataBuffer, 0, dataBuffer.Length);
                if (bytesRead > 0) // If data was received
                {
                    int receivedValue = dataBuffer[0]; // Convert byte to int
                    // Log the received value
                    button1Controller.SetButtonState(receivedValue == 1);
                }
            }
        }
        catch (Exception e) // Catch any exceptions
        {
            Debug.LogError($"Receive error: {e}"); // Log the exception
        }
    }

    private void OnDestroy() // Called when the game object is destroyed
    {
        stream?.Close(); // Close the network stream
        client?.Close(); // Close the TCP client
    }
}

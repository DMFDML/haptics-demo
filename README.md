# Touch Sensor Unity Integration

This repository contains a Unity integration with a touch sensor through a Python socket. The project demonstrates how to read input from a touch sensor connected to a microcontroller via Bluetooth and visualise the input in a Unity scene.

## Python Socket

The `Python Socket` directory includes the following files:

- `RunESP32.ink`: A shortcut file that allows you to specify COM port and baud rate arguments for running the `TouchSensorSocket.exe` executable.
- `TouchSensorSocket.exe`: An executable compiled from `TouchSensorSocket.py` script.
- `TouchSensorSocket.py`: Python script that creates a socket server to read touch sensor input and send it to the Unity application.
- `TouchSensorSocket_COM5_9600.py`: As above, however sets default values for COM port (COM5) and baud rate (9600).

### Finding the Bluetooth COM Port (Windows)

1. In your system settings, navigate to Bluetooth settings.
2. Find "More Bluetooth options" or similar settings.
3. Look for the "COM Ports" tab to find the COM port assigned to the ESP32.

### Usage

1. Edit the `RunESP32.ink` shortcut target by right-clicking and selecting Properties. Modify the suffix arguments in the target box to specify the COM port and baud rate.
2. Run the `RunESP32.ink` shortcut. A terminal will open with the message "Waiting for Unity to connect...".
3. Start your Unity application.

The terminal will show the button input stream from the microcontroller Bluetooth serial. When the Unity application connects, it will receive the input and visualise it in the scene.

## Unity

The `Unity` directory contains a Unity project with the following scripts:

### `ReadSocket.cs`

A C# script that establishes a connection with the Python socket and reads touch sensor input. It communicates with the `Button1Controller` script to visualise the input.

### `Button1Controller.cs`

A C# script that controls the behavior of a drill chuck in the Unity scene. It changes the material color when the touch sensor button is pressed. This could easily be applied to other objects or replaced with other behaviours.

## Getting Started

1. Open the Unity project.
2. Set up your microcontroller and touch sensor according to your hardware setup (see [touch-sensor](https://github.com/DMFDML/touch-sensor))
3. Run the `RunESP32.ink` shortcut to launch the Python socket script.
4. Play the Unity scene to visualise the touch sensor input.

## Notes

- Make sure Unity is running using .NET Framework.
- The port used for the socket communication is 12345 (using the local loopback IP address). This port can be changed.
- Multiple ports can be used to stream input from multiple buttons.
- When the Unity demo is stopped, the Python socket should stop as well. It's recommended to open the Python socket first and then launch the Unity application.

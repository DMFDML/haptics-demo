import serial # Import pyserial library

def read_serial_func(port, baud_rate): # Function to read serial data
    ser = serial.Serial(port, baud_rate) # Create serial object (ser)
    try: # Try to read serial data
        while True: # Infinite loop
            data = ser.readline().decode().strip() # Read serial data
            yield data # Generator function, new value each time it is called
    except KeyboardInterrupt: # If keyboard interrupt (Ctrl+C)
        ser.close() # Close serial connection

# Test code for when this file is run directly
if __name__ == "__main__":
    COM_PORT = 'COM5' # COM port for serial communication (see github readme)
    BAUD_RATE = 9600 # Baud rate for serial communication (see github readme)

    # Print serial data to console
    for data in read_serial_func(COM_PORT, BAUD_RATE):
        print(data)
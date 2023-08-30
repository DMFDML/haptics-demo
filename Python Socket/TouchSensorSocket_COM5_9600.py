import threading # For threading
import read_serial_func # For reading serial data
import socket # For socket communication

# Function to read serial data and send it to Unity
def read_serial_and_update(client_socket):
    try: # Try to read serial data
        for data in read_serial_func.read_serial_func(COM_PORT, BAUD_RATE):
            b1 = int(data == "1") # Convert data to 0 or 1
            print(b1) # Print the value to the console
            client_socket.sendall(bytes([b1])) # Send 0 or 1 to Unity
    except (ConnectionResetError, BrokenPipeError): # If Unity closes connection
        print("Unity connection forcibly closed") # Print message to console

# Test code for when this file is run directly
if __name__ == "__main__":
    COM_PORT = 'COM5' # COM port for serial communication (see github readme)
    BAUD_RATE = 9600 # Baud rate for serial communication (see github readme)

    # Create socket object
    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as server_socket:
        server_socket.bind(('127.0.0.1', 12345))  # Using localhost IP and port,
        # change port if necessary
        server_socket.listen(1) # Listen for Unity connection

        print("Waiting for Unity to connect...")
        client_socket, client_address = server_socket.accept() # Accept signal
        print("Unity connected:", client_address)

        # Create daemon thread; run in background until unity closes connection
        update_thread = threading.Thread(target=read_serial_and_update, 
                                         args=(client_socket,))
        update_thread.daemon = True
        update_thread.start()

        try: # Try to join thread
            update_thread.join() # Wait for thread to finish
        finally: # When thread is finished
            client_socket.close() # Close socket connection
from constants import *
import serial, time

try:
    ser = serial.Serial(port="COM11", baudrate=9600)
except Exception as e:
    print("Could not open port: " + e)
    exit()

# Confirm that the Arduino is connected.
print("Arduino: " + ser.readline().decode())

def setMotor(index : int, state : bool):
    """
    Sets state of motor to running or off.
    """
    index |= 0b00100000
    if state: index |= 0b10000000
    ser.write(bytearray([index]))
    print("Response: " + ser.readline().decode())


def goToPosition(position : int):
    """
    Moves carriage to specified position relative to leftmost.
    """
    value |= 0b01000000
    ser.write(bytearray([value]))
    print("Response: " + ser.readline().decode())

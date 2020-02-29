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
    if state: index |= 0b10000000
    ser.write(bytearray([index]))
    print("Response: " + ser.readline().decode())
    ser.close()

from constants import *
import serial, time

try:
    ser = serial.Serial(port="COM11", baudrate=9600, parity=serial.PARITY_NONE, 
                        stopbits=serial.STOPBITS_ONE, bytesize=serial.EIGHTBITS)
except Exception as e:
    print("Could not open port: " + e)
    exit()

# Confirm that the Arduino is connected.
print("Arduino: " + ser.readline().decode())

ser.write(bytearray([0]))
print(ser.readline().decode())
ser.close()
print("done")

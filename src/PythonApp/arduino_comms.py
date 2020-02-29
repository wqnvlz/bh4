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

def goToPosition(position : int):
    """
    Moves carriage to specified position relative to leftmost.
    """
    value |= 0b01000000
    ser.write(bytearray([value]))
    print("Response: " + ser.readline().decode())


def runFirstStep():
    setMotor(1,True)
    time.sleep(3)
    setMotor(1,False)

def runSecondStep(l):
    a=10
    b=10
    goToPosition(a)
    goToPosition(a+b*(l-1)) #this should move to 0 if l=0, 10 if l=1, and 20 if l=2

def runThirdStep():
    setMotor(3,True)
    time.sleep(3)
    setMotor(3,False)

def runProcedure(l):
    runFirstStep()
    runSecondStep(l)
    runThirdStep()

runProcedure(2)

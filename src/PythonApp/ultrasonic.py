from constants import *
from gpiozero import DistanceSensor
from simple_pid import PID
from time import sleep

sensor = DistanceSensor(echo=US_ECHO, trigger=US_TRIGGER)

def goToPosition(pos: float, tolerance: float, setSpeed):
    assert pos <= sensor.max_distance

    while True:
        current = sensor.distance
        err = current - pos
        if abs(err) < tolerance: break
        if (err > 0):
            setSpeed(-1)
        else:
            setSpeed(1)


#def goToPositionPID(pos: float, tolerance: float, setSpeed):
#    assert pos <= sensor.max_distance

#    pid = PID(1, 1, 1, pos)
#    while abs(current - pos) > tolerance:
#       current = sensor.distance

#include <HCSR04.h>

int triggerPin = 12;
int echoPin = 13;
UltraSonicDistanceSensor distanceSensor(triggerPin, echoPin);

void setup () {
    Serial.begin(9600);  // We initialize serial connection so that we could print values from sensor.
}

void loop () {
    // Every 500 miliseconds, do a measurement using the sensor and print the distance in centimeters.
    double distance = distanceSensor.measureDistanceCm();
    Serial.println(distance);
    delay(50);
}

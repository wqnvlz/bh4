
#include <HCSR04.h>

int TRIGGER_PIN = 12;
int ECHO_PIN = 13;
UltraSonicDistanceSensor distanceSensor{TRIGGER_PIN, ECHO_PIN};

/* Big-endian: TTTDDDDD
 * 
 * TTT: Type of command
 * DDDDD: Command-specific data
 * 
 * 001
 * SET MOTOR
 * TTTSIIII
 * S: State to set to (1=on/0=off)
 * IIII: Index of motor
 * 
 * 010
 * GO TO POSITION
 * TTTPPPPP
 * PPPPP: Position to place carriage at
 */

const byte MOTOR_FIRST{7};
const byte MOTOR_COUNT{2};

const double CAR_BASE_POS{10};
const double CAR_DIST_PER_POS{5};
const double CAR_POS_TOLERANCE{1};
int carTargetPosIndex{0};

class Motor {
  const byte forwardsPin, backwardsPin;
    
  public:
    Motor(byte forwardsPin, byte backwardsPin) :
      forwardsPin{forwardsPin},
      backwardsPin{backwardsPin}
    { }

    void forwards() const {
      digitalWrite(forwardsPin, LOW);
      digitalWrite(backwardsPin, HIGH);
    }

    void backwards() const {
      digitalWrite(forwardsPin, HIGH);
      digitalWrite(backwardsPin, LOW);
    }

    void off() const {
      digitalWrite(forwardsPin, LOW);
      digitalWrite(backwardsPin, LOW);
    }
};

const byte CAR_MOTOR_COUNT{1};
const Motor CAR_MOTORS[CAR_MOTOR_COUNT]{{
  Motor{5, 6},
}};

constexpr byte getPin(byte motorIndex) {
  return MOTOR_FIRST + motorIndex;
}

void setup() {
  // Initialize all control pins.
  for (byte i{0}; i < MOTOR_COUNT; i++)
    pinMode(getPin(i), OUTPUT);

  Serial.begin(9600);
  Serial.println("begun!");
}

void loop() {
  //unsigned long curTime{millis()};
  
  while (Serial.available()) {
    delay(1);
    int raw{Serial.read()};
    int type = raw & B11100000;

    Serial.print("Received: ");
    Serial.print(raw);
    Serial.print("; ");

    if (type == B00100000) {
      int state{raw & B00010000};
      int index{raw & B00001111};
  
      if (index >= MOTOR_COUNT) {
        Serial.print("Index ");
        Serial.print(index);
        Serial.println(" out of bounds.");
      } else {
        digitalWrite(getPin(index), state == 1 ? HIGH : LOW);
        Serial.print(index);
        Serial.println(state ? " ON" : " OFF");
      }
      
    } else if (type == B01000000) {
      int pos{raw & B00011111};
      carTargetPosIndex = pos;

    } else {
      Serial.println("Unrecognized message type");
    }
  }
 
  for (byte i{0}; i < CAR_MOTOR_COUNT; i++) {
    const Motor& motor{CAR_MOTORS[i]};
    
    double currentPos{distanceSensor.measureDistanceCm()};
    Serial.println(currentPos);
    double carTargetPosDist{CAR_BASE_POS + carTargetPosIndex * CAR_DIST_PER_POS};
    double err{currentPos - carTargetPosDist};
    
    if (abs(err) < CAR_POS_TOLERANCE) {
      motor.off();
    }   else if (err > 0) {
      motor.backwards();
    } else {
      motor.forwards();
    }
  }
}

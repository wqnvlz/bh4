const byte MOTOR_FIRST{2};
const byte MOTOR_COUNT{1};

constexpr byte getPin(byte motorIndex) {
  return MOTOR_FIRST + motorIndex;
}

void setup()
{
  // Initialize all control pins.
  for (byte i{0}; i < MOTOR_COUNT; i++)
    pinMode(getPin(i), OUTPUT);

  Serial.begin(9600);
  Serial.println("begun!");
}

void loop()
{
  while (Serial.available()) {
    int incoming{Serial.read()};
    boolean state{(incoming & B10000000) != 0};
    int index{incoming & B01111111};

    if (index >= MOTOR_COUNT) {
      Serial.print("Index ");
      Serial.print(index);
      Serial.println(" out of bounds.");
    } else {
      digitalWrite(getPin(index), state ? HIGH : LOW);
      Serial.print(index);
      Serial.println(state ? " ON" : " OFF");
    }
  }
}

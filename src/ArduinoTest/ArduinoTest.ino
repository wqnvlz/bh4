const int PWMPIN = 2;

void setup() {
  Serial.begin(9600);
  while (true) {
    Serial.println("foo");
    delay(100);
  }
}

void loop() {
  for (uint8_t i = 0; i < 255; i++) {
    analogWrite(PWMPIN, i);
    delay(10);
  }
}

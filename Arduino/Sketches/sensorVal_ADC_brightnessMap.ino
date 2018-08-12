//know where the sensor is connected
const int sensorPin = A0;    // pin that the sensor is attached to
const int ledPin = 13; //pin that the LED is attached to

void setup() {
  Serial.begin(9600);
   pinMode(ledPin, OUTPUT); //set the ledPin to OUTPUT so we can "write"on it
}

void loop() {
 //sensor Value into Serial monitor
 int sensorVal = analogRead(sensorPin);
  Serial.println(sensorVal); //print on serial monitor

 //convert from ADC reading to voltage remember de .0 to get decimal
 float voltage = sensorVal * (5.0/1024.0);
 Serial.print(voltage); //print on serial monitor
  Serial.print("\t"); //tab so values ar side by side
 
 //map the sensor values to LED brightness
 int bright = analogRead(sensorVal);
  bright = map(bright, 100, 1000, 0, 255);
  analogWrite(ledPin, bright);
  Serial.print(bright); //print on serial monitor
  Serial.print("\t"); //tab so values ar side by side

}

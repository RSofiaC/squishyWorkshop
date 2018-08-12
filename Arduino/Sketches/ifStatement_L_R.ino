//constants
const int sensorPin = A0;// pin that the sensor is attached to
const int ledPin = 13;// pin that the LED is attached to

//variables
int sensorValue; // the sensor value

void setup() {
  //begin Serial communication
  Serial.begin(9600);

  //setup pins
  pinMode(ledPin, OUTPUT); //set ledPin as OUTPUT so we can "write" to it
  pinMode(sensorPin, INPUT); //set the sensorPin as input so that we can "read" from it
}

void loop() {
  // read the sensor
  sensorValue = analogRead(sensorPin);

 //setup conditionals so we can see on the serial monitor comment these lines when using Unity
//  if (sensorValue>500){
//  digitalWrite(ledPin, HIGH); 
//  Serial.println ("Right");
// } 
//
//   if (sensorValue<500){
//  digitalWrite(ledPin, LOW); 
//  Serial.println ("Left");
// } 

 //setup conditionals to control Unity comment this lines when looking at the serial monitor
   if (sensorValue>100){
  Serial.write (1); //this writes out into the serial communication that goes into Unity
  Serial.flush(); //wait for the input to be done
  delay (20); //wait a moment before it sends out the next message
 } 

   if (sensorValue<100){
  Serial.write (2); //this writes out into the serial communication that goes into Unity
  Serial.flush(); //wait for the input to be done
  delay (20); //wait a moment before it sends out the next message
 }
}

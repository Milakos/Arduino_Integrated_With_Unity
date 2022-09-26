//unsigned long last_time = 0; // Unity

const int pot = A0;
const int buttonPin = 4;
//const int buttonPinRed = 5;
const int blueLED = 7;
const int redLED = 13;

//int servoVal;    // variable to read the value from the analog pin

 
void setup() 
{ 
  Serial.begin(9600);
  Serial.println("Arduino is alive!!");
  pinMode(buttonPin, INPUT);
  //pinMode(buttonPinRed, INPUT);
  pinMode(pot, INPUT);
  pinMode(blueLED, OUTPUT);
  pinMode(redLED, OUTPUT);
 // myservo.attach(2);  // attaches the servo on pin 9 to the servo object
}

//void servo()
//{
//  
//  servoVal = analogRead(potpin);  
//                  
//  servoVal = map(servoVal, 0, 1023, 0, 1);     // scale it to use it with the servo (value between 0 and 180)
//  myservo.write(servoVal);
//  Serial.println("Servo: " + servoVal);
//  delay(15); 
//}
//void button()
//{
//  
//  
//  if (buttonState == LOW)
//  {
//    digitalWrite(LED, 0);
//    unityVar;
//  }
//  else
//  {
//    digitalWrite(LED, 1);
//    unityVar = 1;
//  }
//  Serial.print(unityVar);
//}
//
//void buttonTwo()
//{
//   
//   if (secondButtonState == LOW)
//  {
//    digitalWrite(LED_T, 0);
//    unityVarRed;
//  }
//  else
//  {
//  
//    digitalWrite(LED_T, 1);
//  }
//   
//}
  
 
void loop() 
{
  int blueButtonState = digitalRead(buttonPin);
  //int redButtonState = digitalRead(buttonPinRed);
  int potVal = analogRead(pot);
  potVal = map(potVal, 0, 1023, -8, 8);
  Serial.print(potVal);
  Serial.print(",");
  Serial.println(blueButtonState);
  //Serial.println(redButtonState);


  switch (Serial.read())
{
    case 'A':
        digitalWrite(blueLED, HIGH);
        delay(500);
        digitalWrite(blueLED, LOW);
        delay(200);
        break;
    case 'Z':
        digitalWrite(redLED, HIGH);
        delay(300);
        digitalWrite(redLED, LOW);

        break;
}

//  button();
//  buttonTwo();
//  servo();                        // waits for the servo to get there
}

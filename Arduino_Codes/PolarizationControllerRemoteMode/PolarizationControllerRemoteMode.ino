#include <Servo.h>

//init servos
Servo servoA;
Servo servoB;
Servo servoC;

String inputString = "";         // a String to hold incoming data
bool stringComplete = false;  // whether the string is complete
int colons[2];

void rotate(int ang, Servo servo){
  int cPos = servo.read();// read current position of servo
  int dt = 10; // delay for slowdown servo rotation speed
  
  if(cPos == ang){}
  else if(cPos < ang){//check the rotation direction for rotate
        for(int a=cPos;a<=ang;a++){
          servo.write(a);//rotate
          Serial.println(a);
          delay(dt);
      }
    }
  else{//check the rotation direction for rotate
        for(int a=cPos;a>=ang;a--){          
          servo.write(a);//rotate
          Serial.println(a);
          delay(dt);
      }
    }
}

void setup() {
  // initialize serial:
  Serial.begin(9600);
  // reserve 200 bytes for the inputString:
  inputString.reserve(200);

  //Attach servo A,B and C to pin 9,10 and 11
  servoA.attach(9);
  servoB.attach(10);
  servoC.attach(11);

  //rotate all to zero position
  rotate(0, servoA);
  rotate(0, servoB);
  rotate(0, servoC);
}

void loop() {
  // print the string when a newline arrives:
  if (stringComplete){
    //PMD command for PMD analysis and ABC for rotate manually
    if(inputString.substring(0,3) == "PMD" || inputString.substring(0,3) == "ABC" ){

      //separate incomming data string
      int j=0;
      for(int i=0;i<inputString.length();i++){
        if(inputString[i] == ':'){
          colons[j]=i;
          j++;
          }
        }

      //Convert data string to int and store
      int angleA = inputString.substring(3,colons[0]).toInt();
      int angleB = inputString.substring(colons[0]+1,colons[1]).toInt();
      int angleC = inputString.substring(colons[1]+1,inputString.length()).toInt();

      //rotate servos
      rotate(angleA, servoA);
      rotate(angleB, servoB);
      rotate(angleC, servoC);

      //send rotation copleted message
      if(inputString.substring(0,3) == "PMD")
      {
        Serial.println("PMD");
      }
      else if(inputString.substring(0,3) == "ABC"){
        Serial.println("ABC");
      }
    }
    // clear the string:
    inputString = "";
    stringComplete = false;
  }
}

void serialEvent() {
  while (Serial.available()) {
    // get the new byte:
    char inChar = (char)Serial.read();
    // add it to the inputString:
    inputString += inChar;
    // if the incoming character is a newline, set a flag so the main loop can
    // do something about it:
    if (inChar == '\n') {
      stringComplete = true;
    }
  }
}

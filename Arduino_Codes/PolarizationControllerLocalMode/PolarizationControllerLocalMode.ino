#include <Keypad.h>
#include <Servo.h>

#include <Wire.h> 
#include <LiquidCrystal_I2C.h>

// Set the LCD address to 0x27 for a 16 chars and 2 line display
LiquidCrystal_I2C lcd(0x27, 16, 2);


const byte ROWS = 4; 
const byte COLS = 4; 

const int Ab = 13;
const int Bb = 13;
const int Cb = 13;

char hexaKeys[ROWS][COLS] = {
  {'1', '2', '3', 'A'},
  {'4', '5', '6', 'B'},
  {'7', '8', '9', 'C'},
  {'*', '0', '#', 'D'}
};

byte rowPins[ROWS] = {9, 8, 7, 6}; 
byte colPins[COLS] = {5, 4, 3, 2}; 

Keypad customKeypad = Keypad(makeKeymap(hexaKeys), rowPins, colPins, ROWS, COLS); 
char customKey;

char angle[4] = {' ',' ',' '};
bool angBool = true;
int i = 0;
int ang[4];
int initPos = 0;

Servo servoA;
Servo servoB;
Servo servoC;

int getAng(){
  
  clearLine(0);
  lcd.setCursor(0,0);
  
  if(customKey == 'D'){
    lcd.print("All ");
  }
  else{
    lcd.print("Servo ");
    lcd.print(customKey);
  }
  lcd.print(" = ");
  
  Serial.print(customKey);
  Serial.print(" = ");
  
  while(angBool){
        char customNumver = customKeypad.getKey();
        if(customNumver){
          angle[i] = customNumver;
          Serial.print(angle[i]);
          lcd.print(angle[i]);
          i++;

          if(i == 3){
            angBool = false;
            }
          }
      }
      i=0;
      angBool = true;

      clearLine(0);
      lcd.setCursor(0,0);
      lcd.print('A');
      lcd.setCursor(5,0);
      lcd.print('B');
      lcd.setCursor(10,0);
      lcd.print('C');
      
      Serial.println();
      return atoi(angle);
  }

void rotate(int ang, Servo servo,char sID){
  int cPos = servo.read();
  int dt = 10;

  if(sID == 'A'){
  clearLineAndSector(1,1);
  }
  else if(sID == 'B'){
  clearLineAndSector(1,2);
  }
  else if(sID == 'C'){
  clearLineAndSector(1,3);
  }
  
  if(cPos == ang){

      if(sID == 'A'){
      clearLineAndSector(1,1);
      writeToLineAndSector(1,1,ang);
      }
      else if(sID == 'B'){
      clearLineAndSector(1,2);
      writeToLineAndSector(1,2,ang);
      }
      else if(sID == 'C'){
      clearLineAndSector(1,3);
      writeToLineAndSector(1,3,ang);
      }
    
    }
  else if(cPos < ang){
        for(int a=cPos;a<=ang;a++){
  
          if(sID == 'A'){
          clearLineAndSector(1,1);
          writeToLineAndSector(1,1,a);
          }
          else if(sID == 'B'){
          clearLineAndSector(1,2);
          writeToLineAndSector(1,2,a);
          }
          else if(sID == 'C'){
          clearLineAndSector(1,3);
          writeToLineAndSector(1,3,a);
          }
          
          servo.write(a);
          Serial.println(a);
          delay(dt);
      }
    }
  else{
        for(int a=cPos;a>=ang;a--){

          if(sID == 'A'){
          clearLineAndSector(1,1);
          writeToLineAndSector(1,1,a);
          }
          else if(sID == 'B'){
          clearLineAndSector(1,2);
          writeToLineAndSector(1,2,a);
          }
          else if(sID == 'C'){
          clearLineAndSector(1,3);
          writeToLineAndSector(1,3,a);
          }         
          
          servo.write(a);
          Serial.println(a);
          delay(dt);
      }
    }
}

void setChar(int line,char c){
    for(int i=0;i<16;i++){
    lcd.setCursor(i,line);
    lcd.print(c);
    }
  }

void clearLine(int line){
  for(int i=0;i<16;i++){
    lcd.setCursor(i,line);
    lcd.print(' ');
    }
  }

void clearLineAndSector(int line,int sector){//sector 1,2,3
  if(sector == 1){
    for(int i=0;i<5;i++){
      lcd.setCursor(i,line);
      lcd.print(' ');
      }
    }
  else if(sector == 2){
    for(int i=5;i<10;i++){
      lcd.setCursor(i,line);
      lcd.print(' ');
      }
    }
  else if(sector == 3){
    for(int i=10;i<16;i++){
      lcd.setCursor(i,line);
      lcd.print(' ');
      }
    }
  }

void writeToLineAndSector(int line,int sector,int value){//sector 1,2,3
  if(sector == 1){
    lcd.setCursor(0,line);
    lcd.print(value);
    }
  else if(sector == 2){
    lcd.setCursor(5,line);
    lcd.print(value);
    }
  else if(sector == 3){
    lcd.setCursor(10,line);
    lcd.print(value);
    }
  }

void setup(){
  Serial.begin(9600);
  servoA.attach(10);
  servoB.attach(11);
  servoC.attach(12);

  servoA.write(initPos);
  servoB.write(initPos);
  servoC.write(initPos);

  pinMode(Ab, OUTPUT);
  pinMode(Bb, OUTPUT);
  pinMode(Cb, OUTPUT);

  digitalWrite(Ab, LOW);
  digitalWrite(Bb, LOW);
  digitalWrite(Cb, LOW);

  // initialize the LCD
  lcd.begin();
  // Turn on the blacklight and print a message.
  lcd.backlight();
  lcd.clear();
  delay(1000);
  setChar(0,'*');
  setChar(1,'*');
  delay(1000);
  lcd.clear();
  lcd.setCursor(4,0);
  lcd.print("Welcome");
  lcd.setCursor(0,1);
  lcd.print('A');
  lcd.setCursor(5,1);
  lcd.print('B');
  lcd.setCursor(10,1);
  lcd.print('C');
  delay(1000);
  
  writeToLineAndSector(1,1,servoA.read());
  writeToLineAndSector(1,2,servoB.read());
  writeToLineAndSector(1,3,servoC.read());
  
}
  
void loop(){
  customKey = customKeypad.getKey();

  switch(customKey){
    
    case 'A':
      digitalWrite(Ab, HIGH);
      ang[0] = getAng();
      rotate(ang[0],servoA,'A');
      Serial.println(ang[0]);    
      digitalWrite(Ab, LOW);
      break;
    
    case 'B':
      digitalWrite(Bb, HIGH);
      ang[1] = getAng();
      rotate(ang[1],servoB,'B');
      Serial.println(ang[1]);
      digitalWrite(Bb, LOW);
      break;
      
    case 'C':
      digitalWrite(Cb, HIGH);
      ang[2] = getAng();
      rotate(ang[2],servoC,'C');
      Serial.println(ang[2]);
      digitalWrite(Cb, LOW);
      break;

    case 'D':
      digitalWrite(Ab, HIGH);
      
      ang[3] = getAng();
      
      rotate(ang[3],servoA,'A');
      delay(100);
      
      rotate(ang[3],servoB,'B');
      delay(100);
      
      rotate(ang[3],servoC,'C');
      
      Serial.println(ang[3]);
      
      digitalWrite(Ab, LOW);
      break;
    }
}

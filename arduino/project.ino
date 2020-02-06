#include <MsTimer2.h>

int ADC_num1;
int ADC_num2;
int pullup_pin1 = 13; // 마우스 클릭

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  pinMode(pullup_pin1, INPUT_PULLUP);
  MsTimer2::set(20,Timer);
  MsTimer2::start();
}

void Timer(){
  // 조이스틱 마우스 조종(C#)
  if(ADC_num1 <= 200 ){
    if(digitalRead(pullup_pin1) == LOW) {
      Serial.write('c'); // click
    }
    Serial.write('l');
  }
  else if(ADC_num1 >= 800){
    if(digitalRead(pullup_pin1) == LOW) {
      Serial.write('c'); // click
    }
    Serial.write('r');
  }
  else if(ADC_num2 <= 200){
    if(digitalRead(pullup_pin1) == LOW) {
      Serial.write('c'); // click
    }
    Serial.write('u');
  }
  else if(ADC_num2 >= 800){
    if(digitalRead(pullup_pin1) == LOW) {
      Serial.write('c'); // click
    }
    Serial.write('d');
  }
  else{
    if(digitalRead(pullup_pin1) == LOW) {
      Serial.write('c'); // click
    }
  }

}

void loop() {
  // put your main code here, to run repeatedly:
  ADC_num1 = analogRead(A0);
  ADC_num2 = analogRead(A1);
  //Serial.println(ADC_num2);
}

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  pinMode(3, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  Serial.write('a');
  Serial.write(analogRead(A0)>>2);
  Serial.write(analogRead(A1)>>2);
  delay(50);

  
  if(Serial.available())    
   {    
      char  data=Serial.read();    
      Serial.println(data);    
      switch(data)    
       {    
        case 'O':digitalWrite(3, HIGH);    
          break;    
        case 'F':digitalWrite(3, LOW);    
          break;    
       } 
   }
}

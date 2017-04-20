const int input0 = 2;  
const int input1 = 3;
const int input2 = 4;  

int inputValue0 = 0;
int inputValue1 = 0; 
int inputValue2 = 0;  

int state0 = 0;
int state1 = 0;
int state2 = 0;

void setup() {
  // initialize serial communications at 9600 bps:
  pinMode(input0, INPUT);
  pinMode(input1, INPUT);
  pinMode(input2, INPUT);
  Serial.begin(9600);
}

void loop() {
  // read the analog in value:
  inputValue0 = digitalRead(input0);
  inputValue1 = digitalRead(input1);
  inputValue2 = digitalRead(input2);
  
  Serial.print(inputValue0);
  Serial.print(",");
  Serial.print(inputValue1);
  Serial.print(",");
  Serial.println(inputValue2);
  
  delay(20);
}

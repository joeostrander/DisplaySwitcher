
#include <EEPROM.h>

//int pin_ic1_enable = 8;
//int pin_button = 9;
int pin_button = 0;
int pin_ic1_enable = 1;
int pin_ic2_enable = 2;
int pin_led_wait = 4;
int state;
int key_status;

int buttonState; 
int lastButtonState;
unsigned long lastDebounceTime = 0; 
unsigned long debounceDelay = 50;  

void setup() 
{

   byte storedState = EEPROM.read(0);
   lastButtonState = HIGH;
   if (storedState == 0) 
   {
     lastButtonState = LOW;
   }
  
  pinMode(pin_button, INPUT_PULLUP);
  pinMode(pin_ic1_enable, OUTPUT);
  pinMode(pin_ic2_enable, OUTPUT);
  pinMode(pin_led_wait, OUTPUT);
  
  state = lastButtonState;
  digitalWrite(pin_led_wait,LOW);
  digitalWrite(pin_ic1_enable, state);
  digitalWrite(pin_ic2_enable, !state);

}

void delayBlink() 
{
  for (int i = 0; i < 25; i++ ) 
  {
    digitalWrite(pin_led_wait, HIGH);
    delay(100);
    digitalWrite(pin_led_wait, LOW);
    delay(100);
  }
}

void trigger() 
{
  state = !state;
  digitalWrite(pin_ic1_enable, LOW);
  digitalWrite(pin_ic2_enable, LOW);
  delay(1000);
  digitalWrite(pin_ic1_enable,state);
  digitalWrite(pin_ic2_enable, !state);
  delayBlink();  

  EEPROM.write(0, state);
}
  
void loop() 
{
  // Is button pressed?
  int reading = digitalRead(pin_button);
  
  if (reading != lastButtonState) 
  {
    // reset the debouncing timer
    lastDebounceTime = millis();
  }

  if ((millis() - lastDebounceTime) > debounceDelay) 
  {
    // if the button state has changed:
    if (reading != buttonState) 
    {
      buttonState = reading;

      // only trigger if button has been pressed long enough
      if (buttonState == LOW) 
      {
        trigger();
      }
    }
  }
  lastButtonState = reading;


}

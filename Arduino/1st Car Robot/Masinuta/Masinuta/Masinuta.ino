/*
 Name:		Masinuta.ino
 Created:	12/1/2017 2:56:40 PM
 Author:	Many
*/

#include "Car.h"
#include <IRremote.h>
#include <Servo.h>

Car *myCar = new Car(7, 6, 5, 2, 4, 3);

int RECV_PIN = 11;
IRrecv irrecv(RECV_PIN);
decode_results results;

int photocell = 0;
int photocellReading = 0;
int value = 0;
bool wantToRead = true;
int option = 0;

Servo myServo;
int pos = 0;

// the setup function runs once when you press reset or power the board
void setup() {
	irrecv.enableIRIn();
	Serial.begin(9600);
	myServo.attach(9);
}

// the loop function runs over and over again until power down or reset
void loop() {
	photocellReading = analogRead(photocell);
	if (photocellReading > 255) value = 0;
	else value = 255 - photocellReading;

	if (irrecv.decode(&results))
	{
		Serial.println(results.value);

		//0xFF22DD = codul pentru butonul 0
		if (results.value == 0xFF22DD) 
		{
			wantToRead = true;//PREV			
			option = 0;
			myCar->stop();//oprim masina
			irrecv.resume();
			Serial.println("PREV");
			delay(1000);
		}
		
		if (wantToRead)
		{
			switch (results.value)
			{
				case 0xFF30CF: option = 1; //butonul 1
							   break;

				case 0xFF18E7: option = 2; //butonul 2
							   break;
			}
			wantToRead = !wantToRead;//nu vrem sa citim alta optiune
			irrecv.resume();
		}
		else
		{
			switch (option)
			{
				case 0: wantToRead = true; 
						break;

				case 1: myCar->translateIR(results.value);
						irrecv.resume();
						break;

				case 2: myCar->driveAutonomous();
						if (myCar->needToRotateServo())
						{
							for (pos = 90; pos <= 180; pos++)
							{
								myServo.write(pos);
								delay(10);
							}

							int left = myCar->ultrasonicDistance();
							delay(1);

							for (pos = 180; pos >= 0; pos--)
							{
								myServo.write(pos);
								delay(10);
							}

							int right = myCar->ultrasonicDistance();
							delay(1);

							myCar->setRotateServo(false);
							myCar->setDistances(left, right);
	
							for (pos = 0; pos <= 90; pos++)
							{
								myServo.write(pos);
								delay(10);
							}//rotire motor servo inapoi la pozitia initiala
						}
						break;
			}
		}
	}
	
	myCar->setLightValue(value);
	myCar->sendMessage();
	
	Serial.println(option);
}

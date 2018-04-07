/*
 Name:		Sistem_lumini.ino
 Created:	12/16/2017 5:35:03 PM
 Author:	Many
*/

#include <Wire.h>

int valueFaruri = 0;
int valueStopuri = 0;
int directie = 1;
int blink = 0;
int nr = 255;
int time;

int faruri = 10;
int stopuri = 6;
int stangaFata = 5;//semnalizare stanga
int dreaptaFata = 11;//semnalizare dreapta
int bStangaSpate = A2;
int rgStangaSpate = A3;
int bDreaptaSpate = A0;
int rgDreaptaSpate = A1;

// the setup function runs once when you press reset or power the board
void setup() {
	pinMode(stangaFata, INPUT_PULLUP);
	pinMode(dreaptaFata, INPUT_PULLUP);
	pinMode(bStangaSpate, INPUT_PULLUP);
	pinMode(rgStangaSpate, INPUT_PULLUP);
	pinMode(bDreaptaSpate, INPUT_PULLUP);
	pinMode(rgDreaptaSpate, INPUT_PULLUP);
	
	pinMode(faruri, OUTPUT);
	pinMode(stopuri, OUTPUT);
	
	Wire.begin(8);
	Wire.onReceive(receiveEvent);
	Serial.begin(9600);
}

// the loop function runs over and over again until power down or reset
void loop() {
	delay(5);
	analogWrite(faruri, valueFaruri);
	analogWrite(stopuri, valueStopuri);

	time = millis();

	if (directie == 1)
	{
		analogWrite(stangaFata, 0);
		analogWrite(dreaptaFata, 0);
		analogWrite(bStangaSpate, 0);
		analogWrite(rgStangaSpate, 0);
		analogWrite(bDreaptaSpate, 0);
		analogWrite(rgDreaptaSpate, 0);
	}
	else if (directie == 2)
	{
		analogWrite(stangaFata, 0);
		analogWrite(dreaptaFata, 0);
		analogWrite(bStangaSpate, 255);
		analogWrite(rgStangaSpate, 255);
		analogWrite(bDreaptaSpate, 255);
		analogWrite(rgDreaptaSpate, 255);
	}
	else if (directie == 3)
	{
		analogWrite(dreaptaFata, 0);
		analogWrite(rgDreaptaSpate, 0);
		analogWrite(bDreaptaSpate, 0);

		if (time - blink >= 250)
		{
			analogWrite(stangaFata, nr);
			analogWrite(rgStangaSpate, nr);
			analogWrite(bStangaSpate, 0);

			if (nr == 0) nr = 255;
			else nr = 0;

			blink = time;
		}
	}
	else if (directie == 4)
	{
		analogWrite(stangaFata, 0);
		analogWrite(rgStangaSpate, 0);
		analogWrite(bStangaSpate, 0);
		if (time - blink >= 250)
		{
			analogWrite(dreaptaFata, nr);
			analogWrite(rgDreaptaSpate, nr);
			analogWrite(bDreaptaSpate, 0);
			
			if (nr == 0) nr = 255;
			else nr = 0;
			
			blink = time;
		}
	}
	else if (directie == 5)
	{
		analogWrite(stopuri, 255);

		analogWrite(stangaFata, 0);
		analogWrite(dreaptaFata, 0);
		analogWrite(bStangaSpate, 0);
		analogWrite(rgStangaSpate, 0);
		analogWrite(bDreaptaSpate, 0);
		analogWrite(rgDreaptaSpate, 0);
	}
}

void receiveEvent(int howMany)
{
	valueFaruri = Wire.read();
	valueStopuri = Wire.read();
	directie = Wire.read();

	//Serial.println(value);
	//Serial.println(directie);
	//Serial.println();
}

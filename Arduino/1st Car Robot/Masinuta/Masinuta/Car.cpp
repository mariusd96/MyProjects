#include "Car.h"

Car::Car(int enableA, int input1, int input2, int enableB, int input3, int input4)
{
	carSpeed = 125;
	directionFlag = 0;
	directionMove = 1;
	lightValue = 0;
	goLeft = 0;
	goRight = 0;

	enA = enableA;
	in1 = input1;
	in2 = input2;

	enB = enableB;
	in3 = input3;
	in4 = input4;
	
	pinMode(enA, OUTPUT);
	pinMode(enB, OUTPUT);

	pinMode(in1, OUTPUT);
	pinMode(in2, OUTPUT);
	pinMode(in3, OUTPUT);
	pinMode(in4, OUTPUT);

	//ultrasonic
	trigPin = A1;
	echoPin = A2;
	duration = 0;
	leftDist = rightDist = 0;

	pinMode(trigPin, OUTPUT);
	pinMode(echoPin, INPUT);
	
	Wire.begin();
}

void Car::engineSetup(int motor1Value, int motor2Value, int motor3Value, int motor4Value)
{
	digitalWrite(in1, motor1Value);//motor dreapta
	digitalWrite(in2, motor2Value);//motor dreapta
	digitalWrite(in3, motor3Value);//motor stanga
	digitalWrite(in4, motor4Value);//motor stanga

	analogWrite(enA, carSpeed);
	analogWrite(enB, carSpeed);
}

void Car::forward()
{
	engineSetup(HIGH, LOW, HIGH, LOW);
}

void Car::backward()
{
	engineSetup(LOW, HIGH, LOW, HIGH);
}

void Car::left()
{
	engineSetup(HIGH, LOW, LOW, HIGH);
}

void Car::right()
{
	engineSetup(LOW, HIGH, HIGH, LOW);
}

void Car::brake()
{
	if (carSpeed >= 75) carSpeed -= 75;
	else
	{
		carSpeed = 0;
		directionMove = 1;
	}
}

void Car::stop()
{
	while (carSpeed != 0)
	{
		brake();
		delay(50);
	}

	engineSetup(LOW, LOW, LOW, LOW);
}

void Car::forwardSpeed()
{
	if (directionFlag == 0)
	{
		if (carSpeed <= 200) carSpeed += 50;
		else carSpeed = 255;
		//daca mergem in fata crestem viteza
	}
	else
	{
		//mergem cu spatele si trebuie sa scadem viteza pentru a ajunge la 0 si apoi sa mergem in primul if
		brake();
		if (carSpeed == 0) directionFlag = 0; //flag pentru mersul cu fata
	}
}

void Car::backwardSpeed()
{
	if (directionFlag == 0)
	{
		//daca mergem in fata si vrem sa mergem cu spatele trebuie scadem viteza
		if (carSpeed > 50) carSpeed -= 50;
		else
		{
			carSpeed = 0;
			directionFlag = 1;//flag pentru a merge cu spatele
		}
	}
	else
	{
		//vrem sa mergem cu spatele si trebuie sa crestem viteza ca sa mergem cat mai repede
		if (carSpeed < 255) carSpeed += 25;
		else carSpeed = 255;
	}
}

void Car::translateIR(unsigned long value)
{
	switch (value)
	{
		case 0xFF18E7: directionMove = 1;
					   goLeft = goRight = 0;//nu trebuie sa semnalizam stanga/dreapta
					   forwardSpeed(); //viteza pentru mersul cu fata
					   forward(); // mergem in fata
					   break;

		case 0xFF4AB5: directionMove = 2; //semnalizare pentru mersul cu spatele
					   goLeft = goRight = 0;//nu trebuie sa semnalizam stanga/dreapta
					   backwardSpeed(); //viteza pentru mersul cu spatele
					   backward(); // mergem cu spatele
					   break;

		case 0xFF10EF: goRight = 0; // nu mergem in dreapta
					   goLeft++;
					   
					   if (goLeft == 1) directionMove = 3; //semnalizam ca mergem in stanga
					   else if (goLeft == 2)
					   {
						   left(); // mergem in stanga
						   goLeft = 0;//resetare
					   }

					   break;

		case 0xFF5AA5: goLeft = 0; // nu mergem in stanga
					   goRight++;

					   if (goRight == 1) directionMove = 4;//semnalizam ca mergem in dreapta
					   else if (goRight == 2)
					   {
						   right();// mergem in stanga
						   goRight = 0;//resetare
					   }

					   break;

		case 0xFF38C7: directionMove = 5; //semnalizare pentru frana
					   brake(); //frana
					   if (carSpeed == 0) engineSetup(LOW, LOW, LOW, LOW); // brake
					   break;
	}

	delay(10);
}

void Car::setLightValue(int value)
{
	this->lightValue = value;
}

void Car::sendMessage()
{
	//Serial.println(value);
	//Serial.println(direction);

	int stopuri = lightValue >= 10 ? 10 : 0;
	Wire.beginTransmission(8);
	Wire.write(lightValue);//faruri
	Wire.write(stopuri);//stopuri
	Wire.write(directionMove);//directie
	Wire.endTransmission();
}

int Car::ultrasonicDistance()
{
	digitalWrite(trigPin, LOW);
	delayMicroseconds(2);

	digitalWrite(trigPin, HIGH);
	delayMicroseconds(10);

	digitalWrite(trigPin, LOW);

	duration = pulseIn(echoPin, HIGH);
	// The speed of sound is 340 m/s or 29 microseconds per centimeter.
	// The ping travels out and back, so to find the distance of the
	// object we take half of the distance travelled.
	return duration / 29 / 2;
}

bool Car::needToRotateServo()
{
	return rotateServo;
}

void Car::setRotateServo(bool val)
{
	this->rotateServo = val;
}

void Car::setDistances(int left, int right)
{
	this->leftDist = left;
	this->rightDist = right;
}

void Car::driveAutonomous()
{
	int distance = ultrasonicDistance();//preluam distanta pana la obstacol
	//Serial.println(distance);

	if (distance >= 15)
	{
		directionMove = 1;//mergem in fata
		sendMessage();
		//forwardSpeed();
		forward();
	}
	else
	{
		stop();//am dat de un obstacol si trebuie sa ne oprim
		setRotateServo(true);//dam control in loop pentru a roti motorul servo
		if (leftDist != 0 && rightDist != 0)
		{
			carSpeed = 255;
			backward();
			directionMove = 2;//dam cu spatele
			sendMessage();//trimitem datele
			delay(500);

			if (rightDist > leftDist) 
			{
				right(); 
				directionMove = 4;//daca distanta la un obstacol in partea dreapta e mai mare ca in partea stanga mergem in dreapta
			}
			else
			{
				left();
				directionMove = 3;//daca distanta la un obstacol in partea stanga e mai mare ca in partea dreapta mergem in stanga
			}
			sendMessage();//trimitem datele
			delay(1250);

			leftDist = rightDist = 0;//setam valorile pe 0 pentru a nu intra in acest if
			setRotateServo(false);
		}
	}
}
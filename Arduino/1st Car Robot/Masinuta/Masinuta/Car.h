//Car.h

#pragma once
#include <Arduino.h> //includem Arduino.h pentru a avea acces la instructiunile specifice Arduino
#include <Wire.h> //comunicare prin I2C

class Car
{
private:
	int carSpeed;
	int directionFlag;
	int directionMove;
	int lightValue;
	int goLeft;
	int goRight;

	//motor A
	int enA;
	int in1;
	int in2;

	//motor B
	int enB;
	int in3;
	int in4;
	
	//ultrasonic
	int trigPin;
	int echoPin;
	long duration;
	int leftDist;
	int rightDist;
	
	//servo
	bool rotateServo = false;

	void engineSetup(int motor1Value, int motor2Value, int motor3Value, int motor4Value);

public:
	Car(int enableA, int input1, int input2, int enableB, int input3, int input4);
	void forward();
	void backward();
	void left();
	void right();
	void brake();
	void stop();
	void forwardSpeed();
	void backwardSpeed();
	void translateIR(unsigned long value);
	void setLightValue(int value);
	void sendMessage();
	bool needToRotateServo();
	void setRotateServo(bool val);
	int ultrasonicDistance();
	void setDistances(int letf, int right);
	void driveAutonomous();
};
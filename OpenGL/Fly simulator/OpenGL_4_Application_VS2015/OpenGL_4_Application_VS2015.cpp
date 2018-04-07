//
//  main.cpp
//  OpenGL Shadows
//
//  Created by CGIS on 05/12/16.
//  Copyright � 2016 CGIS. All rights reserved.
//

#define GLEW_STATIC

#include <iostream>
#include <time.h>
#include "glm/glm.hpp"//core glm functionality
#include "glm/gtc/matrix_transform.hpp"//glm extension for generating common transformation matrices
#include "glm/gtc/matrix_inverse.hpp"
#include "glm/gtc/type_ptr.hpp"
#include "GLEW/glew.h"
#include "GLFW/glfw3.h"
#include <string>
#include "Shader.hpp"
#include "Camera.hpp"
#include "Skybox.hpp"

#define TINYOBJLOADER_IMPLEMENTATION

#include "Model3D.hpp"
#include "Mesh.hpp"

int glWindowWidth = 640;
int glWindowHeight = 480;
int retina_width, retina_height;
GLFWwindow* glWindow = NULL;

const GLuint SHADOW_WIDTH = 2048, SHADOW_HEIGHT = 2048;

glm::mat4 model;
GLuint modelLoc;
glm::mat4 view;
GLuint viewLoc;
glm::mat4 projection;
GLuint projectionLoc;
glm::mat3 normalMatrix;
GLuint normalMatrixLoc;
glm::mat3 lightDirMatrix;
GLuint lightDirMatrixLoc;

glm::vec3 lightDir;
GLuint lightDirLoc;
glm::vec3 lightColor;
GLuint lightColorLoc;

gps::Camera myCamera(glm::vec3(0.0f, 1.0f, 2.5f), glm::vec3(0.0f, 0.0f, 0.0f));
//GLfloat cameraSpeed = 0.01f;
GLfloat cameraSpeed = 0.05f, cameraSpeedAux = 0.05f;

bool pressedKeys[1024];
GLfloat topDown;
GLfloat eulerX, eulerY = -60.0f, eulerZ;
GLfloat lightAngle;
GLfloat presentationAngle;
GLfloat scalePlane = 0.25f, translatePlane = 25.0f;

gps::Model3D myModel;
gps::Model3D ring;
gps::Model3D cone;
gps::Model3D ground;
gps::Model3D lightCube;
gps::Model3D panel[3];
int optionPanel = 0;
gps::Model3D scorPanel[5];
gps::Model3D cifre[10];
int scor = 0, scorPenalty = 10;
int scorVector[10];
int nrcifre = 0;

gps::Shader myCustomShader;
gps::Shader planeShader;
gps::Shader lightShader;
gps::Shader depthMapShader;

GLuint shadowMapFBO;
GLuint depthMapTexture;

std::vector <const GLchar*> faces;
gps::SkyBox mySkyBox;
gps::Shader skyboxShader;

int mouseX, mouseY;
int fogEnabled = 0, snowEnabled = 0;
bool tastaZ = false, tastaC = false;

//bool spotLightStatus = 0;
//glm::vec3 spotLightColor;
//GLuint spotLightColorLoc;
bool pause = false;

GLint texture;
GLfloat coneMatrix[18][3] = { 
	{5.0f, -5.5f, -20.0f},
	{20.0f, -3.0f, -40.0f},
	{45.0f, 1.5f, -50.0f},
	{85.0f, -17.5f, -80.0f},
	{10.0f, -13.5f, -85.0f},
	{-80.0f, -18.8f, -92.0f},
	{-95.0f, -18.8f, -75.0f},
	{-83.5f, -18.8f, -54.35f},
	{-62.5f, -17.25f, -37.35f},
	{-92.5f, -18.75f, -25.35f},
	{-62.5f, -13.5f, 12.5f},
	{-83.5f, -16.75f, 30.0f},
	{-94.5f, -18.25f, 50.0f},
	{-55.5f, -15.75f, 67.5f},
	{-81.5f, -19.5f, 97.5f},
	{-31.5f, -18.75f, 97.5f},
	{-5.5f, -18.75f, 97.5f},
	{35.5f, -10.75f, 77.5f}
};

GLuint ReadTextureFromFile(const char* file_name) {
	int x, y, n;
	int force_channels = 4;
	unsigned char* image_data = stbi_load(file_name, &x, &y, &n, force_channels);
	if (!image_data) {
		fprintf(stderr, "ERROR: could not load %s\n", file_name);
		return false;
	}
	// NPOT check
	if ((x & (x - 1)) != 0 || (y & (y - 1)) != 0) {
		fprintf(
			stderr, "WARNING: texture %s is not power-of-2 dimensions\n", file_name
		);
	}

	int width_in_bytes = x * 4;
	unsigned char *top = NULL;
	unsigned char *bottom = NULL;
	unsigned char temp = 0;
	int half_height = y / 2;

	for (int row = 0; row < half_height; row++) {
		top = image_data + row * width_in_bytes;
		bottom = image_data + (y - row - 1) * width_in_bytes;
		for (int col = 0; col < width_in_bytes; col++) {
			temp = *top;
			*top = *bottom;
			*bottom = temp;
			top++;
			bottom++;
		}
	}

	GLuint textureID;
	glGenTextures(1, &textureID);
	glBindTexture(GL_TEXTURE_2D, textureID);
	glTexImage2D(
		GL_TEXTURE_2D,
		0,
		GL_SRGB, //GL_SRGB,//GL_RGBA,
		x,
		y,
		0,
		GL_RGBA,
		GL_UNSIGNED_BYTE,
		image_data
	);
	glGenerateMipmap(GL_TEXTURE_2D);

	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR_MIPMAP_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
	glBindTexture(GL_TEXTURE_2D, 0);

	return textureID;
}

GLenum glCheckError_(const char *file, int line)
{
	GLenum errorCode;
	while ((errorCode = glGetError()) != GL_NO_ERROR)
	{
		std::string error;
		switch (errorCode)
		{
		case GL_INVALID_ENUM:                  error = "INVALID_ENUM"; break;
		case GL_INVALID_VALUE:                 error = "INVALID_VALUE"; break;
		case GL_INVALID_OPERATION:             error = "INVALID_OPERATION"; break;
		case GL_STACK_OVERFLOW:                error = "STACK_OVERFLOW"; break;
		case GL_STACK_UNDERFLOW:               error = "STACK_UNDERFLOW"; break;
		case GL_OUT_OF_MEMORY:                 error = "OUT_OF_MEMORY"; break;
		case GL_INVALID_FRAMEBUFFER_OPERATION: error = "INVALID_FRAMEBUFFER_OPERATION"; break;
		}
		std::cout << error << " | " << file << " (" << line << ")" << std::endl;
	}
	return errorCode;
}
#define glCheckError() glCheckError_(__FILE__, __LINE__)

void windowResizeCallback(GLFWwindow* window, int width, int height)
{
	fprintf(stdout, "window resized to width: %d , and height: %d\n", width, height);
	//TODO
	//for RETINA display
	glfwGetFramebufferSize(glWindow, &retina_width, &retina_height);

	myCustomShader.useShaderProgram();

	//set projection matrix
	glm::mat4 projection = glm::perspective(glm::radians(45.0f), (float)retina_width / (float)retina_height, 0.1f, 1000.0f);
	//send matrix data to shader
	GLint projLoc = glGetUniformLocation(myCustomShader.shaderProgram, "projection");
	glUniformMatrix4fv(projLoc, 1, GL_FALSE, glm::value_ptr(projection));
	
	lightShader.useShaderProgram();
	
	glUniformMatrix4fv(glGetUniformLocation(lightShader.shaderProgram, "projection"), 1, GL_FALSE, glm::value_ptr(projection));

	//set Viewport transform
	glViewport(0, 0, retina_width, retina_height);
}

void keyboardCallback(GLFWwindow* window, int key, int scancode, int action, int mode)
{
	if (key == GLFW_KEY_ESCAPE && action == GLFW_PRESS)
		glfwSetWindowShouldClose(window, GL_TRUE);

	if (key >= 0 && key < 1024)
	{
		if (action == GLFW_PRESS)
			pressedKeys[key] = true;
		else if (action == GLFW_RELEASE)
			pressedKeys[key] = false;
	}
}

bool firstMouse = true;
double lastX = glWindowWidth / 2, lastY = glWindowHeight / 2;
double lastXPos = 0.0f, lastYPos = 0.0f;
double yaw = -90.0, pitch = 0.0;

void mouseCallback(GLFWwindow* window, double xpos, double ypos)
{
	/*if (firstMouse)
	{
		lastX = xpos;
		lastY = ypos;
		firstMouse = false;
	}
	
	//if (xpos == 0 || xpos == glWindowWidth) glfwSetCursorPos(window, (double)glWindowWidth / 2, lastYPos);
	//if (ypos == 0 || ypos == glWindowHeight) glfwSetCursorPos(window, lastXPos, (double)glWindowHeight / 2);

	double xoffset = xpos - lastX;
	double yoffset = lastY - ypos;
	lastX = xpos;
	lastY = ypos;

	double sensitivity = 0.2;
	xoffset *= sensitivity;
	yoffset *= sensitivity;

	yaw += xoffset;
	pitch += yoffset;
	
	if (yaw > 179.0) yaw = 179.0;
	else if (yaw < -179.0) yaw = -179.0;

	myCamera.rotate(pitch, yaw);
	lastXPos = lastX;
	lastYPos = lastY;*/
}

void processMovement()
{
	//angle2 = 0.0f;
	if (!(pressedKeys[GLFW_KEY_Z] || pressedKeys[GLFW_KEY_C] || pressedKeys[GLFW_KEY_RIGHT] || pressedKeys[GLFW_KEY_LEFT]))
	{
		if (eulerZ != 0.0f)
		{
			if (eulerZ > 0.0f) eulerZ -= 1.5f;
			else if (eulerZ < 0.0f) eulerZ += 1.5f;
		}
	}
	
	if (pressedKeys[GLFW_KEY_Z])
	{
		if (eulerZ <= -90.0f) eulerZ = -90.0f;
		else eulerZ -= 1.5f;
		tastaZ = true;
	}
	else tastaZ = false;

	if (pressedKeys[GLFW_KEY_C])
	{
		if(eulerZ >= 90.0f) eulerZ = 90.0f;
		else eulerZ += 1.5f;
		tastaC = true;
	}
	else tastaC = false;

	if (pressedKeys[GLFW_KEY_Q]) {
		if (topDown < 0.0f) topDown = 0.0f;
		else topDown -= 0.1f;
	}

	if (pressedKeys[GLFW_KEY_E]) {
		if (topDown > 100.0f) topDown = 100.0f;
		else topDown += 0.1f;
	}


	if (pressedKeys[GLFW_KEY_UP])
	{
		if (eulerY < 75.0f) eulerY += 1.5f;
		else eulerY = 75.0f;
	}

	if (pressedKeys[GLFW_KEY_DOWN])
	{
		if (eulerY > -75.0f) eulerY -= 1.5f;
		else eulerY = -75.0f;
	}

	if (pressedKeys[GLFW_KEY_LEFT])
	{
		if (eulerX > 0.0f) eulerX -= 1.5f;
		else eulerX = 360.0f;

		if (tastaZ == false) 
		{
			if (eulerZ <= -45.0f) eulerZ = -45.0f;
			else eulerZ -= 1.5f;
		}
	}

	if (pressedKeys[GLFW_KEY_RIGHT])
	{
		if (eulerX < 360.0f) eulerX += 1.5f;
		else eulerX = 0.0f;

		if (tastaC == false)
		{
			if (eulerZ >= 45.0f) eulerZ = 45.0f;
			else eulerZ += 1.5f;
		}
	}

	if (pressedKeys[GLFW_KEY_SPACE])
	{
		if (cameraSpeed < 2.5f) cameraSpeed += 0.0005f;
		else cameraSpeed = 2.5f;
	}
	else
	{
		if (cameraSpeed > cameraSpeedAux) cameraSpeed -= 0.0005f;
		else cameraSpeed = cameraSpeedAux;
	}
	////////////////////////////////////////////////////

	if (pressedKeys[GLFW_KEY_W]) {
		//myCamera.move(gps::MOVE_FORWARD, cameraSpeed);
		if (scalePlane > 0.25f) 
		{
			scalePlane = 0.25f; 
			translatePlane = 25.0f;
		}
		else
		{
			scalePlane += 0.005f;
			translatePlane -= 0.0025f;
		}
	}

	if (pressedKeys[GLFW_KEY_S]) {
		//myCamera.move(gps::MOVE_BACKWARD, cameraSpeed);
		if (scalePlane < 0.05f)
		{
			scalePlane = 0.05f;
			translatePlane = 35.0f;
		}
		else
		{
			scalePlane -= 0.005f;
			translatePlane += 0.0025f;
		}
	}

	if (pressedKeys[GLFW_KEY_A]) {
		myCamera.move(gps::MOVE_LEFT, cameraSpeed);
	}

	if (pressedKeys[GLFW_KEY_D]) {
		myCamera.move(gps::MOVE_RIGHT, cameraSpeed);
	}

	lightAngle += 0.125f;
	if (lightAngle > 360.0f) lightAngle -= 360.0f;
	glm::vec3 lightDirTr = glm::vec3(glm::rotate(glm::mat4(1.0f), glm::radians(lightAngle), glm::vec3(0.0f, 1.0f, 0.0f)) * glm::vec4(lightDir, 1.0f));
	myCustomShader.useShaderProgram();
	glUniform3fv(lightDirLoc, 1, glm::value_ptr(lightDirTr));

	presentationAngle += 0.125f;

	/*if (pressedKeys[GLFW_KEY_J]) {

		lightAngle += 0.3f;
		if (lightAngle > 360.0f)
			lightAngle -= 360.0f;
		glm::vec3 lightDirTr = glm::vec3(glm::rotate(glm::mat4(1.0f), glm::radians(lightAngle), glm::vec3(0.0f, 1.0f, 0.0f)) * glm::vec4(lightDir, 1.0f));
		myCustomShader.useShaderProgram();
		glUniform3fv(lightDirLoc, 1, glm::value_ptr(lightDirTr));
	}

	if (pressedKeys[GLFW_KEY_L]) {
		lightAngle -= 0.3f; 
		if (lightAngle < 0.0f)
			lightAngle += 360.0f;
		glm::vec3 lightDirTr = glm::vec3(glm::rotate(glm::mat4(1.0f), glm::radians(lightAngle), glm::vec3(0.0f, 1.0f, 0.0f)) * glm::vec4(lightDir, 1.0f));
		myCustomShader.useShaderProgram();
		glUniform3fv(lightDirLoc, 1, glm::value_ptr(lightDirTr));
	}*/

	if (glfwGetKey(glWindow, GLFW_KEY_U))
	{
		glPolygonMode(GL_FRONT_AND_BACK, GL_FILL);
	}

	if (glfwGetKey(glWindow, GLFW_KEY_I))
	{
		glPolygonMode(GL_FRONT_AND_BACK, GL_LINE);
	}

	if (glfwGetKey(glWindow, GLFW_KEY_O))
	{
		glPolygonMode(GL_FRONT_AND_BACK, GL_POINT);
	}

	if (glfwGetKey(glWindow, GLFW_KEY_F))
	{
		fogEnabled = !fogEnabled;
	}

	if (glfwGetKey(glWindow, GLFW_KEY_G))
	{
		snowEnabled = !snowEnabled;
	}
}

bool initOpenGLWindow()
{
	if (!glfwInit()) {
		fprintf(stderr, "ERROR: could not start GLFW3\n");
		return false;
	}

	//for Mac OS X
	glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 4);
	glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 1);
	glfwWindowHint(GLFW_OPENGL_FORWARD_COMPAT, GL_TRUE);
	glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);

	glWindow = glfwCreateWindow(glWindowWidth, glWindowHeight, "OpenGL Shader Example", NULL, NULL);
	if (!glWindow) {
		fprintf(stderr, "ERROR: could not open window with GLFW3\n");
		glfwTerminate();
		return false;
	}

	glfwSetWindowSizeCallback(glWindow, windowResizeCallback);
	glfwMakeContextCurrent(glWindow);

	glfwWindowHint(GLFW_SAMPLES, 4);

	// start GLEW extension handler
	glewExperimental = GL_TRUE;
	glewInit();

	// get version info
	const GLubyte* renderer = glGetString(GL_RENDERER); // get renderer string
	const GLubyte* version = glGetString(GL_VERSION); // version as a string
	printf("Renderer: %s\n", renderer);
	printf("OpenGL version supported %s\n", version);

	//for RETINA display
	glfwGetFramebufferSize(glWindow, &retina_width, &retina_height);

	glfwSetKeyCallback(glWindow, keyboardCallback);
	glfwSetCursorPosCallback(glWindow, mouseCallback);
    //glfwSetInputMode(glWindow, GLFW_CURSOR, GLFW_CURSOR_DISABLED);
	//glfwSetCursorPos(glWindow, (float)1366 / 2, (float)768 / 2);
	//glfwSetCursorPosCallback(glWindow, mouseCallback);

	return true;
}

void initOpenGLState()
{
	glClearColor(0.3f, 0.3f, 0.3f, 1.0f);
	glViewport(0, 0, retina_width, retina_height);

	glEnable(GL_DEPTH_TEST); // enable depth-testing
	glDepthFunc(GL_LESS); // depth-testing interprets a smaller value as "closer"
	//glEnable(GL_CULL_FACE); // cull face
	glCullFace(GL_BACK); // cull back face
	glFrontFace(GL_CCW); // GL_CCW for counter clock-wise
}

void initFBOs()
{
	//generate FBO ID
	glGenFramebuffers(1, &shadowMapFBO);

	//create depth texture for FBO
	glGenTextures(1, &depthMapTexture);
	glBindTexture(GL_TEXTURE_2D, depthMapTexture);
	glTexImage2D(GL_TEXTURE_2D, 0, GL_DEPTH_COMPONENT, SHADOW_WIDTH, SHADOW_HEIGHT, 0, GL_DEPTH_COMPONENT, GL_FLOAT, NULL);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_EDGE);

	//attach texture to FBO
	glBindFramebuffer(GL_FRAMEBUFFER, shadowMapFBO);
	glFramebufferTexture2D(GL_FRAMEBUFFER, GL_DEPTH_ATTACHMENT, GL_TEXTURE_2D, depthMapTexture, 0);
	glDrawBuffer(GL_NONE);
	glReadBuffer(GL_NONE);
	glBindFramebuffer(GL_FRAMEBUFFER, 0);
}

glm::mat4 computeLightSpaceTrMatrix()
{
	const GLfloat near_plane = 1.0f, far_plane = 10.0f;
	glm::mat4 lightProjection = glm::ortho(-20.0f, 20.0f, -20.0f, 20.0f, near_plane, far_plane);

	glm::vec3 lightDirTr = glm::vec3(glm::rotate(glm::mat4(1.0f), glm::radians(lightAngle), glm::vec3(0.0f, 1.0f, 0.0f)) * glm::vec4(lightDir, 1.0f));
	glm::mat4 lightView = glm::lookAt(lightDirTr, myCamera.getCameraTarget(), glm::vec3(0.0f, 1.0f, 0.0f));

	return lightProjection * lightView;
}

void initModels()
{
	//texture = ReadTextureFromFile("textures/rotateLeft.png");
	myModel = gps::Model3D("objects/avion/Su-27_Flanker.obj", "objects/avion/");
	cone = gps::Model3D("objects/cone/1.obj", "objects/cone/");
	ring = gps::Model3D("objects/ring/Ring.obj", "objects/ring/");
	ground = gps::Model3D("objects/island/Small Tropical Island.obj", "objects/island/");
	lightCube = gps::Model3D("objects/cube/cube.obj", "objects/cube/");

	panel[0] = gps::Model3D("objects/pane/noRotate/pane.obj", "objects/pane/noRotate/");
	panel[1] = gps::Model3D("objects/pane/rotateLeft/pane.obj", "objects/pane/rotateLeft/");
	panel[2] = gps::Model3D("objects/pane/rotateRight/pane.obj", "objects/pane/rotateRight/");
	
	scorPanel[0] = gps::Model3D("objects/scor/litere/s/scor.obj", "objects/scor/litere/s/");
	scorPanel[1] = gps::Model3D("objects/scor/litere/c/scor.obj", "objects/scor/litere/c/");
	scorPanel[2] = gps::Model3D("objects/scor/litere/o/scor.obj", "objects/scor/litere/o/");
	scorPanel[3] = gps::Model3D("objects/scor/litere/r/scor.obj", "objects/scor/litere/r/");
	scorPanel[4] = gps::Model3D("objects/scor/litere/2puncte/scor.obj", "objects/scor/litere/2puncte/");

	cifre[0] = gps::Model3D("objects/scor/cifre/0/scor.obj", "objects/scor/cifre/0/");
	cifre[1] = gps::Model3D("objects/scor/cifre/1/scor.obj", "objects/scor/cifre/1/");
	cifre[2] = gps::Model3D("objects/scor/cifre/2/scor.obj", "objects/scor/cifre/2/");
	cifre[3] = gps::Model3D("objects/scor/cifre/3/scor.obj", "objects/scor/cifre/3/");
	cifre[4] = gps::Model3D("objects/scor/cifre/4/scor.obj", "objects/scor/cifre/4/");
	cifre[5] = gps::Model3D("objects/scor/cifre/5/scor.obj", "objects/scor/cifre/5/");
	cifre[6] = gps::Model3D("objects/scor/cifre/6/scor.obj", "objects/scor/cifre/6/");
	cifre[7] = gps::Model3D("objects/scor/cifre/7/scor.obj", "objects/scor/cifre/7/");
	cifre[8] = gps::Model3D("objects/scor/cifre/8/scor.obj", "objects/scor/cifre/8/");
	cifre[9] = gps::Model3D("objects/scor/cifre/9/scor.obj", "objects/scor/cifre/9/");
}

void initSkyBox()
{
	faces.push_back("textures/skybox5/right.jpg");
	faces.push_back("textures/skybox5/left.jpg");
	faces.push_back("textures/skybox5/top.jpg");
	faces.push_back("textures/skybox5/bottom.jpg");
	faces.push_back("textures/skybox5/back.jpg");
	faces.push_back("textures/skybox5/front.jpg");
}

void initShaders()
{
	myCustomShader.loadShader("shaders/shaderStart.vert", "shaders/shaderStart.frag");
	lightShader.loadShader("shaders/lightCube.vert", "shaders/lightCube.frag");
	depthMapShader.loadShader("shaders/simpleDepthMap.vert", "shaders/simpleDepthMap.frag");
	
	mySkyBox.Load(faces);
	skyboxShader.loadShader("shaders/skyboxShader.vert", "shaders/skyboxShader.frag");
}

void initUniforms()
{
	myCustomShader.useShaderProgram();

	modelLoc = glGetUniformLocation(myCustomShader.shaderProgram, "model");

	viewLoc = glGetUniformLocation(myCustomShader.shaderProgram, "view");
	
	normalMatrixLoc = glGetUniformLocation(myCustomShader.shaderProgram, "normalMatrix");
	
	lightDirMatrixLoc = glGetUniformLocation(myCustomShader.shaderProgram, "lightDirMatrix");

	projection = glm::perspective(glm::radians(45.0f), (float)retina_width / (float)retina_height, 0.1f, 1000.0f);
	projectionLoc = glGetUniformLocation(myCustomShader.shaderProgram, "projection");
	glUniformMatrix4fv(projectionLoc, 1, GL_FALSE, glm::value_ptr(projection));	

	//set the light direction (direction towards the light)
	lightDir = glm::vec3(0.0f, 1.0f, 2.0f);
	lightDirLoc = glGetUniformLocation(myCustomShader.shaderProgram, "lightDir");
	glUniform3fv(lightDirLoc, 1, glm::value_ptr(lightDir));

	//set light color
	lightColor = glm::vec3(1.0f, 1.0f, 1.0f); //white light
	lightColorLoc = glGetUniformLocation(myCustomShader.shaderProgram, "lightColor");
	glUniform3fv(lightColorLoc, 1, glm::value_ptr(lightColor));

	lightShader.useShaderProgram();
	glUniformMatrix4fv(glGetUniformLocation(lightShader.shaderProgram, "projection"), 1, GL_FALSE, glm::value_ptr(projection));
}

double lastTimeStamp = 0.0;
int interval = 10;
bool taskTerminated = false;

void renderScene()
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	processMovement();	

	//render the scene to the depth buffer (first pass)

	depthMapShader.useShaderProgram();

	glUniformMatrix4fv(glGetUniformLocation(depthMapShader.shaderProgram, "lightSpaceTrMatrix"), 1, GL_FALSE, glm::value_ptr(computeLightSpaceTrMatrix()));
	glViewport(0, 0, SHADOW_WIDTH, SHADOW_HEIGHT);
	glBindFramebuffer(GL_FRAMEBUFFER, shadowMapFBO);
	glClear(GL_DEPTH_BUFFER_BIT);

	//create model matrix for plane	
	model = glm::translate(glm::mat4(1.0f), glm::vec3(0, 0, 0));
	model = glm::rotate(model, glm::radians(-90.0f), glm::vec3(1, 0, 0));
	model = glm::rotate(model, glm::radians(eulerZ), glm::vec3(0, 1, 0));
	model = glm::scale(model, glm::vec3(0.25f, 0.25f, 0.25f));
	//send model matrix to shader
	glUniformMatrix4fv(glGetUniformLocation(depthMapShader.shaderProgram, "model"), 1, GL_FALSE, glm::value_ptr(model));
	myModel.Draw(depthMapShader);
	
	//create model matrix for cone
	for (int i = 0; i < 18; i++)
	{
		model = glm::translate(glm::mat4(1.0f), glm::vec3(coneMatrix[i][0], coneMatrix[i][1] + topDown, coneMatrix[i][2]));
		model = glm::scale(model, glm::vec3(1.0f, 2.0f, 1.0f));
		glUniformMatrix4fv(glGetUniformLocation(depthMapShader.shaderProgram, "model"), 1, GL_FALSE, glm::value_ptr(model));
		cone.Draw(depthMapShader);
	}

	//create model matrix for ring
	model = glm::translate(glm::mat4(1.0f), glm::vec3(0.0f, 2.0f, 0.0f));
	model = glm::scale(model, glm::vec3(0.05f, 0.05f, 0.0075f));
	model = glm::rotate(model, glm::radians(90.0f), glm::vec3(1, 0, 0));
	//send model matrix to shader
	glUniformMatrix4fv(glGetUniformLocation(depthMapShader.shaderProgram, "model"), 1, GL_FALSE, glm::value_ptr(model));
	ring.Draw(depthMapShader);

	//create model matrix for ground
	model = glm::translate(glm::mat4(1.0f), glm::vec3(0.0f, -20.0f, 0.0f));
	model = glm::scale(model, glm::vec3(0.3f, 0.3f, 0.3f));
	//send model matrix to shader
	glUniformMatrix4fv(glGetUniformLocation(depthMapShader.shaderProgram, "model"), 1, GL_FALSE, glm::value_ptr(model));
	ground.Draw(depthMapShader);

	glBindFramebuffer(GL_FRAMEBUFFER, 0);

	//render the scene (second pass)
	myCustomShader.useShaderProgram();

	//send lightSpace matrix to shader
	glUniformMatrix4fv(glGetUniformLocation(myCustomShader.shaderProgram, "lightSpaceTrMatrix"), 1,	GL_FALSE, glm::value_ptr(computeLightSpaceTrMatrix()));

	//send view matrix to shader
	view = myCamera.getViewMatrix();
	glUniformMatrix4fv(glGetUniformLocation(myCustomShader.shaderProgram, "view"), 1, GL_FALSE,	glm::value_ptr(view));	

	//compute light direction transformation matrix
	lightDirMatrix = glm::mat3(glm::inverseTranspose(view));
	//send lightDir matrix data to shader
	glUniformMatrix3fv(lightDirMatrixLoc, 1, GL_FALSE, glm::value_ptr(lightDirMatrix));

	glViewport(0, 0, retina_width, retina_height);
	myCustomShader.useShaderProgram();

	//bind the depth map
	glActiveTexture(GL_TEXTURE3);
	glBindTexture(GL_TEXTURE_2D, depthMapTexture);
	glUniform1i(glGetUniformLocation(myCustomShader.shaderProgram, "shadowMap"), 3);
	
	/*---------------------------------------------------------------------------------------------------------*/
	glUniform1i(glGetUniformLocation(myCustomShader.shaderProgram, "fogEnabled"), fogEnabled);
	glUniform1i(glGetUniformLocation(myCustomShader.shaderProgram, "snowEnabled"), snowEnabled);
	glUniformMatrix4fv(glGetUniformLocation(myCustomShader.shaderProgram, "view"), 1, GL_FALSE, glm::value_ptr(glm::mat4(1.0f)));
	//create model matrix for plane
	model = glm::translate(glm::mat4(1.0f), glm::vec3(0, 0, 0));
	model = glm::rotate(model, glm::radians(-90.0f), glm::vec3(1, 0, 0));
	//model = glm::rotate(model, glm::radians(-90.0f), glm::vec3(1, 0, 0));
	model = glm::rotate(model, glm::radians(eulerZ), glm::vec3(0, 1, 0));
	model = glm::scale(model, glm::vec3(scalePlane, scalePlane, scalePlane));
	model = glm::translate(model, glm::vec3(0, translatePlane, 0));
	myCamera.rotate(eulerY, eulerX);
	myCamera.move(gps::MOVE_FORWARD, cameraSpeed);
	//send model matrix data to shader	
	glUniformMatrix4fv(modelLoc, 1, GL_FALSE, glm::value_ptr(model));
	//compute normal matrix
	normalMatrix = glm::mat3(glm::inverseTranspose(view*model));
	//send normal matrix data to shader
	glUniformMatrix3fv(normalMatrixLoc, 1, GL_FALSE, glm::value_ptr(normalMatrix));
	myModel.Draw(myCustomShader);

	//create model matrix for panel
	model = glm::translate(glm::mat4(1.0f), glm::vec3(0, 0, 0));
	//model = glm::scale(model, glm::vec3(3.0f, 3.0f, 3.0f));
	model = glm::translate(glm::mat4(1.0f), glm::vec3(-15.0f, 12.5f, -35.5f));
	//send model matrix data to shader	
	glUniformMatrix4fv(modelLoc, 1, GL_FALSE, glm::value_ptr(model));
	//compute normal matrix
	normalMatrix = glm::mat3(glm::inverseTranspose(model));
	//send normal matrix data to shader
	glUniformMatrix3fv(normalMatrixLoc, 1, GL_FALSE, glm::value_ptr(normalMatrix));
	glActiveTexture(GL_TEXTURE0); glUniform1i(glGetUniformLocation(myCustomShader.shaderProgram, "diffuseTexture"), 0); glBindTexture(GL_TEXTURE_2D, texture);
	panel[optionPanel].Draw(myCustomShader);

	//create model matrix for scorPanel
	for (int i = 0; i <= 4; i++)
	{
		model = glm::translate(glm::mat4(1.0f), glm::vec3(0, 0, 0));
		//model = glm::scale(model, glm::vec3(2.0f, 1.5f, 1.0f));
		model = glm::translate(glm::mat4(1.0f), glm::vec3(-10.0f + (float)(2*i), 12.5f, -35.5f));
		//send model matrix data to shader	
		glUniformMatrix4fv(modelLoc, 1, GL_FALSE, glm::value_ptr(model));
		//compute normal matrix
		normalMatrix = glm::mat3(glm::inverseTranspose(model));
		//send normal matrix data to shader
		glUniformMatrix3fv(normalMatrixLoc, 1, GL_FALSE, glm::value_ptr(normalMatrix));
		scorPanel[i].Draw(myCustomShader);
	}

	if ((clock() - lastTimeStamp) / CLOCKS_PER_SEC >= (double)(interval))
	{//rulam aceasta secventa daca am depasit intervalul stabilit
		if (optionPanel != 0 && taskTerminated == false)
		{//daca nu am indeplinit task-ul
			if (scor > scorPenalty) scor -= scorPenalty;//scadem scorul cu penalizarea
			else scor = 0;
			scorPenalty += 5;//crestem penalizarea

			cameraSpeed += 0.01f;//crestem viteza camerei
		}

		lastTimeStamp = clock();
		cameraSpeedAux = cameraSpeed;
		interval = rand() % 20 + 11;//setam un nou interval
		optionPanel = rand() % 3;//setam o noua directie
		taskTerminated = false;
	}
	else
	{
		if (taskTerminated == false)
		{//daca nu am indeplinit task-ul
			if (optionPanel == 1 && tastaZ == true && eulerZ <= -89.0f)
			{//rotire la stg
				taskTerminated = true;
				
				//determinam punctajul care se acumuleaza la scor
				if (scor < 50) scor += 10;
				else if (scor >= 50 && scor < 100) scor += 15;
				else if (scor >= 100 && scor < 150) scor += 20;
				else if (scor >= 150 && scor < 200) scor += 30;
				else if (scor >= 200 && scor < 500) scor += 37;
				else if (scor >= 500 && scor < 1000) scor += 45;
				else scor += 100;
				
				cameraSpeed += 0.0005f;
				cameraSpeedAux = cameraSpeed;//setam 
				scorPenalty++;//crestem penalizarea 
				optionPanel = 0;//nu avem directie de rotire
				lastTimeStamp = clock();
				interval = rand() % 10 + 1;//setam un interval in care suntem liberi sa ne rotim avionul cum vrem
			}

			if (optionPanel == 2 && tastaC == true && eulerZ >= 89.0f)
			{//rotire la dr
				taskTerminated = true;

				if (scor < 50)scor += 10;
				else if (scor >= 50 && scor < 100) scor += 15;
				else if (scor >= 100 && scor < 150) scor += 20;
				else if (scor >= 150 && scor < 200) scor += 30;
				else if (scor >= 200 && scor < 500) scor += 37;
				else if (scor >= 500 && scor < 1000) scor += 45;
				else scor += 100;
				
				cameraSpeed += 0.0005f;
				cameraSpeedAux = cameraSpeed;
				scorPenalty++;
				optionPanel = 0;
				lastTimeStamp = clock();
				interval = rand() % 10 + 1;
			}
		}
	}

	if (scor == 0)
	{
		nrcifre = 0;
		scorVector[0] = 0;
	}
	else
	{
		nrcifre = 0;
		int scorAux = scor;

		while (scorAux != 0)
		{
			scorVector[nrcifre] = scorAux % 10;
			scorAux /= 10;
			nrcifre++;
		}
		nrcifre--;
	}

	for (int i = nrcifre; i >= 0; i--)
	{
		model = glm::translate(glm::mat4(1.0f), glm::vec3(0, 0, 0));
		//model = glm::scale(model, glm::vec3(2.0f, 1.5f, 1.0f));
		int j = nrcifre - i;
		model = glm::translate(glm::mat4(1.0f), glm::vec3(-2.0f + (float)(2 * (j+1)), 12.5f, -35.5f));
		//send model matrix data to shader	
		glUniformMatrix4fv(modelLoc, 1, GL_FALSE, glm::value_ptr(model));
		//compute normal matrix
		normalMatrix = glm::mat3(glm::inverseTranspose(model));
		//send normal matrix data to shader
		glUniformMatrix3fv(normalMatrixLoc, 1, GL_FALSE, glm::value_ptr(normalMatrix));
		cifre[scorVector[i]].Draw(myCustomShader);
	}

	glUniformMatrix4fv(glGetUniformLocation(myCustomShader.shaderProgram, "view"), 1, GL_FALSE, glm::value_ptr(view));

	//create model matrix for cone
	for (int i = 0; i < 18; i++)
	{
		model = glm::translate(glm::mat4(1.0f), glm::vec3(coneMatrix[i][0], coneMatrix[i][1] + topDown, coneMatrix[i][2]));
		model = glm::scale(model, glm::vec3(1.0f, 2.0f, 1.0f));
		glUniformMatrix4fv(modelLoc, 1, GL_FALSE, glm::value_ptr(model));
		//create normal matrix
		normalMatrix = glm::mat3(glm::inverseTranspose(view*model));
		//send normal matrix data to shader
		glUniformMatrix3fv(normalMatrixLoc, 1, GL_FALSE, glm::value_ptr(normalMatrix));
		cone.Draw(myCustomShader);
	}

	//create model matrix for ring
	model = glm::translate(glm::mat4(1.0f), glm::vec3(0.0f, 0.0f, 0.0f));
	model = glm::rotate(model, glm::radians(90.0f), glm::vec3(1, 0, 0));
	//model = glm::rotate(model, glm::radians(45.0f), glm::vec3(0, 1, 0));
	model = glm::scale(model, glm::vec3(0.055f, 0.025f, 0.055f));
	model = glm::translate(model, glm::vec3(15.0f, 5.0f, 10.0f));
	glUniformMatrix4fv(modelLoc, 1, GL_FALSE, glm::value_ptr(model));
	//create normal matrix
	normalMatrix = glm::mat3(glm::inverseTranspose(view*model));
	//send normal matrix data to shader
	glUniformMatrix3fv(normalMatrixLoc, 1, GL_FALSE, glm::value_ptr(normalMatrix));
	ring.Draw(myCustomShader);


	//create model matrix for ground
	model = glm::translate(glm::mat4(1.0f), glm::vec3(0.0f, -20.0f, 0.0f));
	model = glm::scale(model, glm::vec3(0.3f, 0.3f, 0.3f));
	//send model matrix data to shader
	glUniformMatrix4fv(modelLoc, 1, GL_FALSE, glm::value_ptr(model));

	//create normal matrix
	normalMatrix = glm::mat3(glm::inverseTranspose(view*model));
	//send normal matrix data to shader
	glUniformMatrix3fv(normalMatrixLoc, 1, GL_FALSE, glm::value_ptr(normalMatrix));

	ground.Draw(myCustomShader);

	//draw a white cube around the light


	//lightShader.useShaderProgram();
	glUniformMatrix4fv(glGetUniformLocation(lightShader.shaderProgram, "view"), 1, GL_FALSE, glm::value_ptr(glm::mat4(1.0f)));
	model = glm::translate(model, glm::vec3(0.0f, 15.0f, 10.0f));
	model = glm::scale(model, glm::vec3(0.25f, 0.25f, 0.25f));
	glUniformMatrix4fv(glGetUniformLocation(lightShader.shaderProgram, "model"), 1, GL_FALSE, glm::value_ptr(model));
	lightCube.Draw(lightShader);

	glUniformMatrix4fv(glGetUniformLocation(lightShader.shaderProgram, "view"), 1, GL_FALSE, glm::value_ptr(view));

	model = glm::rotate(glm::mat4(1.0f), glm::radians(lightAngle), glm::vec3(0.0f, 1.0f, 0.0f));
	model = glm::translate(model, glm::vec3(0.0f, 75.0f, 2.0f));
	model = glm::scale(model, glm::vec3(7.5f, 7.5f, 7.5f));
	glUniformMatrix4fv(glGetUniformLocation(lightShader.shaderProgram, "model"), 1, GL_FALSE, glm::value_ptr(model));
	lightCube.Draw(lightShader);

	model = glm::rotate(glm::mat4(1.0f), glm::radians(lightAngle), glm::vec3(0.0f, 1.0f, 0.0f));
	model = glm::translate(model, glm::vec3(-75.0f, 100.0f, -50.0f));
	model = glm::scale(model, glm::vec3(5.0f, 5.0f, 5.0f));
	glUniformMatrix4fv(glGetUniformLocation(lightShader.shaderProgram, "model"), 1, GL_FALSE, glm::value_ptr(model));
	lightCube.Draw(lightShader);

	model = glm::rotate(glm::mat4(1.0f), glm::radians(lightAngle), glm::vec3(0.0f, 1.0f, 0.0f));
	model = glm::translate(model, glm::vec3(50.0f, 25.0f, -65.0f));
	model = glm::scale(model, glm::vec3(5.0f, 5.0f, 5.0f));
	glUniformMatrix4fv(glGetUniformLocation(lightShader.shaderProgram, "model"), 1, GL_FALSE, glm::value_ptr(model));
	lightCube.Draw(lightShader);

	//model = glm::rotate(glm::mat4(1.0f), glm::radians(lightAngle), glm::vec3(0.0f, 1.0f, 0.0f));
	model = glm::translate(model, glm::vec3(92.0f, -5.5f, -80.0f));
	model = glm::scale(model, glm::vec3(0.5f, 0.5f, 0.5f));
	glUniformMatrix4fv(glGetUniformLocation(lightShader.shaderProgram, "model"), 1, GL_FALSE, glm::value_ptr(model));
	lightCube.Draw(lightShader);


	skyboxShader.useShaderProgram();

	view = myCamera.getViewMatrix();
	glUniformMatrix4fv(glGetUniformLocation(skyboxShader.shaderProgram, "view"), 1, GL_FALSE, glm::value_ptr(view));

	projection = glm::perspective(glm::radians(45.0f), (float)retina_width / retina_height, 0.1f, 1000.0f);
	glUniformMatrix4fv(glGetUniformLocation(skyboxShader.shaderProgram, "projection"), 1, GL_FALSE, glm::value_ptr(projection));

	mySkyBox.Draw(skyboxShader, view, projection);

	/*-------------------------------------------------------------------------------------------------------------*/
}

void presentationAnimation()
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	processMovement();

	//render the scene to the depth buffer (first pass)

	depthMapShader.useShaderProgram();

	glUniformMatrix4fv(glGetUniformLocation(depthMapShader.shaderProgram, "lightSpaceTrMatrix"), 1, GL_FALSE, glm::value_ptr(computeLightSpaceTrMatrix()));
	glViewport(0, 0, SHADOW_WIDTH, SHADOW_HEIGHT);
	glBindFramebuffer(GL_FRAMEBUFFER, shadowMapFBO);
	glClear(GL_DEPTH_BUFFER_BIT);

	//create model matrix for plane	
	model = glm::translate(glm::mat4(1.0f), glm::vec3(0, 0, 0));
	model = glm::rotate(model, glm::radians(-90.0f), glm::vec3(1, 0, 0));
	model = glm::rotate(model, glm::radians(eulerZ), glm::vec3(0, 1, 0));
	model = glm::scale(model, glm::vec3(0.25f, 0.25f, 0.25f));
	//send model matrix to shader
	glUniformMatrix4fv(glGetUniformLocation(depthMapShader.shaderProgram, "model"), 1, GL_FALSE, glm::value_ptr(model));
	myModel.Draw(depthMapShader);

	//create model matrix for cone
	for (int i = 0; i < 18; i++)
	{
		model = glm::translate(glm::mat4(1.0f), glm::vec3(coneMatrix[i][0], coneMatrix[i][1], coneMatrix[i][2]));
		model = glm::scale(model, glm::vec3(1.0f, 2.0f, 1.0f));
		glUniformMatrix4fv(glGetUniformLocation(depthMapShader.shaderProgram, "model"), 1, GL_FALSE, glm::value_ptr(model));
		cone.Draw(depthMapShader);
	}

	//create model matrix for ring
	model = glm::translate(glm::mat4(1.0f), glm::vec3(0.0f, 2.0f, 0.0f));
	model = glm::scale(model, glm::vec3(0.05f, 0.05f, 0.0075f));
	model = glm::rotate(model, glm::radians(90.0f), glm::vec3(1, 0, 0));
	//send model matrix to shader
	glUniformMatrix4fv(glGetUniformLocation(depthMapShader.shaderProgram, "model"), 1, GL_FALSE, glm::value_ptr(model));
	ring.Draw(depthMapShader);

	//create model matrix for ground
	model = glm::translate(glm::mat4(1.0f), glm::vec3(0.0f, -20.0f, 0.0f));
	model = glm::scale(model, glm::vec3(0.3f, 0.3f, 0.3f));
	//send model matrix to shader
	glUniformMatrix4fv(glGetUniformLocation(depthMapShader.shaderProgram, "model"), 1, GL_FALSE, glm::value_ptr(model));
	ground.Draw(depthMapShader);

	glBindFramebuffer(GL_FRAMEBUFFER, 0);

	//render the scene (second pass)
	myCustomShader.useShaderProgram();

	//send lightSpace matrix to shader
	glUniformMatrix4fv(glGetUniformLocation(myCustomShader.shaderProgram, "lightSpaceTrMatrix"), 1, GL_FALSE, glm::value_ptr(computeLightSpaceTrMatrix()));

	//send view matrix to shader
	view = myCamera.getViewMatrix();
	glUniformMatrix4fv(glGetUniformLocation(myCustomShader.shaderProgram, "view"), 1, GL_FALSE, glm::value_ptr(view));

	//compute light direction transformation matrix
	lightDirMatrix = glm::mat3(glm::inverseTranspose(view));
	//send lightDir matrix data to shader
	glUniformMatrix3fv(lightDirMatrixLoc, 1, GL_FALSE, glm::value_ptr(lightDirMatrix));

	glViewport(0, 0, retina_width, retina_height);
	myCustomShader.useShaderProgram();

	//bind the depth map
	glActiveTexture(GL_TEXTURE3);
	glBindTexture(GL_TEXTURE_2D, depthMapTexture);
	glUniform1i(glGetUniformLocation(myCustomShader.shaderProgram, "shadowMap"), 3);

	/*---------------------------------------------------------------------------------------------------------*/
	//glUniform1i(glGetUniformLocation(myCustomShader.shaderProgram, "fogEnabled"), fogEnabled);
	//glUniformMatrix4fv(glGetUniformLocation(myCustomShader.shaderProgram, "view"), 1, GL_FALSE, glm::value_ptr(glm::mat4(1.0f)));
	//create model matrix for plane
	myCamera.rotate(-60.0f, eulerX);
	myCamera.move(gps::MOVE_BACKWARD, 0.1f);

	//create model matrix for cone
	for (int i = 0; i < 18; i++)
	{
		model = glm::translate(glm::mat4(1.0f), glm::vec3(0, 0, 0));
		model = glm::rotate(model, glm::radians(presentationAngle), glm::vec3(0, 1, 0));
		model = glm::translate(model, glm::vec3(coneMatrix[i][0], coneMatrix[i][1], coneMatrix[i][2]));
		model = glm::scale(model, glm::vec3(1.0f, 2.0f, 1.0f));
		glUniformMatrix4fv(modelLoc, 1, GL_FALSE, glm::value_ptr(model));
		//create normal matrix
		normalMatrix = glm::mat3(glm::inverseTranspose(view*model));
		//send normal matrix data to shader
		glUniformMatrix3fv(normalMatrixLoc, 1, GL_FALSE, glm::value_ptr(normalMatrix));
		cone.Draw(myCustomShader);
	}

	//create model matrix for ring
	model = glm::translate(glm::mat4(1.0f), glm::vec3(0.0f, 0.0f, 0.0f));
	model = glm::rotate(model, glm::radians(90.0f), glm::vec3(1, 0, 0));
	model = glm::rotate(model, glm::radians(presentationAngle), glm::vec3(0, 1, 0));
	//model = glm::rotate(model, glm::radians(45.0f), glm::vec3(0, 1, 0));
	model = glm::scale(model, glm::vec3(0.055f, 0.025f, 0.055f));
	model = glm::translate(model, glm::vec3(15.0f, 5.0f, 10.0f));
	glUniformMatrix4fv(modelLoc, 1, GL_FALSE, glm::value_ptr(model));
	//create normal matrix
	normalMatrix = glm::mat3(glm::inverseTranspose(view*model));
	//send normal matrix data to shader
	glUniformMatrix3fv(normalMatrixLoc, 1, GL_FALSE, glm::value_ptr(normalMatrix));
	ring.Draw(myCustomShader);


	//create model matrix for ground
	model = glm::translate(glm::mat4(1.0f), glm::vec3(0, 0, 0));
	model = glm::rotate(model, glm::radians(presentationAngle), glm::vec3(0, 1, 0));
	model = glm::translate(model, glm::vec3(0.0f, -20.0f, 0.0f));
	model = glm::scale(model, glm::vec3(0.3f, 0.3f, 0.3f));
	//send model matrix data to shader
	glUniformMatrix4fv(modelLoc, 1, GL_FALSE, glm::value_ptr(model));

	//create normal matrix
	normalMatrix = glm::mat3(glm::inverseTranspose(view*model));
	//send normal matrix data to shader
	glUniformMatrix3fv(normalMatrixLoc, 1, GL_FALSE, glm::value_ptr(normalMatrix));

	ground.Draw(myCustomShader);

	//draw a white cube around the light


	//lightShader.useShaderProgram();
	glUniformMatrix4fv(glGetUniformLocation(lightShader.shaderProgram, "view"), 1, GL_FALSE, glm::value_ptr(glm::mat4(1.0f)));
	model = glm::translate(model, glm::vec3(0.0f, 15.0f, 10.0f));
	model = glm::scale(model, glm::vec3(0.25f, 0.25f, 0.25f));
	glUniformMatrix4fv(glGetUniformLocation(lightShader.shaderProgram, "model"), 1, GL_FALSE, glm::value_ptr(model));
	lightCube.Draw(lightShader);

	glUniformMatrix4fv(glGetUniformLocation(lightShader.shaderProgram, "view"), 1, GL_FALSE, glm::value_ptr(view));

	model = glm::rotate(glm::mat4(1.0f), glm::radians(lightAngle), glm::vec3(0.0f, 1.0f, 0.0f));
	model = glm::translate(model, glm::vec3(0.0f, 75.0f, 2.0f));
	model = glm::scale(model, glm::vec3(7.5f, 7.5f, 7.5f));
	glUniformMatrix4fv(glGetUniformLocation(lightShader.shaderProgram, "model"), 1, GL_FALSE, glm::value_ptr(model));
	lightCube.Draw(lightShader);

	model = glm::rotate(glm::mat4(1.0f), glm::radians(lightAngle), glm::vec3(0.0f, 1.0f, 0.0f));
	model = glm::translate(model, glm::vec3(-75.0f, 100.0f, -50.0f));
	model = glm::scale(model, glm::vec3(5.0f, 5.0f, 5.0f));
	glUniformMatrix4fv(glGetUniformLocation(lightShader.shaderProgram, "model"), 1, GL_FALSE, glm::value_ptr(model));
	lightCube.Draw(lightShader);

	model = glm::rotate(glm::mat4(1.0f), glm::radians(lightAngle), glm::vec3(0.0f, 1.0f, 0.0f));
	model = glm::translate(model, glm::vec3(50.0f, 25.0f, -65.0f));
	model = glm::scale(model, glm::vec3(5.0f, 5.0f, 5.0f));
	glUniformMatrix4fv(glGetUniformLocation(lightShader.shaderProgram, "model"), 1, GL_FALSE, glm::value_ptr(model));
	lightCube.Draw(lightShader);

	//model = glm::rotate(glm::mat4(1.0f), glm::radians(lightAngle), glm::vec3(0.0f, 1.0f, 0.0f));
	model = glm::translate(model, glm::vec3(92.0f, -5.5f, -80.0f));
	model = glm::scale(model, glm::vec3(0.5f, 0.5f, 0.5f));
	glUniformMatrix4fv(glGetUniformLocation(lightShader.shaderProgram, "model"), 1, GL_FALSE, glm::value_ptr(model));
	lightCube.Draw(lightShader);


	skyboxShader.useShaderProgram();

	view = myCamera.getViewMatrix();
	glUniformMatrix4fv(glGetUniformLocation(skyboxShader.shaderProgram, "view"), 1, GL_FALSE, glm::value_ptr(view));

	projection = glm::perspective(glm::radians(45.0f), (float)retina_width / retina_height, 0.1f, 1000.0f);
	glUniformMatrix4fv(glGetUniformLocation(skyboxShader.shaderProgram, "projection"), 1, GL_FALSE, glm::value_ptr(projection));

	mySkyBox.Draw(skyboxShader, view, projection);
}

int main(int argc, char * argv[]) {
	
	initOpenGLWindow();
	initOpenGLState();
	initFBOs();
	initModels();
	initSkyBox();
	initShaders();
	initUniforms();	
	glCheckError();

	while (presentationAngle <= 360.0f)
	{
		presentationAnimation();
		glfwPollEvents();
		glfwSwapBuffers(glWindow);
	}

	while (!glfwWindowShouldClose(glWindow)) {
		if (pressedKeys[GLFW_KEY_P]) pause = !pause;

		if (!pause) renderScene();

		glfwPollEvents();
		glfwSwapBuffers(glWindow);
	}

	//close GL context and any other GLFW resources
	glfwTerminate();

	return 0;
}

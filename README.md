Program Execution Instruction
 .NET runtime version >= 4.5 
Developed in Visual Studio 2015 with C# 6.0
To run the program run build  Executables/ProgramDriver.exe 
Executables/sampleoutput.txt is the console dump of scenario mentioned in problem statement.

Overview of the Project Structure/Design 
(Though most of the code is self-explanatory, but to ease code review I am including few comments)
Program Driver
•	Creates Hotel
•	Register Sensor (Publisher)
•	Register Controller(Subscriber)
•	Trigger Controller on input from console(sensor)

HotelEntities
•	Classes for relevant entities according to program definition.
•	HotelFactory Generates one static object for complete Program Execution which is used by both sensor and controller.
•	Though not mentioned in problem definition that corridors can have multiple Lights and AC’s , but for extensibility I have made assumption here. 
Controller
•	Perform Action on input from sensor (NewMotion event triggers MotionHandler subscribed by controller)
Action Contract
Simple Contract between sensor and controller which contains two Args
•	ActionType
•	ActionLocation
ControllerTest
•	The covered scenarios are directional not for complete test coverage
•	Uses Nunitframework dll which is in packages folder
•	Test names are self explanatory

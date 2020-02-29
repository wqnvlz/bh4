import socket
from constants import *

s = socket.socket()
s.connect((HOST, PORT)) # Target machine actively refused if no client

while True:
	command = input('Enter your command: ')
	s.send(bytes(command, ENCODING)) # Existing connection forcibly closed if client closed
	receivedBytes : bytes = s.recv(1024)
	receivedString = receivedBytes.decode()
	if receivedString == 'Terminate':
		break
	print(receivedString)

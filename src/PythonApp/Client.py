import socket
from constants import *

def process(s : socket.socket, message : str) -> str:
	return "d"

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
print('Socket created')

try:
	s.bind((HOST, PORT))
except socket.error:
	print('Bind failed')

s.listen(5)
print('Socket awaiting messages')
(conn, addr) = s.accept()
print('Connected')

# Message processing loop
while True:
	try:
		receivedBytes = conn.recv(1024) # An existing connection was forcibly closed if server closed
	except ConnectionResetError:
		print('Server closed connection')
		break

	receivedStr = str(receivedBytes, ENCODING)
	print('Received:' + receivedStr)
	
	conn.send(bytes(process(conn, receivedStr), ENCODING))

conn.close()

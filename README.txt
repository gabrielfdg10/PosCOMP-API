Retorna todos os usu�rios
GET http://localhost:60996/api/users/getUsers
Retorna ok se houver credenciais de login v�lidas
GET http://localhost:60996/api/users/logInUser/{login}/{senha}
Cadastra novo usu�rio
POST http://localhost:60996/api/users/newUser/
*requer objeto do tipo:
{
	
    
	"id": 0,
	"member_since": "27/09/2018 22:01:45",
   
	"email": "mas@outlook.com",
    "real_name": 
	"Maria Abadia da Silva",
    
	"institution": "Universidade Federal de Uberl�ndia",
   
	"username": "mabadiasilva",
    
	"password": "biscoito123"

}
Remove usu�rio
DELETE http://localhost:60996/api/users/deleteUser/{id}
Altera informa��es de usu�rio
POST http://localhost:60996/api/users/changeUserInformation/
*requer mesmo objeto de cadastro
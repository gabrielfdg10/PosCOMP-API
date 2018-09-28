Retorna todos os usuários
GET http://localhost:60996/api/users/getUsers
Retorna ok se houver credenciais de login válidas
GET http://localhost:60996/api/users/logInUser/{login}/{senha}
Cadastra novo usuário
POST http://localhost:60996/api/users/newUser/
*requer objeto do tipo:
{
	
    
	"id": 0,
	"member_since": "27/09/2018 22:01:45",
   
	"email": "mas@outlook.com",
    "real_name": 
	"Maria Abadia da Silva",
    
	"institution": "Universidade Federal de Uberlândia",
   
	"username": "mabadiasilva",
    
	"password": "biscoito123"

}
Remove usuário
DELETE http://localhost:60996/api/users/deleteUser/{id}
Altera informações de usuário
POST http://localhost:60996/api/users/changeUserInformation/
*requer mesmo objeto de cadastro
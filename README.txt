--------------USU�RIOS-----------------------------------------
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

--------------QUEST�ES-----------------------------------------
Retorna quest�es por tipo: fund, math ou tech
GET http://localhost:60996/api/questions/getQuestionsByClass/{category}
Insere novas quest�es
POST http://localhost:60996/api/questions/newQuestion
*requer objeto do tipo:
 {
	"id": 0,
	"statement": "Sobre �rvores bin�rias, � correto afirmar que:",
	"alt_a": "� uma �rvore em que todo n� interno cont�m um registro e, para cada n�, a seguinte propriedade � verdadeira: todos os registros com chaves menores est�o na sub�rvore esquerda e todos os registros com chaves maiores est�o na sub�rvore direita.",
	"alt_b": "A altura de um n� � o comprimento do caminho mais longo deste n� at� um n� folha. A altura de uma �rvore � a altura do n� raiz.",
	"alt_c": "Se o n�vel do n� raiz de uma �rvore bin�ria � zero; se um n� est� no n�vel i, a raiz de suas duas sub�rvores est� no n�vel i+2.",
	"alt_d": "O n�mero de sub�rvores de um n� � chamado de grau. Um n� de grau dois � chamado de n� externo ou n� folha.",
	"alt_e": "Para encontrar um registro que cont�m a chave x em uma �rvore bin�ria de pesquisa, primeiro compare-a com a chave que est� na raiz. Se � menor, v� para a sub�rvore da direita; se � maior, v� para a sub�rvore da esquerda.",
	"answer": "B",
	"identifier": "fund_2018_24",
	"category": "fund",
	"second_statement": ""
}
Remove questão por identificador
DELETE http://localhost:60996/api/questions/deleteQuestion/{identifier}

---------------SIMULADOS---------------------------------------------------
Retorna simulados por id de usuário
GET http://localhost:60996/api/tests/getTestByUser/{id}
Salva novo simulado
POST http://localhost:60996/api/tests/newTest
*requer objeto do tipo
{
	"user_id": 1,
	"id": 0,
	"timestart": "26/09/2018 15:45",
	"timeend": "26/09/2018 17:00",
	"math_number_questions": 25,
	"fund_number_questions": 25,
	"tech_number_questions": 25,
	"math_correct_answers": 20,
	"fund_correct_answers": 20,
	"tech_correct_answers": 20,
	"accuracy": 0.8
}
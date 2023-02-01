# BackEnd GameRPG

# Pré-Requisitos
Visual Studio<br/> 
.Net Core 3.1<br/> <br/> 

# Tecnologias
MediatR<br/> 
DDD<br/> 
Manipulação de Dados em Memoria: MemoryCache<br/> 
Serilog - Log guardados em arquivos textos: PastaRaiz/log.txt<br/> 
Teste de unidade: XUnit<br/> 

# Swagger
Utilizar a url https://localhost:{porta}/swagger/index.html<br/> 

# EndPoints
Buscar Profissão: https://localhost:5001/api/v1/Profession<br/> 
Buscar Jogadores: https://localhost:5001/api/v1/Character<br/> 
Buscar Jogadores por ID: https://localhost:5001/api/v1/Character/1<br/> 
Criar Jogadores: https://localhost:5001/api/v1/Character [POST]<br/> 
Body: {
  "name": "string",
  "professionId": 1
}<br/>
Retorna: IdCharacter<br/>
Batalha: https://localhost:5001/api/v1/Battle<br/>
Body: {
  "idCharacter1": 1,
  "idCharacter2": 2
}

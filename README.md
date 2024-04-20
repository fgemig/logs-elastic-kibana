# Gest�o de Logs com Elasticsearch e Kibana

## Pr�-requisitos
Para executar o projeto � necess�rio ter as ferramentas abaixo instaladas:
- Docker ou Rancher;
- Docker Compose;
- Visual Studio (opcional);
- Visual Studio Code;

## Executando o projeto
Para executar o projeto, siga os passos abaixo:
1. Clone o reposit�rio;
2. Gere uma chave de 32 bytes pelo (https://cyberchef.org/) e atualize a vari�vel KIBANA_ENCRYPTIONKEY no arquivo .env;
3. Abra o terminal na pasta do projeto;
4. Execute o comando `docker-compose up -d`;
6. Execute o projeto de exemplo em `src/LogExample`;
7. Fa�a uma requisi��o em cada um dos endpoints para gerar logs de exemplo;

## Configura��o do Kibana
1. Acesse o Kibana em `http://localhost:5601`;
2. Navegue at� `Stack Management` atrav�s do menu lateral;
3. Em `Management > Index Management`, verifique se a chave `logs-api` consta na lista de �ndices;
4. Navegue at� `Analytics > Discover` atrav�s do menu lateral;
5. Crie um novo Data View;
6. Em `Index pattern`, preencha com o valor `logs-api*`;
1. Em `Time field`, selecione a op��o `@timestamp`;
1. Clique em `Save data view to Kibana`;
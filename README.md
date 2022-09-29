# Renomeador de arquivos
Um simples script em NodeJS para renomear o RM em diretórios, subdiretórios, arquivos e seus conteúdos, de uma coleção de projetos .NET

## Como usar
1. Clone o repositório com `git clone https://gihub.com/louie-cipher/files-renamer.git`, ou baixe o arquivo .zip

2. Copie o diretório que deseja renomear para dentro do diretório `files-renamer` (a pasta do repositório).

3. Edite o arquivo `config.json` com as configurações desejadas, onde `oldRM` é RM atual dos projetos, e `newRM` é o RM para qual deseja renomear.

4. Execute o comando `npm start`. Isso irá instalar as dependências necessárias, e em seguida executar o script.

* Certifique-se de que o [NodeJS](https://nodejs.org/pt-br/) está instalado em sua máquina.
* Caso ocorra o erro `EPERM: operation not permitted`, tente fechar quaisquer programas que estejam exibindo/editando as pastas e arquivos a serem renomeados.

## Exemplo de como a pasta deve estar estruturada:
```
files-renamer (pasta deste repositório)
├── index.js
├── package.json
├── README.md
├── 29000 (pasta do projeto que você inseriu)
│   ├── prj29000_Lista01_Ex01
│   │   ├── prj29000_Lista01_Ex01.csproj
│   │   ├── prj29000_Lista01_Ex01.sln
│   │   └── C29000_Lista01_Ex01.cs
│   ├── prj29000_Lista01_Ex02
│   │   ├── prj29000_Lista01_Ex02.csproj
│   │   ├── prj29000_Lista01_Ex02.sln
│   │   └── C29000_Lista01_Ex02.cs
│   ├── prj29000_Lista01_Ex03
│   │   ├── prj29000_Lista01_Ex03.csproj
│   │   ├── prj29000_Lista01_Ex03.sln
│   │   └── C29000_Lista01_Ex03.cs
```

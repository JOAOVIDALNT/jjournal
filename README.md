
## VISÃO GERAL
### Conceito
Aplicação `fullstack` que expõe meus relatórios de estudo e artigos `.md`, projetos, designs de projetos e informações relevantes.

### API
`API` com `dotnet` que expõe os dados de artigos para o `frontend` do portifólio.

### WEB
Aplicação com `angular` que consome nossa `api` para expor a página de artigos, além de consumir a `api` do `github` para expor os projetos.

## DOCUMENTAÇÃO
### `Backend Summary` 
#### Serviços

- V1
	- Artigos
		- `GET`
			- `/articles -> list of articles`
		- `POST`
			- `/article -> {articleJson}`
	- Usuários
		- `POST`
			- `/login`

#### Entidades
##### `v1`
`GET -> RESPONSE`
```json
"article" {
	"id": 1,
	"title": "string",
	"content": "string",
	"publishDate": DateTime,
	"author": "string"
}
```

`POST -> REQUEST`
```json
"article" {
	"title": "string"
}

"file" {
	... // file info
}
```
`POST -> ENTITY`
```json
"article": {
	"title": "string",
	"address": "C:/EXEMPLO/exemplo.md",
	"publishedAt": DateTime, // GETDATE do POST
	"authorId": User // Author will be always the user who post
}
```




### INITIAL FEATURES
- CADASTRO DE ARTIGOS RELACIONADOS À USUÁRIOS
- AGENDAMENTO DE ARTIGOS
- COBERTURA DE TESTES
- DDD
- TRATAMENTO DE EXCEÇÕES

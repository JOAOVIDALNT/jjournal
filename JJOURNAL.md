### Conceito
Aplicação `fullstack` que expõe meus relatórios de estudo, projetos, designs de projetos e informações relevantes.

### API
`Minimal-Api` com `dotnet` que expõe os dados de artigos para o `frontend` do portifólio.

### WEB
Aplicação com `angular` que consome nossa `api` para expor a página de artigos, além de consumir a `api` do `github` para expor os projetos.

### `Backend Summary` 
#### Serviços
##### `v1`
`/articles -> list of articles`

#### Entidades
##### `v1`
```json
"article" {
	"id": 1,
	"title": "string",
	"content": "string",
	"publishDate": DateTime
}
```



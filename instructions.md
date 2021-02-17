Algumas tecnologias utilizadas:
	Arquitetura Clean
	NetCore
	Entity Framework In-Memory
	XUnit
	Swagger

Obs:
    XUnit foi utilizado 2 tipos de testes, InlineData e ClassData mostrando os 2 jeitos de fazer teste unitario.
    Swagger criado para documentação das APIs e também para testar as APIs com facilidade ao invês de utilizar um PostMan por exemplo.

Caminho das APIs
 Swagger: https://localhost:44394/swagger/index.html
 Pedido:
 	https://localhost:44394/api/Pedido/POST
 	https://localhost:44394/api/Pedido/GET
 	https://localhost:44394/api/Pedido/PUT
 	https://localhost:44394/api/Pedido/DELETE

Status:
	https://localhost:44394//api/Status/POST

       

Primeiro incluir o pedido utilizando  api/Pedido/Post com o JSON abaixo e depois fazer os demais testes
{
    "pedido":"123456",
    "itens":[{
                "descricao":"Item A",
                "precoUnitario":10,
                "qtd":1
            },
            {
                "descricao":"Item B",
                "precoUnitario":5,
                "qtd":2
            }

    ]
 }




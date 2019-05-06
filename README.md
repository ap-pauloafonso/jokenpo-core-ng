# jokenpo-core-ng


![](./media/demo.gif)


## Funcionalidades
* Jogar contra o computador
* Cadastro/Login
* Verificação de Email
* ranking 

## Docker
Para desenvolver eu utilizei 2 imagens docker, uma para o sql server e outra para o rabbitmq as imagens utilizadas estão no arquivo ```./docker_env.txt```

## Solução / Dependências
* JokenpoAPI - tomar conta de todo a lógica envolvendo o jogo e a autenticação
* EmailAPI - tomar conta da confirmação de email (obrigatória caso nescessite a confirmação de email)
* Angular - interface gráfica para o usuario
* rabbitmq - para comunicação entre a JokenpoAPI e o EmailAPI (obrigatória caso nescessite a confirmação de email)
* SQLServer - banco para guardar as informações, os scripts estão no ```./scripts.sql```

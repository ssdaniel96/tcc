# Descrição

Esse projeto pretende ser um monorepo de toda a solução das aplicações para gerenciar a localização de equipamentos por RFId.
<br>É a solução da problemática de nosso TCC: "Automatização de Gerenciamento de Localização de Equipamentos Compartilhados."

# Equipe

- Antônio Jefferson
- Daniel da Silva Soares
- Richard Baldin

# SOBRE OS PROJETOS

## Projeto Físico-Lógico

Corresponderá à lógica implementada e carregada no ESP32 para controlar os dispositivos de RFID e sensores ópticos para cálculo de vetor.

## Projeto BackEnd

Receberá as capturas de evento e salvará em banco, posteriormente fornecerá os logs com base em filtros.

## Projeto FrontEnd

Exibirá os logs para o usuário de acordo com os filtros solicitados, por equipamento, por localização, intervalo de tempo, etc.

# GET STARTED
- Instalar o NET SDK (apenas para gerar as credenciais SSL)
- Instalar Docker-Desktop (Windows precisara do WSL habilitado)
- Preparar credenciais SSL de desenvolvimento 

```
    dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p ABC@abc123
    dotnet dev-certs https --trust
```

- Executar comando `docker-compose up --build` na raiz da soluçao (onde se encontra esse README)

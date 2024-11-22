# Global Solution - Projeto SunShare

## Integrantes
- Cristian Alvaro Condori Paucara - RM550509 (2TDSPJ)
- Diego Seiti Ogita Iacabo - RM551289 (2TDSPJ)
- Giovanni Paschoalatto Ibelli - RM98837 (2TDSPJ)
- Luiz Felipe Azevedo de Oliveira - RM550348 (2TDSPX)
- Pedro Marques Pais Pavão - RM550252 (2TDSPX)

## Descrição do Projeto
Nos últimos anos, as energias renováveis têm desempenhado um papel fundamental na transição para um modelo energético mais sustentável. Fontes como a energia solar, eólica e hidrelétrica oferecem uma alternativa limpa às fontes fósseis, reduzindo a emissão de gases de efeito estufa e mitigando os impactos das mudanças climáticas. Entre essas fontes, a energia solar se destaca por sua acessibilidade e pelo potencial de ser amplamente utilizada, inclusive em residências e pequenos negócios.

Apesar das vantagens, muitos proprietários de sistemas de energia solar geram desperdícios, pois, ao produzirem mais energia do que consomem, acumulam créditos que muitas vezes não são aproveitados de forma plena. É nesse contexto que surge a SunShare, uma plataforma de compartilhamento de créditos de energia solar que conecta, por meio de contratos de locação, esses proprietários a consumidores interessados em reduzir custos e adotar práticas mais sustentáveis. 

Dessa forma, o projeto tem como objetivo facilitar e aproximar a interação entre os locadores e clientes através de um sistema de buscas e recomendações com base em preços, demandas e disponibilidade de créditos. Além disso, visa auxiliar nas questões legais do processo, atuando também na gestão de contratos ao estabelecer regras claras e personalizáveis para os termos de uso, valores e períodos de aluguel. Sendo assim, a plataforma transforma créditos excedentes de energia solar em um recurso ativo, permitindo que a energia solar seja utilizada de forma mais eficiente, o que reduz o desperdício e maximiza os benefícios para todos os envolvidos.

## Como Rodar a Aplicação
    1. Clonar o repositório: `git clone https://github.com/DiegoIacabo/SunShare_.NET.git`;
    
    2. Navegar até o diretório do projeto: `cd SunShare_.NET`;

    3. Abrir a aplicação no aplicativo do Visual Studio 2022;

    4. Verificar o acesso ao banco de dados no arquivo appsettings.json. No profile 'Development' coloque suas credenciais para conexão com Oracle;

    5. Rodar a aplicação com o mode de execução 'https';

    6. Testar as requisições através do Swagger no endereço: https://localhost:7295/swagger/index.html.

## Tecnologias Utilizadas
- API Web do ASP.NET Core (.NET 8.0)
- EntityFrameworkCore 8.0.11
- EntityFrameworkCore.Design 8.0.11
- EntityFrameworkCore.Tools 8.0.11
- Oracle.EntityFrameworkCore 
- xUnit e Moq para testes unitários
- ML.NET Model Builder

## Machine Learning
Pensando na evolução e crescimento do projeto a longo prazo, tivemos a ideia de desenvolver, através do ML.NET Model Builder, um modelo de detecção de fraude em compras por cartões de crédito, pois, por se tratar de uma plataforma em que haverá pagamentos através do aplicativo, é de suma importância manter a segurança e confiança dos usuários. Portanto, conseguir detectar e alertar nossos clientes de possíveis fraudes ou compras suspeitas é uma preocupação real para o projeto SunShare.         

Além disso, também foi desenvolvido um modelo de predição de geração de energia solar, uma ferramenta de extrema relevância para um planejamento de oferta e demanda ou até mesmo na definição de preços. A futura implementação dessa Inteligência Artificial pode vir a se um diferencial competitivo no mercado, auxiliando tanto locadores, quanto locatários a tomar suas decisões e, assim, melhorando a experiência dos usuários e aumentando a satisfação geral. 

### Links dos Datasets utilizados
- Credit Card Fraud Detection: https://www.kaggle.com/datasets/mlg-ulb/creditcardfraud
- Solar power Generation: https://www.kaggle.com/datasets/vipulgote4/solar-power-generation

## Vídeo Pitch
- Link: https://www.youtube.com/watch?v=haIFBOvtYp0
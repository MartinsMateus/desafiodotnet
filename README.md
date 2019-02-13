# desafiodotnet

DesafioDotNet

API RESTFull para autenticação e autorização de usuários, APIs de terceiros, projetos web MVC, SPA, Mobile e etc.

Aplicação foi criada de acordo com o frameowrk IdentityServer4 que é um framework OAuth 2.0 e OpenID Connect para ASP.NET Core 2. 
Os clientes podem interagir com a API de acordo com os tipos de concessão:<br>
        <ul>
	        <li>Implicit</li>
          <li>Hybrid</li>
          <li>Client credentials</li>
          <li>Resource owner password</li>
          <li>Refresh tokens</li>
        </ul>

Exemplo resource owner password:

1. Criar usuário:
<code>
post: http://localhost:60148/api/account/signup <br>
</code>
<br>
<code>
body:   Email=adolfojosedeandrade@gmail.com
        FirstName=Adolfo
        LastName=Andrade
        Password=12345678
        ConfirmPassword=12345678
</code>

2. Obter token:
<code>
post: http://localhost:60148/connect/token <br>
</code>
<br>
<code>
body:   client_id=mobile
        client_secret=secret
        grant_type=password
        scope=api_desafio_dot_net
        userName=adolfojosedeandrade@gmail.com
        password=12345678
</code>
<br>

3. Requisitar recursos:
<code>
get: http://localhost:60148/api/account/me <br>
</code>
<br>
<code>
body:   Authorization=Bearer toke_here
        Content-Type=application/json
</code>

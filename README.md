# gRPC-CMUX
Simulate multiplex connections in dotnet for gRPC (H2C) & HTTP using an Envoy proxy.

Serve gRPC service `http://localhost:5004/Greet.Greeter/SayHello` & REST API `http://localhost:5002/swagger` from the same TCP port `http://localhost:80`.

## Run
```
docker-compose up
```
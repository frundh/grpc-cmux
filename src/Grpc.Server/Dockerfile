FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
COPY ./Grpc.Server/ /src/Grpc.Server/
COPY ./Grpc.Proto/ /src/Grpc.Proto/
RUN set -ex; \
    dotnet publish /src/Grpc.Server -c Release -o /app;

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
ENV ASPNETCORE_URLS "http://0.0.0.0:80"
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
ENTRYPOINT [ "dotnet", "Grpc.Server.dll" ]

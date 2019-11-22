FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
COPY ./Grpc.Client/ /src/Grpc.Client/
COPY ./Grpc.Proto/ /src/Grpc.Proto/
RUN set -ex; \
    dotnet publish /src/Grpc.Client -c Release -o /app;

FROM mcr.microsoft.com/dotnet/core/runtime:3.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT [ "dotnet", "Grpc.Client.dll" ]
CMD [ "--help" ]
